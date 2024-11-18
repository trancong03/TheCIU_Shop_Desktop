using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class SizeDAL
    {
        private QuanLyShopDataContext db = new QuanLyShopDataContext();

        public List<Size> GetAllSizes()
        {
            return db.Sizes.ToList();
        }

        public Size GetSizeById(int id)
        {
            return db.Sizes.SingleOrDefault(s => s.size_id == id);
        }

        public bool InsertSize(Size size)
        {
            try
            {
                db.Sizes.InsertOnSubmit(size);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateSize(Size size)
        {
            try
            {
                var existingSize = db.Sizes.SingleOrDefault(s => s.size_id == size.size_id);
                if (existingSize != null)
                {
                    existingSize.size_name = size.size_name;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteSize(int id)
        {
            try
            {
                var size = db.Sizes.SingleOrDefault(s => s.size_id == id);
                if (size != null)
                {
                    db.Sizes.DeleteOnSubmit(size);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
