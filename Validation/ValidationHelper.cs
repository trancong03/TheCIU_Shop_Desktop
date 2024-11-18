using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public static class ValidationHelper
    {
        public static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        public static bool IsWithinLength(string input, int min, int max)
        {
            return !IsNullOrEmpty(input) && input.Length >= min && input.Length <= max;
        }

        public static bool IsPositiveNumber(double? value)
        {
            return value.HasValue && value.Value > 0;
        }

        public static bool IsValidDate(DateTime? date)
        {
            return date.HasValue && date.Value <= DateTime.Now;
        }

        public static bool IsValidDateRange(DateTime? startDate, DateTime? endDate)
        {
            return startDate.HasValue && endDate.HasValue && startDate.Value <= endDate.Value;
        }
    }

}
