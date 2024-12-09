using DTO;
using DAL;
using System;
using System.Collections.Generic;
using Validation;

namespace BLL
{
    public class OrderBLL
    {
        private readonly OrderDAL orderDAL = new OrderDAL();
        private readonly OrderDetailsDAL orderDetailsDAL = new OrderDetailsDAL();
        private readonly OrderValidation orderValidation = new OrderValidation();

        public List<Order> GetAllOrders()
        {
            return orderDAL.GetAllOrders();
        }

        public Order GetOrderById(int id)
        {
            return orderDAL.GetOrderById(id);
        }

        public bool AddOrder(Order order)
        {
            // Validate order amount
            var amountValidation = orderValidation.ValidateOrderAmount(order.amount);
            if (!amountValidation.IsValid)
                throw new Exception(amountValidation.ErrorMessage);

            // Validate order date
            var dateValidation = orderValidation.ValidateOrderDate(order.order_date);
            if (!dateValidation.IsValid)
                throw new Exception(dateValidation.ErrorMessage);

            // Add order to database
            return orderDAL.InsertOrder(order);
        }

        public bool EditOrder(Order order)
        {
            // Validate data
            var amountValidation = orderValidation.ValidateOrderAmount(order.amount);
            if (!amountValidation.IsValid)
                throw new Exception(amountValidation.ErrorMessage);

            var dateValidation = orderValidation.ValidateOrderDate(order.order_date);
            if (!dateValidation.IsValid)
                throw new Exception(dateValidation.ErrorMessage);

            return orderDAL.UpdateOrder(order);
        }

        public bool RemoveOrder(int id)
        {
            return orderDAL.DeleteOrder(id);
        }

        public bool UpdateOrderStatus(Order order)
        {
            var existingOrder = orderDAL.GetOrderById(order.order_id);
            if (existingOrder == null)
                throw new Exception("Không tìm thấy đơn hàng!");

            existingOrder.status = order.status;
            return orderDAL.UpdateOrder(existingOrder);
        }
        public List<Order> GetOrdersByStatus(int status)
        {
            return orderDAL.GetOrdersByStatus(status);
        }

        public bool UpdateOrderStatus(int orderId, int newStatus)
        {
            try
            {
                // Gọi DAL để cập nhật trạng thái
                return orderDAL.UpdateOrderStatus(orderId, newStatus);
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Phương thức sử dụng DTO
        public List<DetailsOrderDTO> GetOrderDetailsByStatus(int? status)
        {
            return orderDAL.GetOrderDetailsByStatus(status);
        }
        public List<DetailsOrderDTO> SearchOrders(string keyword)
        {
            // Kiểm tra từ khóa
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentException("Từ khóa tìm kiếm không được để trống!");

            // Gọi phương thức trong DAL
            return orderDAL.SearchOrders(keyword);
        }


    }
}
