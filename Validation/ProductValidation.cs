using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class ProductValidation
    {
        public bool ValidateProductCategory(int? category_id)
        {
            if (category_id == null || category_id <= 0)
                return false;

            return true;
        }

        // Kiểm tra tên sản phẩm có hợp lệ không
        public bool ValidateProductName(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
                return false;

            if (productName.Length < 3 || productName.Length > 50)
                return false;

            return true;
        }

        // Kiểm tra giá sản phẩm có hợp lệ không
        public bool ValidateProductPrice(double? price)
        {
            if (price == null || price <= 0)
                return false;

            return true;
        }
    }

}
