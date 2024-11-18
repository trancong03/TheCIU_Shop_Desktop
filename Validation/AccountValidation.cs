using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class AccountValidation
    {
        public ValidationResult ValidateUsername(string username)
        {
            if (ValidationHelper.IsNullOrEmpty(username) || !ValidationHelper.IsWithinLength(username, 3, 50))
                return new ValidationResult { IsValid = false, ErrorMessage = "Tên đăng nhập phải từ 3 đến 50 ký tự." };
            return new ValidationResult { IsValid = true };
        }

        public ValidationResult ValidatePassword(string password)
        {
            if (ValidationHelper.IsNullOrEmpty(password) || password.Length < 6)
                return new ValidationResult { IsValid = false, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự." };
            return new ValidationResult { IsValid = true };
        }

        public ValidationResult ValidateEmail(string email)
        {
            if (ValidationHelper.IsNullOrEmpty(email) || !email.Contains("@"))
                return new ValidationResult { IsValid = false, ErrorMessage = "Email không hợp lệ." };
            return new ValidationResult { IsValid = true };
        }

        public ValidationResult ValidatePhone(string phone)
        {
            if (ValidationHelper.IsNullOrEmpty(phone) || phone.Length != 10)
                return new ValidationResult { IsValid = false, ErrorMessage = "Số điện thoại phải có 10 chữ số." };
            return new ValidationResult { IsValid = true };
        }

        public ValidationResult ValidateAddress(string address)
        {
            if (ValidationHelper.IsNullOrEmpty(address))
                return new ValidationResult { IsValid = false, ErrorMessage = "Địa chỉ không được để trống." };
            return new ValidationResult { IsValid = true };
        }
    }



}
