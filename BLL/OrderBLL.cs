using DAL;
using DTO;
using System;
using System.Collections.Generic;
using Validation;

namespace BLL
{
    public class OrderBLL
    {
        private OrderDAL orderDAL = new OrderDAL();
        private OrderValidation orderValidation = new OrderValidation();

        public List<Order> GetAllOrders()
        {
            return orderDAL.GetAllOrders();
        }

        public Order GetOrderById(int id)
        {
            return orderDAL.GetOrderById(id);
        }

        public void AddOrder(Order order)
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
            orderDAL.InsertOrder(order);
        }

        public void EditOrder(Order order)
        {
            // Validate order amount
            var amountValidation = orderValidation.ValidateOrderAmount(order.amount);
            if (!amountValidation.IsValid)
                throw new Exception(amountValidation.ErrorMessage);

            // Validate order date
            var dateValidation = orderValidation.ValidateOrderDate(order.order_date);
            if (!dateValidation.IsValid)
                throw new Exception(dateValidation.ErrorMessage);

            // Update order in database
            orderDAL.UpdateOrder(order);
        }

        public void RemoveOrder(int id)
        {
            orderDAL.DeleteOrder(id);
        }
    }
}
