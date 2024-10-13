using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderDAL
    {
        private QuanLyShopDataContext db = new QuanLyShopDataContext();

        public List<Order> GetAllOrders()
        {
            return db.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return db.Orders.SingleOrDefault(o => o.order_id == id);
        }

        public void InsertOrder(Order order)
        {
            db.Orders.InsertOnSubmit(order);
            db.SubmitChanges();
        }

        public void UpdateOrder(Order order)
        {
            var existingOrder = db.Orders.SingleOrDefault(o => o.order_id == order.order_id);
            if (existingOrder != null)
            {
                existingOrder.status = order.status;
                existingOrder.amount = order.amount;
                // Update other fields as necessary
                db.SubmitChanges();
            }
        }

        public void DeleteOrder(int id)
        {
            var order = db.Orders.SingleOrDefault(o => o.order_id == id);
            if (order != null)
            {
                db.Orders.DeleteOnSubmit(order);
                db.SubmitChanges();
            }
        }
    }

}
