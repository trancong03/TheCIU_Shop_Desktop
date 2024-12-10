using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLIntegration.Models
{
    public class CustomerData
    {
        public string CustomerID { get; set; }
        public float TotalSpending { get; set; }
        public float OrderCount { get; set; } // Chuyển sang float
        public float DaysSinceLastOrder { get; set; } // Chuyển sang float
        public float TotalQuantity { get; set; } // Chuyển sang float
    }
}

