using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace BLL
{
    public class VoucherBLL
    {
        private VoucherDAL voucherDAL = new VoucherDAL();
        private VoucherValidation voucherValidation = new VoucherValidation();

        public List<Voucher> GetAllVouchers()
        {
            return voucherDAL.GetAllVouchers();
        }

        public Voucher GetVoucherById(int id)
        {
            return voucherDAL.GetVoucherById(id);
        }

        public void AddVoucher(Voucher voucher)
        {

            if (!voucherValidation.ValidateTitle(voucher.tiltle))
                throw new Exception("Tiêu đề không hợp lệ.");

            if (!voucherValidation.ValidateDiscount(voucher.discount))
                throw new Exception("Giá trị giảm giá không hợp lệ.");

            voucherDAL.InsertVoucher(voucher);
        }

        public void EditVoucher(Voucher voucher)
        {
            if (!voucherValidation.ValidateTitle(voucher.tiltle))
                throw new Exception("Tiêu đề không hợp lệ.");

            if (!voucherValidation.ValidateDiscount(voucher.discount))
                throw new Exception("Giá trị giảm giá không hợp lệ.");


            voucherDAL.UpdateVoucher(voucher);
        }

        public void RemoveVoucher(int id)
        {
            voucherDAL.DeleteVoucher(id);
        }
    }

}
