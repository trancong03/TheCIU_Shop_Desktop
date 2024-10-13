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
    public class AccountBLL
    {
        private AccountDAL accountDAL = new AccountDAL();
        private AccountValidation accountValidation = new AccountValidation();

        // Get all accounts
        public List<Account> GetAllAccounts()
        {
            return accountDAL.GetAllAccounts();
        }

        // Get account by username
        public Account GetAccountByUsername(string username)
        {
            return accountDAL.GetAccountByUsername(username);
        }

        // Add a new account
        public void AddAccount(Account account)
        {
            if (!accountValidation.ValidateUsername(account.username))
                throw new Exception("Tên đăng nhập không hợp lệ.");

            if (!accountValidation.ValidatePassword(account.password))
                throw new Exception("Mật khẩu không hợp lệ.");

            if (!accountValidation.ValidateEmail(account.email))
                throw new Exception("Email không hợp lệ.");

            if (!accountValidation.ValidatePhone(account.phone))
                throw new Exception("Số điện thoại không hợp lệ.");

            accountDAL.InsertAccount(account);
        }

        // Edit an existing account
        public void EditAccount(Account account)
        {
            if (!accountValidation.ValidateUsername(account.username))
                throw new Exception("Tên đăng nhập không hợp lệ.");

            if (!accountValidation.ValidatePassword(account.password))
                throw new Exception("Mật khẩu không hợp lệ.");

            if (!accountValidation.ValidateEmail(account.email))
                throw new Exception("Email không hợp lệ.");

            if (!accountValidation.ValidatePhone(account.phone))
                throw new Exception("Số điện thoại không hợp lệ.");

            accountDAL.UpdateAccount(account);
        }

        // Remove an account
        public void RemoveAccount(string username)
        {
            accountDAL.DeleteAccount(username);
        }
        public bool CheckLogin(string username, string password)
        {
            Account account = accountDAL.GetAccountByUsernameAndPassword(username, password);
            return account != null; 
        }

        public void RegisterNewAccount(string username,string name, string password, string email, string phone, string address, string gender, string avatarPath, string backgroundPath)
        {
            if (!accountValidation.ValidateUsername(username))
                throw new Exception("Tên đăng nhập không hợp lệ.");

            if (!accountValidation.ValidatePassword(password))
                throw new Exception("Mật khẩu không hợp lệ.");

            if (!accountValidation.ValidateEmail(email))
                throw new Exception("Email không hợp lệ.");

            if (!accountValidation.ValidatePhone(phone))
                throw new Exception("Số điện thoại không hợp lệ.");

            Account existingAccount = accountDAL.GetAccountByUsername(username);
            if (existingAccount != null)
            {
                throw new Exception("Tài khoản đã tồn tại.");
            }

            // Tạo tài khoản mới
            Account newAccount = new Account
            {
                username = username,
                name = name,
                password = password,
                email = email,
                phone = phone,
                address = address,
                gender = gender,
                avatar = avatarPath,
                background = backgroundPath
            };

            accountDAL.InsertAccount(newAccount);
        }
    }

}
