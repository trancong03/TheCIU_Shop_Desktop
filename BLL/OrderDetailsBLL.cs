using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class OrderDetailsBLL
    {
        private readonly OrderDetailsDAL orderDetailsDAL = new OrderDetailsDAL();
        private readonly ProductVariantDAL productVariantDAL = new ProductVariantDAL();
        private readonly ProductDAL productDAL = new ProductDAL();

        public List<OrderDetail> GetAllOrderDetails()
        {
            return orderDetailsDAL.GetAllOrderDetails();
        }

        public List<DetailsOrderDTO> GetOrderDetailsByOrderId(int orderId)
        {
            return orderDetailsDAL.GetOrderDetailsByOrderDetailsId(orderId);
        }

        public bool AddOrderDetail(OrderDetail orderDetail)
        {
            return orderDetailsDAL.AddOrderDetail(orderDetail);
        }

        public bool UpdateOrderDetail(OrderDetail orderDetail)
        {
            return orderDetailsDAL.UpdateOrderDetail(orderDetail);
        }

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
                if (variant == null) continue;

                var product = productDAL.GetProductById(variant.product_id ?? 0);
                if (product == null) continue;

                result.Add(new
                {
                    ProductName = product.product_name,
                    Quantity = detail.quantity,
                    Subtotal = detail.subtotal,
                    Size = variant.Size.size_name,
                    Color = variant.Color.color_name,
                    ProductId = variant.product_id,
                    VariantId = detail.variant_id
                });
            }

            return result;
        }
    }
}
