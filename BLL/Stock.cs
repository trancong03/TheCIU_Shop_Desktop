using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DTO;

namespace BLL
{
    public class StockBLL
    {
        private readonly ProductDAL productDAL;
        private readonly ProductVariantDAL productVariantDAL;
        private readonly OrderDetailsDAL orderDetailsDAL;

        public StockBLL()
        {
            productDAL = new ProductDAL();
            orderDetailsDAL = new OrderDetailsDAL();
        }

        // Lấy danh sách tồn kho
        public List<dynamic> GetStockData(string search = "", int? categoryId = null)
        {
            // Get data from DAL
            var products = productDAL.GetAllProducts();
            var productVariants = productVariantDAL.GetAllProductVariants();
            var orderDetails = orderDetailsDAL.GetAllOrderDetails();

            // LINQ query to calculate stock
            var stockData = from product in products
                            join variant in productVariants on product.product_id equals variant.product_id
                            join detail in orderDetails on variant.variant_id equals detail.variant_id into productDetails
                            from detail in productDetails.DefaultIfEmpty() // Handle products with no orders
                            group detail by new
                            {
                                product.product_id,
                                product.product_name,
                                product.category_id,
                                variant.quantity
                            } into grouped
                            let totalSold = grouped.Sum(d => d?.quantity ?? 0) // Sum of quantities sold
                            select new
                            {
                                ProductId = grouped.Key.product_id,
                                ProductName = grouped.Key.product_name,
                                CategoryId = grouped.Key.category_id,
                                TotalStock = grouped.Key.quantity - totalSold
                            };

            // Apply filters and return the result
            return stockData
                .Where(p => (string.IsNullOrEmpty(search) || p.ProductName.Contains(search)) &&
                            (categoryId == null || p.CategoryId == categoryId))
                .ToList<dynamic>();
        }



        // Lấy danh sách sản phẩm tồn ít
        public List<dynamic> GetLowStockProducts(int threshold = 10)
        {
            var stockData = GetStockData();
            return stockData.Where(p => p.TotalStock < threshold).ToList();
        }
    }
}
