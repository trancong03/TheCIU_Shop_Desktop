using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class OrderDetailsDAL
    {
        private readonly QuanLyShopDataContext db = new QuanLyShopDataContext();

        public List<OrderDetail> GetAllOrderDetails()
        {
            return db.OrderDetails.ToList();
        }

        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return db.OrderDetails.Where(od => od.order_id == orderId).ToList();
        }

        public bool AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                db.OrderDetails.InsertOnSubmit(orderDetail);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                var existingDetail = db.OrderDetails.SingleOrDefault(od => od.order_id == orderDetail.order_id && od.variant_id == orderDetail.variant_id);
                if (existingDetail != null)
                {
                    existingDetail.quantity = orderDetail.quantity;
                    existingDetail.subtotal = orderDetail.subtotal;
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

        public bool DeleteOrderDetail(int orderId, int variantId)
        {
            try
            {
                var orderDetail = db.OrderDetails.SingleOrDefault(od => od.order_id == orderId && od.variant_id == variantId);
                if (orderDetail != null)
                {
                    db.OrderDetails.DeleteOnSubmit(orderDetail);
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
        // Trả về List<DetailsOrderDTO>
        public List<DetailsOrderDTO> GetOrderDetailsByOrderDetailsId(int orderId)
        {
            var query = from od in db.OrderDetails
                        join pv in db.ProductVariants on od.variant_id equals pv.variant_id
                        join p in db.Products on pv.product_id equals p.product_id
                        where od.order_id == orderId
                        select new DetailsOrderDTO
                        {
                            OrderId = od.order_id,
                            VariantId = od.variant_id,
                            ProductName = p.product_name,
                            Quantity = od.quantity.HasValue ? od.quantity.Value : 0,
                            Subtotal = od.subtotal.HasValue ? od.subtotal.Value : 0
                        };

            return query.ToList();
        }
    }
}
