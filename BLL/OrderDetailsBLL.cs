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
        private readonly ProductDAL productDAL;

        public OrderDetailsBLL()
        {
            orderDetailsDAL = new OrderDetailsDAL();
            productVariantDAL = new ProductVariantDAL();
            productDAL = new ProductDAL();
        }

        public List<OrderDetail> GetAllOrderDetails()
        {
            return orderDetailsDAL.GetAllOrderDetails();
        }

        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return orderDetailsDAL.GetOrderDetailsByOrderId(orderId);
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
                Console.WriteLine($"Đang xử lý OrderDetail với VariantId: {detail.variant_id}");

                var variant = productVariantDAL.GetProductVariantById(detail.variant_id);
                if (variant != null)
                {
                    Console.WriteLine($"Lấy được Variant với ProductId: {variant.product_id}");

                    if (variant.product_id.HasValue)
                    {
                        var product = productDAL.GetProductById(variant.product_id.Value);
                        if (product != null)
                        {
                            Console.WriteLine($"Lấy được Product: {product.product_name} cho ProductId: {variant.product_id}");
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
                        else
                        {
                            Console.WriteLine($"Không tìm thấy Product cho ProductId: {variant.product_id}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"VariantId: {detail.variant_id} không có ProductId.");
                    }
                }
                else
                {
                    Console.WriteLine($"Không tìm thấy Variant cho VariantId: {detail.variant_id}");
                }
            }

            return result;
        }



    }
}