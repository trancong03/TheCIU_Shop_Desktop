using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class ProductDAL
    {
        private readonly QuanLyShopDataContext context = new QuanLyShopDataContext();
        private readonly CategoryDAL categoryDAL = new CategoryDAL();

        // Lấy tất cả sản phẩm
        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }
        public List<ProductDetailDTO> FilterProductsByPrice(float price)
        {
            return context.Products
                .Where(p => p.price == price)
                .Select(p => new ProductDetailDTO
                {
                    ProductId = p.product_id,
                    ProductName = p.product_name,
                    Price = p.price ?? 0,
                    CategoryName = p.Category.category_name,
                    DateAdd = p.Dateadd ?? DateTime.MinValue,
                    ImageSP = p.ImageSP,
                    Title = p.Title
                })
                .OrderBy(p => p.Price)
                .ToList();
        }
        public Product GetProductById(int productId)
        {
            return context.Products.FirstOrDefault(p => p.product_id == productId);
        }

        public List<ProductDetailDTO> GetBasicProductDetails()
        {
            return (from p in GetAllProducts()
                    join cat in categoryDAL.GetAllCategories() on p.category_id equals cat.category_id into categoryGroup
                    from category in categoryGroup.DefaultIfEmpty()
                    select new ProductDetailDTO
                    {
                        ProductId = p.product_id,
                        ProductName = p.product_name,
                        Title = p.Title,
                        Price = p.price ?? 0,
                        DateAdd = p.Dateadd ?? DateTime.MinValue,
                        Rating = (float)(p.rating ?? 0),
                        ImageSP = p.ImageSP,
                        CategoryName = category?.category_name,
                        CategoryId = p.category_id ?? 0
                    }).ToList();
        }

        // Thêm sản phẩm và biến thể trong một transaction
        public bool AddProductWithVariant(Product product, ProductVariant variant)
        {
            using (var transaction = context.Connection.BeginTransaction())
            {
                try
                {
                    context.Transaction = transaction;

                    // Thêm sản phẩm
                    context.Products.InsertOnSubmit(product);
                    context.SubmitChanges();

                    // Gắn `product_id` mới vào biến thể và thêm biến thể
                    variant.product_id = product.product_id;
                    context.ProductVariants.InsertOnSubmit(variant);
                    context.SubmitChanges();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Error adding product with variant: {ex.Message}");
                    return false;
                }
            }
        }

        // Cập nhật sản phẩm
        public bool UpdateProduct(Product product)
        {
            try
            {
                var existingProduct = context.Products.SingleOrDefault(p => p.product_id == product.product_id);
                if (existingProduct != null)
                {
                    existingProduct.product_name = product.product_name;
                    existingProduct.Title = product.Title;
                    existingProduct.price = product.price;
                    existingProduct.category_id = product.category_id;
                    existingProduct.Dateadd = product.Dateadd;
                    existingProduct.ImageSP = product.ImageSP;

                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product: {ex.Message}");
                return false;
            }
        }

        // Xóa sản phẩm và biến thể
        public bool DeleteProductWithVariants(int productId)
        {
            try
            {
                // Xóa biến thể sản phẩm
                var productVariants = context.ProductVariants.Where(pv => pv.product_id == productId).ToList();
                if (productVariants.Any())
                {
                    context.ProductVariants.DeleteAllOnSubmit(productVariants);
                }

                // Xóa sản phẩm
                var product = context.Products.SingleOrDefault(p => p.product_id == productId);
                if (product != null)
                {
                    context.Products.DeleteOnSubmit(product);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting product: {ex.Message}");
                return false;
            }
        }

        // Kiểm tra phụ thuộc
        public bool HasDependencies(int productId)
        {
            return context.Feedbacks.Any(fb => fb.product_id == productId) ||
                   context.ProductVariants.Any(pv => pv.product_id == productId &&
                   context.OrderDetails.Any(od => od.variant_id == pv.variant_id));
        }
        public int GetStockByProductId(int productId)
        {
            try
            {
                // Lấy tổng số lượng tồn kho từ ProductVariant
                var totalStock = context.ProductVariants
                    .Where(pv => pv.product_id == productId)
                    .Sum(pv => (int?)pv.quantity) ?? 0;

                return totalStock;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy tồn kho: {ex.Message}");
                throw;
            }
        }
        public int AddProductAndGetId(Product product)
        {
            try
            {
                context.Products.InsertOnSubmit(product);
                context.SubmitChanges();
                return product.product_id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product: {ex.Message}");
                throw;
            }
        }

        public int UpdateProductAndGetId(Product product)
        {
            try
            {
                var existingProduct = context.Products.SingleOrDefault(p => p.product_id == product.product_id);
                if (existingProduct != null)
                {
                    existingProduct.product_name = product.product_name;
                    existingProduct.Title = product.Title;
                    existingProduct.price = product.price;
                    existingProduct.category_id = product.category_id;
                    existingProduct.Dateadd = product.Dateadd;
                    existingProduct.ImageSP = product.ImageSP;

                    context.SubmitChanges();
                    return existingProduct.product_id; // Trả về `product_id` được cập nhật
                }
                return 0; // Trả về 0 nếu không tìm thấy sản phẩm
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật sản phẩm: {ex.Message}");
                return 0; // Trả về 0 nếu có lỗi
            }
        }
    }
}
