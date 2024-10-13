using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class OrderValidation
    {
        public bool ValidateOrderAmount(double? amount)
        {
            if (amount == null || amount <= 0)
                return false;

            return true;
        }

        public bool ValidateOrderDate(DateTime? orderDate)
        {
            if (orderDate == null || orderDate > DateTime.Now)
                return false;

            return true;
        }
    }

}
