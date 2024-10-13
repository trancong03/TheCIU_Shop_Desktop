using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class OrderDetailValidation
    {
        public bool ValidateQuantity(int? quantity)
        {
            if (quantity == null || quantity <= 0)
                return false;

            return true;
        }

        public bool ValidateSubtotal(double? subtotal)
        {
            if (subtotal == null || subtotal <= 0)
                return false;

            return true;
        }
    }

}
