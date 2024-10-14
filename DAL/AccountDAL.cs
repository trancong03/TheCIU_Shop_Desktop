using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class AccountDAL
    {
        private QuanLyShopDataContext db = new QuanLyShopDataContext();

        // Lấy tất cả tài khoản
        public List<Account> GetAllAccounts()
        {
            return db.Accounts.ToList();
        }

        // Lấy tài khoản theo username
        public Account GetAccountByUsername(string username)
        {
            return db.Accounts.FirstOrDefault(acc => acc.username == username);
        }

        // Lấy tài khoản theo username và password (đăng nhập)
        public Account GetAccountByUsernameAndPassword(string username, string password)
        {
            return db.Accounts.FirstOrDefault(acc => acc.username == username && acc.password == password);
        }
        public List<Account> SearchAccountsByUsername(string username)
        {
            using (QuanLyShopDataContext context = new QuanLyShopDataContext())
            {
                // Tìm kiếm gần đúng bằng cách sử dụng Contains trong LINQ
                var result = context.Accounts.Where(acc => acc.username.Contains(username)).ToList();
                return result;
            }
        }

        // Thêm tài khoản mới
        public void InsertAccount(Account account)
        {
            db.Accounts.InsertOnSubmit(account);
            db.SubmitChanges();
        }

        // Cập nhật tài khoản
        public void UpdateAccount(Account account)
        {
            var existingAccount = db.Accounts.FirstOrDefault(acc => acc.username == account.username);
            if (existingAccount != null)
            {
                existingAccount.name = account.name;
                existingAccount.password = account.password;
                existingAccount.email = account.email;
                existingAccount.phone = account.phone;
                existingAccount.address = account.address;
                existingAccount.gender = account.gender;
                existingAccount.status = account.status; // Cập nhật trạng thái tài khoản
                db.SubmitChanges();
            }
            else
            {
                throw new Exception("Tài khoản không tồn tại!");
            }
        }

        // Xóa tài khoản
        public void DeleteAccount(string username)
        {
            var account = db.Accounts.FirstOrDefault(acc => acc.username == username);
            if (account != null)
            {
                db.Accounts.DeleteOnSubmit(account);
                db.SubmitChanges();
            }
        }
    }
}
