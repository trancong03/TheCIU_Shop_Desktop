using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ClusteredCustomerDTO
    {
        public string CustomerID { get; set; }
        public uint ClusterId { get; set; }
        public string ClusterName { get; set; }
    }
}
