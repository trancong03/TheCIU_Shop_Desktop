using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDAL
    {
        private QuanLyShopDataContext db = new QuanLyShopDataContext();

        // Get all accounts
        public List<Account> GetAllAccounts()
        {
            return db.Accounts.ToList();
        }

        // Get account by username
        public Account GetAccountByUsername(string username)
        {
            return db.Accounts.SingleOrDefault(a => a.username == username);
        }

        // Insert a new account
        public void InsertAccount(Account account)
        {
            db.Accounts.InsertOnSubmit(account);
            db.SubmitChanges();
        }

        // Update an existing account
        public void UpdateAccount(Account account)
        {
            var existingAccount = db.Accounts.SingleOrDefault(a => a.username == account.username);
            if (existingAccount != null)
            {
                existingAccount.password = account.password;
                existingAccount.email = account.email;
                // Update other fields as necessary
                db.SubmitChanges();
            }
        }

        // Delete an account
        public void DeleteAccount(string username)
        {
            var account = db.Accounts.SingleOrDefault(a => a.username == username);
            if (account != null)
            {
                db.Accounts.DeleteOnSubmit(account);
                db.SubmitChanges();
            }
        }
    }

}
