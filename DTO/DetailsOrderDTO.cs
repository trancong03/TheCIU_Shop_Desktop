using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DetailsOrderDTO
    {
        // Thuộc tính từ bảng Orders
        public int OrderId { get; set; }          // order_id
        public string Username { get; set; }     // username
        public string CustomerName { get; set; } // Lấy từ Account -> name
        public DateTime? OrderDate { get; set; }  // order_date
        public int Status { get; set; }          // status
        public DateTime? PaymentDate { get; set; } // payment_date (nullable)
        public int? VoucherId { get; set; }      // voucher_id (nullable)
        public string VoucherName { get; set; }  // Tên Voucher nếu có
        public double Amount { get; set; }       // amount
        public string AddressDeliver { get; set; } // address_deliver

        // Thuộc tính từ bảng OrderDetails
        public int VariantId { get; set; }       // variant_id
        public string ProductName { get; set; }  // Tên sản phẩm từ Product -> product_name
        public int Quantity { get; set; }        // quantity
        public double Subtotal { get; set; }     // subtotal

        public string Name { get;set; }

        // Các thuộc tính mở rộng (nếu cần thêm thông tin)
        public string ColorName { get; set; }    // Tên màu từ Color
        public string SizeName { get; set; }     // Tên kích thước từ Size
    }
}
