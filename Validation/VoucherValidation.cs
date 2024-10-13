using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class VoucherValidation
    {
        public bool ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return false;

            if (title.Length < 3 || title.Length > 50)
                return false;

            return true;
        }

        public bool ValidateDiscount(int? discount)
        {
            if (discount == null || discount <= 0 || discount > 100)
                return false;

            return true;
        }

        public bool ValidateDateRange(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null || endDate == null)
                return false;

            if (startDate > endDate)
                return false;

            return true;
        }
    }

}
