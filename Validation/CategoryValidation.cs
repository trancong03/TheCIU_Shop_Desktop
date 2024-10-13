using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class CategoryValidation
    {
        public bool ValidateCategoryName(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                return false;

            if (categoryName.Length < 3 || categoryName.Length > 50)
                return false;

            return true;
        }
    }

}
