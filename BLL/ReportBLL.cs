using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DTO;

namespace BLL
{
    public class ReportBLL
    {
        private readonly OrderDAL orderDAL;
        private readonly OrderDetailsDAL orderDetailsDAL;
        private readonly ProductDAL productDAL;
        private readonly CategoryDAL categoryDAL;
        private readonly ProductVariantDAL productVariantDAL;

        public ReportBLL()
        {
            orderDAL = new OrderDAL();
            orderDetailsDAL = new OrderDetailsDAL();
            productDAL = new ProductDAL();
            categoryDAL = new CategoryDAL();
            productVariantDAL = new ProductVariantDAL();
        }

        // Tổng doanh thu theo ngày/tháng/năm
        public List<RevenueDetailDTO> GetRevenueByDateRangeDetails(DateTime startDate, DateTime endDate)
        {
            return orderDAL.GetAllOrders()
                .Where(o => o.order_date >= startDate && o.order_date <= endDate)
                .GroupBy(o => o.order_date.Value.Date)
                .Select(g => new RevenueDetailDTO
                {
                    Date = g.Key,
                    Revenue = g.Sum(o => o.amount ?? 0)
                })
                .ToList();
        }


        // Số lượng khách hàng mới theo ngày/tháng/năm
        public List<CustomerDetailDTO> GetNewCustomerDetails(DateTime startDate, DateTime endDate)
        {
            return orderDAL.GetAllOrders()
                .Where(o => o.order_date >= startDate && o.order_date <= endDate)
                .GroupBy(o => o.order_date.Value.Date)
                .Select(g => new CustomerDetailDTO
                {
                    Date = g.Key,
                    NewCustomers = g.Select(o => o.username).Distinct().Count()
                })
                .ToList();
        }


        // Doanh thu từng sản phẩm
        public List<ProductRevenueDTO> GetRevenueByProduct()
        {
            var orderDetails = orderDetailsDAL.GetAllOrderDetails();
            var productVariants = productVariantDAL.GetAllProductVariants();
            var products = productDAL.GetAllProducts();

            return (from detail in orderDetails
                    join variant in productVariants on detail.variant_id equals variant.variant_id
                    join product in products on variant.product_id equals product.product_id
                    group detail by product.product_name into grouped
                    select new ProductRevenueDTO
                    {
                        ProductName = grouped.Key,
                        TotalRevenue = (double)grouped.Sum(d => d.subtotal),
                        TotalQuantity = grouped.Sum(d => d.quantity)
                    }).ToList();
        }


        // Doanh thu theo danh mục sản phẩm
        public List<CategoryRevenueDTO> GetRevenueByCategory()
        {
            var orderDetails = orderDetailsDAL.GetAllOrderDetails();
            var productVariants = productVariantDAL.GetAllProductVariants();
            var products = productDAL.GetAllProducts();
            var categories = categoryDAL.GetAllCategories();

            return (from detail in orderDetails
                    join variant in productVariants on detail.variant_id equals variant.variant_id
                    join product in products on variant.product_id equals product.product_id
                    join category in categories on product.category_id equals category.category_id
                    group detail by category.category_name into grouped
                    select new CategoryRevenueDTO
                    {
                        Category = grouped.Key,
                        Revenue = (double)grouped.Sum(d => d.subtotal),
                        Quantity = grouped.Sum(d => d.quantity)
                    }).ToList();
        }


        // Tổng số đơn hàng
        public int GetTotalOrders()
        {
            return orderDAL.GetAllOrders().Count();
        }

        // Tổng số sản phẩm đã bán
        public int GetTotalProductsSold()
        {
            return orderDetailsDAL.GetAllOrderDetails().Sum(d => d.quantity);
        }

        // Tổng doanh thu
        public double GetTotalRevenue()
        {
            return orderDAL.GetAllOrders().Sum(o => o.amount ?? 0);
        }

        // Khách hàng mới
        public int GetNewCustomers()
        {
            var today = DateTime.Today;
            var customers = orderDAL.GetAllOrders()
                .Where(o => o.order_date >= today.AddDays(-30)) // Xem các đơn hàng trong 30 ngày qua
                .Select(o => o.username)
                .Distinct()
                .Count();

            return customers;
        }

        // Chi tiết doanh thu (hiển thị trong DataGridView)
        public List<RevenueDetailFullDTO> GetRevenueDetails()
        {
            var orderDetails = orderDetailsDAL.GetAllOrderDetails();
            var productVariants = productVariantDAL.GetAllProductVariants();
            var products = productDAL.GetAllProducts();
            var categories = categoryDAL.GetAllCategories();

            return (from detail in orderDetails
                    join variant in productVariants on detail.variant_id equals variant.variant_id
                    join product in products on variant.product_id equals product.product_id
                    join category in categories on product.category_id equals category.category_id
                    select new RevenueDetailFullDTO
                    {
                        OrderId = detail.order_id,
                        ProductName = product.product_name,
                        Category = category.category_name,
                        Quantity = detail.quantity,
                        Revenue = (double)detail.subtotal 
                    }).ToList();
        }

    }
}
