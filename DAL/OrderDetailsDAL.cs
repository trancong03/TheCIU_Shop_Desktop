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
                        join o in db.Orders on od.order_id equals o.order_id
                        join pv in db.ProductVariants on od.variant_id equals pv.variant_id
                        join p in db.Products on pv.product_id equals p.product_id
                        join v in db.Vouchers on o.voucher_id equals v.voucher_id into voucherJoin
                        from voucher in voucherJoin.DefaultIfEmpty() // Left join for Voucher
                        join acc in db.Accounts on o.username equals acc.username into accountJoin
                        from account in accountJoin.DefaultIfEmpty() // Left join for Account
                        where od.order_id == orderId
                        select new DetailsOrderDTO
                        {
                            OrderId = o.order_id,
                            Username = o.username,
                            CustomerName = account != null ? account.name : "Không rõ",
                            OrderDate = o.order_date,
                            Status = o.status.HasValue ? o.status.Value : 0,
                            PaymentDate = o.payment_date,
                            VoucherId = o.voucher_id,
                            VoucherName = voucher != null ? voucher.tiltle : "Không có",
                            Amount = o.amount.HasValue ? o.amount.Value : 0,
                            AddressDeliver = o.address,
                            VariantId = od.variant_id,
                            ProductName = p.product_name,
                            Quantity = od.quantity,
                            Subtotal = od.subtotal, // Dùng trực tiếp giá trị subtotal                                                   // Chuyển đổi thành decimal với 0m
                            ColorName = pv.Color.color_name,
                            SizeName = pv.Size.size_name
                        };

            return query.ToList();
        }


    }
}
