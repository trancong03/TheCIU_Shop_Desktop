using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class OrderDetailsDAL
    {
        private QuanLyShopDataContext db = new QuanLyShopDataContext();

        public OrderDetailsDAL()
        {
        }

        // Lấy tất cả chi tiết đơn hàng
        public List<OrderDetail> GetAllOrderDetails()
        {
            try
            {
                return db.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        // Lấy chi tiết đơn hàng theo mã đơn hàng
        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            try
            {
                return db.OrderDetails.Where(od => od.order_id == orderId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        // Thêm chi tiết đơn hàng
        public bool AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                db.OrderDetails.InsertOnSubmit(orderDetail);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        // Sửa chi tiết đơn hàng
        public bool UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                var existingOrderDetail = db.OrderDetails.FirstOrDefault(od => od.order_id == orderDetail.order_id && od.variant_id == orderDetail.variant_id);
                if (existingOrderDetail != null)
                {
                    existingOrderDetail.quantity = orderDetail.quantity;
                    existingOrderDetail.subtotal = orderDetail.subtotal;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        // Xóa chi tiết đơn hàng
        public bool DeleteOrderDetail(int orderId, int variantId)
        {
            try
            {
                var orderDetail = db.OrderDetails.FirstOrDefault(od => od.order_id == orderId && od.variant_id == variantId);
                if (orderDetail != null)
                {
                    db.OrderDetails.DeleteOnSubmit(orderDetail);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
