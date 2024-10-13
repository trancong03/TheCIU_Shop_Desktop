using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class AccountValidation
    {
        public bool ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username) || username.Length < 3 || username.Length > 50)
                return false;
            return true;
        }

        public bool ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                return false;
            return true;
        }

        public bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                return false;
            return true;
        }

        public bool ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone) || phone.Length != 10)
                return false;
            return true;
        }

        public bool ValidateAddress(string address)
        {
            return !string.IsNullOrWhiteSpace(address);
        }

        // Thêm kiểm tra tên
        public bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 2 || name.Length > 100)
                return false;
            return true;
        }
    }


}
