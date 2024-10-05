using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCIU_Shop.Data.Context;

namespace TheCIU_Shop.Data.Repository
{
    internal class UserRepository
    {
        private QuanLyShopDataContext _dbContext;

        public UserRepository(QuanLyShopDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool ValidateUser(string username, string password)
        {
            var user = _dbContext.NguoiDungs.FirstOrDefault(u => u.TenDangNhap == username && u.MatKhau == password);


            return user != null;
        }
    }
}
