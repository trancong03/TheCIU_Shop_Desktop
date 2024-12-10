using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class VoucherDAL
    {
        public List<Voucher> GetAllVouchers()
        {
            using (var db = new QuanLyShopDataContext())
            {
                return db.Vouchers.ToList();
            }
        }
        public List<Voucher> GetVouchersByStatus(bool status)
        {
            using (var db = new QuanLyShopDataContext())
            {
                return db.Vouchers.Where(v => v.status == status).ToList();
            }
        }

        public List<Voucher> SearchVouchers(string searchText)
        {
            using (var db = new QuanLyShopDataContext())
            {
                var query = db.Vouchers.AsQueryable();

                if (!string.IsNullOrEmpty(searchText))
                {
                    query = query.Where(v =>
                        v.voucher_id.Contains(searchText) ||
                        v.tiltle.Contains(searchText) ||
                        v.discription.Contains(searchText));
                }

                return query.ToList();
            }
        }

        public Voucher GetVoucherById(string id)
        {
            using (var db = new QuanLyShopDataContext())
            {
                return db.Vouchers.SingleOrDefault(v => v.voucher_id == id);
            }
        }

        public void InsertVoucher(Voucher voucher)
        {
            using (var db = new QuanLyShopDataContext())
            {
                db.Vouchers.InsertOnSubmit(voucher);
                db.SubmitChanges();
            }
        }

        public void UpdateVoucher(Voucher voucher)
        {
            using (var db = new QuanLyShopDataContext())
            {
                var existingVoucher = db.Vouchers.SingleOrDefault(v => v.voucher_id == voucher.voucher_id);
                if (existingVoucher != null)
                {
                    existingVoucher.tiltle = voucher.tiltle;
                    existingVoucher.discount = voucher.discount;
                    existingVoucher.status = voucher.status;
                    existingVoucher.dateStart = voucher.dateStart;
                    existingVoucher.dateEnd = voucher.dateEnd;
                    existingVoucher.discription = voucher.discription;

                    if (voucher.quantity >= 0)
                        existingVoucher.quantity = voucher.quantity;
                    else
                        throw new Exception("Số lượng không hợp lệ.");

                    db.SubmitChanges();
                }
                else
                {
                    throw new Exception($"Voucher với ID {voucher.voucher_id} không tồn tại.");
                }
            }
        }

        public void DeleteVoucher(string id)
        {
            using (var db = new QuanLyShopDataContext())
            {
                var voucher = db.Vouchers.SingleOrDefault(v => v.voucher_id == id);
                if (voucher != null)
                {
                    db.Vouchers.DeleteOnSubmit(voucher);
                    db.SubmitChanges();
                }
                else
                {
                    throw new Exception($"Voucher với ID {id} không tồn tại.");
                }
            }
        }
        public void AddVoucherToCustomer(string username, string voucherId)
        {
            using (var db = new QuanLyShopDataContext())
            {
                var existingEntry = db.product_vouchers.SingleOrDefault(pv => pv.username == username && pv.voucher_id == voucherId);

                if (existingEntry != null)
                {
                    existingEntry.count += 1; // Tăng số lượng voucher nếu đã tồn tại
                }
                else
                {
                    db.product_vouchers.InsertOnSubmit(new product_voucher
                    {
                        username = username,
                        voucher_id = voucherId,
                        count = 1
                    });
                }

                db.SubmitChanges();
            }
        }
        public void UpdateVoucherQuantity(string voucherId, int quantityUsed)
        {
            using (var db = new QuanLyShopDataContext())
            {
                var voucher = db.Vouchers.SingleOrDefault(v => v.voucher_id == voucherId);
                if (voucher == null)
                    throw new Exception($"Voucher với ID {voucherId} không tồn tại.");

                if (voucher.quantity < quantityUsed)
                    throw new Exception("Không đủ số lượng voucher để phân phối.");

                voucher.quantity -= quantityUsed;

                db.SubmitChanges();
            }
        }

    }
}
