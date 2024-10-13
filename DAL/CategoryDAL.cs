using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void InsertCategory(Category category)
        {
            db.Categories.InsertOnSubmit(category);
            db.SubmitChanges();
        }

        public void UpdateCategory(Category category)
        {
            var existingCategory = db.Categories.SingleOrDefault(c => c.category_id == category.category_id);
            if (existingCategory != null)
            {
                existingCategory.category_name = category.category_name;
                // Update other fields as necessary
                db.SubmitChanges();
            }
        }

        public void DeleteCategory(int id)
        {
            var category = db.Categories.SingleOrDefault(c => c.category_id == id);
            if (category != null)
            {
                db.Categories.DeleteOnSubmit(category);
                db.SubmitChanges();
            }
        }
    }

}
