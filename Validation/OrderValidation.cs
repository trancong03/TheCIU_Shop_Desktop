using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class OrderValidation
    {
        public ValidationResult ValidateOrderAmount(double? amount)
        {
            if (!ValidationHelper.IsPositiveNumber(amount))
                return new ValidationResult { IsValid = false, ErrorMessage = "Số lượng đơn hàng phải lớn hơn 0." };
            return new ValidationResult { IsValid = true };
        }

        public ValidationResult ValidateOrderDate(DateTime? orderDate)
        {
            if (!ValidationHelper.IsValidDate(orderDate))
                return new ValidationResult { IsValid = false, ErrorMessage = "Ngày đơn hàng không hợp lệ." };
            return new ValidationResult { IsValid = true };
        }
    }


}
