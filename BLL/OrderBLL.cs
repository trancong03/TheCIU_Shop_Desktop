using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (!orderValidation.ValidateOrderAmount(order.amount))
                throw new Exception("Số lượng đơn hàng không hợp lệ.");

            if (!orderValidation.ValidateOrderDate(order.order_date))
                throw new Exception("Ngày đơn hàng không hợp lệ.");

            orderDAL.InsertOrder(order);
        }

        public void EditOrder(Order order)
        {
            if (!orderValidation.ValidateOrderAmount(order.amount))
                throw new Exception("Số lượng đơn hàng không hợp lệ.");

            if (!orderValidation.ValidateOrderDate(order.order_date))
                throw new Exception("Ngày đơn hàng không hợp lệ.");

            orderDAL.UpdateOrder(order);
        }

        public void RemoveOrder(int id)
        {
            orderDAL.DeleteOrder(id);
        }
    }

}
