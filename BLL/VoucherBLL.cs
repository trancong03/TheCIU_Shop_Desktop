using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class VoucherBLL
    {
        private VoucherDAL voucherDAL = new VoucherDAL();

        public List<Voucher> GetAllVouchers()
        {
            return voucherDAL.GetAllVouchers();
        }

        public List<Voucher> GetActiveVouchers()
        {
            return voucherDAL.GetAllVouchers()
                .Where(v => v.dateStart <= DateTime.Now && v.dateEnd >= DateTime.Now && v.status == true)
                .ToList();
        }

        public Voucher GetVoucherById(string id)
        {
            return voucherDAL.GetVoucherById(id);
        }

        public void AddVoucher(Voucher voucher)
        {
            ValidateVoucher(voucher);
            var existingVoucher = voucherDAL.GetVoucherById(voucher.voucher_id);
            if (existingVoucher != null)
                throw new Exception("Voucher với id này đã tồn tại.");

            voucherDAL.InsertVoucher(voucher);
        }

        public void EditVoucher(Voucher voucher)
        {
            ValidateVoucher(voucher);
            voucherDAL.UpdateVoucher(voucher);
        }

        public void RemoveVoucher(string id)
        {
            voucherDAL.DeleteVoucher(id);
        }

        public List<Voucher> SearchVouchers(string searchText)
        {
            return voucherDAL.SearchVouchers(searchText);
        }

        private void ValidateVoucher(Voucher voucher)
        {
            if (string.IsNullOrWhiteSpace(voucher.tiltle))
                throw new Exception("Tiêu đề không được để trống.");

            if (voucher.discount <= 0)
                throw new Exception("Giảm giá phải là số lớn hơn 0.");

            if (voucher.dateStart > voucher.dateEnd)
                throw new Exception("Ngày bắt đầu không được lớn hơn ngày kết thúc.");

            if (voucher.quantity < 0)
                throw new Exception("Số lượng phải là số nguyên không âm.");
        }
        public List<Voucher> GetExpiredVouchers()
        {
            return voucherDAL.GetAllVouchers()
                .Where(v => v.dateEnd < DateTime.Now)
                .ToList();
        }
        public void DistributeVoucher(string voucherId, List<string> customerIds)
        {
            if (string.IsNullOrWhiteSpace(voucherId))
                throw new ArgumentException("ID voucher không hợp lệ.", nameof(voucherId));
            if (customerIds == null || !customerIds.Any())
                throw new ArgumentException("Danh sách khách hàng không hợp lệ.", nameof(customerIds));

            // Lấy thông tin voucher
            var voucher = voucherDAL.GetVoucherById(voucherId);
            if (voucher == null || voucher.quantity < customerIds.Count)
                throw new Exception("Voucher không tồn tại hoặc số lượng không đủ để phân phối.");

            foreach (var customerId in customerIds)
            {
                if (string.IsNullOrWhiteSpace(customerId))
                    throw new ArgumentException("ID khách hàng không hợp lệ.", nameof(customerIds));

                // Thêm bản ghi vào bảng product_voucher
                voucherDAL.AddVoucherToCustomer(customerId, voucherId);
            }

            // Cập nhật số lượng voucher
            voucher.quantity -= customerIds.Count;
            voucherDAL.UpdateVoucher(voucher);
        }



    }
}
