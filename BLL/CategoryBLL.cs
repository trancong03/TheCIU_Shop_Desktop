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
    public class CategoryBLL
    {
        private CategoryDAL categoryDAL = new CategoryDAL();
        private CategoryValidation categoryValidation = new CategoryValidation();

        public List<Category> GetAllCategories()
        {
            return categoryDAL.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
            return categoryDAL.GetCategoryById(id);
        }

        public void AddCategory(Category category)
        {
            if (!categoryValidation.ValidateCategoryName(category.category_name))
                throw new Exception("Tên danh mục không hợp lệ.");

            categoryDAL.InsertCategory(category);
        }

        public void EditCategory(Category category)
        {
            if (!categoryValidation.ValidateCategoryName(category.category_name))
                throw new Exception("Tên danh mục không hợp lệ.");

            categoryDAL.UpdateCategory(category);
        }

        public void RemoveCategory(int id)
        {
            categoryDAL.DeleteCategory(id);
        }
    }

}
