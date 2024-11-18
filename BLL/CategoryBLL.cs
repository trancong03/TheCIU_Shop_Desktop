using DAL;
using DTO;
using System;
using System.Collections.Generic;
using Validation;

namespace BLL
{
    public class CategoryBLL
    {
        private CategoryDAL categoryDAL = new CategoryDAL();
        private CategoryValidation categoryValidation = new CategoryValidation();

        // Lấy tất cả danh mục
        public List<Category> GetAllCategories()
        {
            return categoryDAL.GetAllCategories();
        }

        // Lấy danh mục theo ID
        public Category GetCategoryById(int id)
        {
            return categoryDAL.GetCategoryById(id);
        }

        // Thêm danh mục mới
        public bool AddCategory(Category category)
        {
            ValidateField(categoryValidation.ValidateCategoryName(category.category_name), "Tên danh mục không hợp lệ.");
            return categoryDAL.InsertCategory(category);
        }

        // Sửa danh mục
        public bool EditCategory(Category category)
        {
            ValidateField(categoryValidation.ValidateCategoryName(category.category_name), "Tên danh mục không hợp lệ.");
            return categoryDAL.UpdateCategory(category);
        }

        // Xóa danh mục
        public bool RemoveCategory(int id)
        {
            return categoryDAL.DeleteCategory(id);
        }

        // Phương thức kiểm tra dữ liệu và ném ngoại lệ nếu không hợp lệ
        private void ValidateField(ValidationResult validationResult, string errorMessage)
        {
            if (!validationResult.IsValid)
                throw new Exception(errorMessage);
        }
    }
}
