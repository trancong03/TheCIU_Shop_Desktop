using DAL;
using DTO;
using System;
using System.Collections.Generic;
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

        // Search accounts by username
        public List<Account> SearchAccounts(string username)
        {
            return accountDAL.SearchAccountsByUsername(username);
        }

        // Add a new account
        public void AddAccount(Account account)
        {
            ValidateAccount(account);

            // Check if the username already exists
            var existingAccount = accountDAL.GetAccountByUsername(account.username);
            if (existingAccount != null)
                throw new Exception("Tài khoản đã tồn tại.");

            accountDAL.InsertAccount(account);
        }

        public void EditAccount(Account account)
        {
            ValidateAccount(account);

            // Update the account
            accountDAL.UpdateAccount(account);
        }

        public void RemoveAccount(string username)
        {
            accountDAL.DeleteAccount(username);
        }

        public Account CheckLogin(string username, string password)
        {
            var account = accountDAL.GetAccountByUsernameAndPassword(username, password);
            if (account != null && account.password == password)
                return account;

            return null;
        }

        public void RegisterNewAccount(string username, string name, string password, string email, string phone, string address, string gender, string avatarPath, string backgroundPath)
        {
            // Validate individual fields
            ValidateField(accountValidation.ValidateUsername(username), "Tên đăng nhập không hợp lệ.");
            ValidateField(accountValidation.ValidatePassword(password), "Mật khẩu không hợp lệ.");
            ValidateField(accountValidation.ValidateEmail(email), "Email không hợp lệ.");
            ValidateField(accountValidation.ValidatePhone(phone), "Số điện thoại không hợp lệ.");

            // Check if the account already exists
            var existingAccount = accountDAL.GetAccountByUsername(username);
            if (existingAccount != null)
                throw new Exception("Tài khoản đã tồn tại.");

            // Create a new account
            var newAccount = new Account
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

        // Helper method to validate an account
        private void ValidateAccount(Account account)
        {
            ValidateField(accountValidation.ValidateUsername(account.username), "Tên đăng nhập không hợp lệ.");
            ValidateField(accountValidation.ValidatePassword(account.password), "Mật khẩu không hợp lệ.");
            ValidateField(accountValidation.ValidateEmail(account.email), "Email không hợp lệ.");
            ValidateField(accountValidation.ValidatePhone(account.phone), "Số điện thoại không hợp lệ.");
            ValidateField(accountValidation.ValidateAddress(account.address), "Địa chỉ không hợp lệ.");
        }

        // Helper method to throw an exception with a custom message
        private void ValidateField(ValidationResult validationResult, string errorMessage)
        {
            if (!validationResult.IsValid)
                throw new Exception(errorMessage);
        }
    }
}
