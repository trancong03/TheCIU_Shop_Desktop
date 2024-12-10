using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class OrderDAL
    {
        private readonly QuanLyShopDataContext db = new QuanLyShopDataContext();

        public List<Order> GetAllOrders()
        {
            return db.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return db.Orders.SingleOrDefault(o => o.order_id == id);
        }
        public List<Order> GetOrdersByStatus(int status)
        {
            return db.Orders.Where(o => o.status == status).ToList();
        }
        public bool InsertOrder(Order order)
        {
            try
            {
                db.Orders.InsertOnSubmit(order);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateOrder(Order order)
        {
            try
            {
                var existingOrder = db.Orders.SingleOrDefault(o => o.order_id == order.order_id);
                if (existingOrder != null)
                {
                    existingOrder.status = order.status;
                    existingOrder.amount = order.amount;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteOrder(int id)
        {
            try
            {
                var order = db.Orders.SingleOrDefault(o => o.order_id == id);
                if (order != null)
                {
                    db.Orders.DeleteOnSubmit(order);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateOrderStatus(int orderId, int newStatus)
        {
            try
            {
                var order = db.Orders.SingleOrDefault(o => o.order_id == orderId);
                if (order != null)
                {
                    order.status = newStatus;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public List<DetailsOrderDTO> GetOrderDetailsByStatus(int? status)
        {
            try
            {
                var result = from order in db.Orders
                             where order.status == status
                             join account in db.Accounts on order.username equals account.username
                             join orderDetail in db.OrderDetails on order.order_id equals orderDetail.order_id
                             join productVariant in db.ProductVariants on orderDetail.variant_id equals productVariant.variant_id
                             join product in db.Products on productVariant.product_id equals product.product_id
                             select new DetailsOrderDTO
                             {
                                 OrderId = order.order_id,
                                 Username = order.username,
                                 CustomerName = account.name,
                                 OrderDate = order.order_date.HasValue
                                ? order.order_date.Value
                                : (DateTime?)null, // Đảm bảo kiểu nullable nếu cần

                                 Status = order.status ?? 0,
                                 PaymentDate = order.payment_date,
                                 VoucherId = order.voucher_id,
                                 Amount = order.amount ?? 0,
                                 AddressDeliver = order.address,
                                 VariantId = orderDetail.variant_id,
                                 ProductName = product.product_name,
                                 Quantity = orderDetail.quantity,
                                 Subtotal = orderDetail.subtotal
                             };

                // Group by OrderId to ensure unique rows per order
                var groupedResult = result.GroupBy(o => o.OrderId)
                                          .Select(g => g.First())
                                          .ToList();
                return groupedResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<DetailsOrderDTO>();
            }
        }
        public List<DetailsOrderDTO> SearchOrders(string keyword)
        {
            try
            {
                // Tìm kiếm trên các trường cần thiết
                var result = from order in db.Orders
                             join account in db.Accounts on order.username equals account.username
                             where order.order_id.ToString().Contains(keyword) || // Tìm theo mã đơn hàng
                                   account.name.Contains(keyword) ||             // Tìm theo tên khách hàng
                                   order.address.Contains(keyword)       // Tìm theo địa chỉ giao hàng
                             select new DetailsOrderDTO
                             {
                                 OrderId = order.order_id,
                                 Username = order.username,
                                 CustomerName = account.name,
                                 OrderDate = order.order_date.HasValue ? order.order_date.Value : (DateTime?)null,
                                 Status = order.status ?? 0,
                                 PaymentDate = order.payment_date,
                                 VoucherId = order.voucher_id,
                                 Amount = order.amount ?? 0,
                                 AddressDeliver = order.address
                             };

                return result.Distinct().ToList(); // Sử dụng Distinct để loại bỏ kết quả trùng lặp
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchOrders: {ex.Message}");
                return new List<DetailsOrderDTO>(); // Trả về danh sách rỗng nếu có lỗi
            }
        }


        public List<DetailsOrderDTO> GetOrderDetailsByOrderId(int orderId)
        {
            // Truy vấn dữ liệu chi tiết đơn hàng từ bảng OrderDetails và ánh xạ sang DTO
            var query = from od in db.OrderDetails
                        join pv in db.ProductVariants on od.variant_id equals pv.variant_id
                        join p in db.Products on pv.product_id equals p.product_id
                        where od.order_id == orderId
                        select new DetailsOrderDTO
                        {
                            OrderId = od.order_id,
                            VariantId = od.variant_id,
                            ProductName = p.product_name,
                            Quantity = od.quantity,
                            Subtotal = od.subtotal
                        };

            return query.ToList();
        }
    }
}
