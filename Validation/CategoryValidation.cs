using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class CategoryValidation
    {
        public ValidationResult ValidateCategoryName(string categoryName)
        {
            if (!ValidationHelper.IsWithinLength(categoryName, 3, 50))
                return new ValidationResult { IsValid = false, ErrorMessage = "Tên danh mục phải từ 3 đến 50 ký tự." };
            return new ValidationResult { IsValid = true };
        }
    }


}
