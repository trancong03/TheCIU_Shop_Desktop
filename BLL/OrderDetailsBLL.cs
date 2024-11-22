using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class OrderDetailsBLL
    {
        private readonly OrderDetailsDAL orderDetailsDAL;
        private readonly ProductVariantDAL productVariantDAL;

        public OrderDetailsBLL()
        {
            orderDetailsDAL = new OrderDetailsDAL();
            productVariantDAL = new ProductVariantDAL();
        }

        // Lấy tất cả chi tiết đơn hàng
        public List<OrderDetail> GetAllOrderDetails()
        {
            return orderDetailsDAL.GetAllOrderDetails();
        }

        // Lấy chi tiết đơn hàng theo mã đơn hàng
        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return orderDetailsDAL.GetOrderDetailsByOrderId(orderId);
        }

        // Thêm chi tiết đơn hàng
        public bool AddOrderDetail(OrderDetail orderDetail)
        {
            return orderDetailsDAL.AddOrderDetail(orderDetail);
        }

        // Sửa chi tiết đơn hàng
        public bool UpdateOrderDetail(OrderDetail orderDetail)
        {
            return orderDetailsDAL.UpdateOrderDetail(orderDetail);
        }

        // Xóa chi tiết đơn hàng
        public bool DeleteOrderDetail(int orderId, int variantId)
        {
            return orderDetailsDAL.DeleteOrderDetail(orderId, variantId);
        }
        public List<dynamic> GetOrderDetailsWithProductInfo(int orderId)
        {
            var orderDetails = orderDetailsDAL.GetOrderDetailsByOrderId(orderId);
            var result = new List<dynamic>();

            foreach (var detail in orderDetails)
            {
                var variant = productVariantDAL.GetProductVariantById(detail.variant_id);
                if (variant != null)
                {
                    result.Add(new
                    {
                        OrderId = detail.order_id,
                        VariantId = detail.variant_id,
                        Quantity = detail.quantity,
                        Subtotal = detail.subtotal,
                        ProductId = variant.product_id,
                        Size = variant.Size.size_name,
                        Color = variant.Color.color_name
                    });
                }
            }

            return result;
        }
    }
}
