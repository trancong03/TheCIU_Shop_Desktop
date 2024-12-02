using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDetailDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public DateTime DateAdd { get; set; }
        public float Rating { get; set; }
        public string ImageSP { get; set; }
        public string CategoryName { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
    }

}
