using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DTO;

namespace BLL
{
    public class StockBLL
    {
        private readonly ProductDAL productDAL = new ProductDAL();
        private readonly ProductVariantDAL productVariantDAL = new ProductVariantDAL();
        private readonly OrderDetailsDAL orderDetailsDAL = new OrderDetailsDAL();

        public StockBLL()
        {

        }
        // Product: product_id  ProductVariant Muốn biết sản phẩm có biến thể thì truy xuất đến bảng ProductVariant(variant_id) và lấy số lượng productVariant.quantity

        // Lấy danh sách tồn kho
        public List<dynamic> GetStockData(string search = "", int? categoryId = null)
        {
            // Get data from DAL
            var products = productDAL.GetAllProducts();
            var orderDetails = orderDetailsDAL.GetAllOrderDetails();

            var stockData = new List<dynamic>();

            // Calculate stock for each product
            foreach (var product in products)
            {
                // Get variants for the current product
                var productVariants = productVariantDAL.GetVariantsByProductId(product.product_id);

                foreach (var variant in productVariants)
                {
                    // LINQ logic to calculate stock for each variant
                    var totalSold = orderDetails
                        .Where(od => od.variant_id == variant.variant_id)
                        .Sum(od => od.quantity ?? 0);

                    stockData.Add(new
                    {
                        ProductId = product.product_id,
                        ProductName = product.product_name,
                        CategoryId = product.category_id,
                        VariantId = variant.variant_id,
                                                TotalStock = variant.quantity - totalSold
                    });
                }
            }

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
