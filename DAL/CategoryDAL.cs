using DTO;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class CategoryDAL
    {
        private QuanLyShopDataContext db = new QuanLyShopDataContext();

        public List<Category> GetAllCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return db.Categories.SingleOrDefault(c => c.category_id == id);
        }

        public bool InsertCategory(Category category)
        {
            try
            {
                db.Categories.InsertOnSubmit(category);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                var existingCategory = db.Categories.SingleOrDefault(c => c.category_id == category.category_id);
                if (existingCategory != null)
                {
                    existingCategory.category_name = category.category_name;
                    // Update other fields as necessary
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

        public bool DeleteCategory(int id)
        {
            try
            {
                var category = db.Categories.SingleOrDefault(c => c.category_id == id);
                if (category != null)
                {
                    db.Categories.DeleteOnSubmit(category);
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
