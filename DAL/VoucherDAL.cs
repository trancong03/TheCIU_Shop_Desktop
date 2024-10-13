using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VoucherDAL
    {
        private QuanLyShopDataContext db = new QuanLyShopDataContext();

        public List<Voucher> GetAllVouchers()
        {
            return db.Vouchers.ToList();
        }

        public Voucher GetVoucherById(int id)
        {
            return db.Vouchers.SingleOrDefault(v => v.voucher_id == id);
        }

        public void InsertVoucher(Voucher voucher)
        {
            db.Vouchers.InsertOnSubmit(voucher);
            db.SubmitChanges();
        }

        public void UpdateVoucher(Voucher voucher)
        {
            var existingVoucher = db.Vouchers.SingleOrDefault(v => v.voucher_id == voucher.voucher_id);
            if (existingVoucher != null)
            {
                existingVoucher.tiltle = voucher.tiltle;
                existingVoucher.discount = voucher.discount;
                // Update other fields as necessary
                db.SubmitChanges();
            }
        }

        public void DeleteVoucher(int id)
        {
            var voucher = db.Vouchers.SingleOrDefault(v => v.voucher_id == id);
            if (voucher != null)
            {
                db.Vouchers.DeleteOnSubmit(voucher);
                db.SubmitChanges();
            }
        }
    }

}
