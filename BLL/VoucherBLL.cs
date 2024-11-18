using DAL;
using DTO;
using System;
using System.Collections.Generic;
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
            ValidateVoucher(voucher);
            voucherDAL.InsertVoucher(voucher);
        }

        public void EditVoucher(Voucher voucher)
        {
            ValidateVoucher(voucher);
            voucherDAL.UpdateVoucher(voucher);
        }

        public void RemoveVoucher(int id)
        {
            voucherDAL.DeleteVoucher(id);
        }

        private void ValidateVoucher(Voucher voucher)
        {
            ValidateField(voucherValidation.ValidateTitle(voucher.tiltle), "Tiêu đề không hợp lệ.");
            ValidateField(voucherValidation.ValidateDiscount(voucher.discount), "Giảm giá không hợp lệ.");
            //ValidateField(voucherValidation.ValidateDateRange(voucher.dateStart, voucher.dateEnd), "Khoảng ngày không hợp lệ.");
        }

        private void ValidateField(ValidationResult validationResult, string errorMessage)
        {
            if (!validationResult.IsValid)
                throw new Exception(errorMessage);
        }
    }
}
