using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class ProductValidation
    {
        public ValidationResult ValidateProductCategory(int? category_id)
        {
            if (!ValidationHelper.IsPositiveNumber(category_id))
                return new ValidationResult { IsValid = false, ErrorMessage = "Danh mục sản phẩm không hợp lệ." };
            return new ValidationResult { IsValid = true };
        }

        public ValidationResult ValidateProductName(string productName)
        {
            if (!ValidationHelper.IsWithinLength(productName, 3, 50))
                return new ValidationResult { IsValid = false, ErrorMessage = "Tên sản phẩm phải từ 3 đến 50 ký tự." };
            return new ValidationResult { IsValid = true };
        }

        public ValidationResult ValidateProductPrice(double? price)
        {
            if (!ValidationHelper.IsPositiveNumber(price))
                return new ValidationResult { IsValid = false, ErrorMessage = "Giá sản phẩm phải lớn hơn 0." };
            return new ValidationResult { IsValid = true };
        }
    }

}
