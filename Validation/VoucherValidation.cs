using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class VoucherValidation
    {
        public ValidationResult ValidateTitle(string title)
        {
            if (!ValidationHelper.IsWithinLength(title, 3, 50))
                return new ValidationResult { IsValid = false, ErrorMessage = "Tiêu đề phải từ 3 đến 50 ký tự." };
            return new ValidationResult { IsValid = true };
        }

        public ValidationResult ValidateDiscount(int? discount)
        {
            if (discount == null || discount <= 0 || discount > 100)
                return new ValidationResult { IsValid = false, ErrorMessage = "Giảm giá phải từ 1 đến 100%." };
            return new ValidationResult { IsValid = true };
        }

        public ValidationResult ValidateDateRange(DateTime? startDate, DateTime? endDate)
        {
            if (!ValidationHelper.IsValidDateRange(startDate, endDate))
                return new ValidationResult { IsValid = false, ErrorMessage = "Khoảng ngày không hợp lệ." };
            return new ValidationResult { IsValid = true };
        }
    }
}
