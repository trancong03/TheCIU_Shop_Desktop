using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class ProductDAL
    {
        private QuanLyShopDataContext context = new QuanLyShopDataContext();

        // Lấy tất cả sản phẩm
        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        // Thêm sản phẩm
        public bool AddProduct(Product product)
        {
            try
            {
                context.Products.InsertOnSubmit(product);
                context.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
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

                    // Chỉ cập nhật nếu có thay đổi
                    if (context.GetChangeSet().Updates.Count > 0)
                    {
                        context.SubmitChanges();
                    }

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật sản phẩm: {ex.Message}");
                return false;
            }
        }


        public bool DeleteProduct(int productId)
        {
            try
            {
                // Lấy danh sách ProductVariant liên quan đến Product
                var productVariants = context.ProductVariants.Where(pv => pv.product_id == productId).ToList();

                // Xóa tất cả ProductVariant liên quan
                if (productVariants.Any())
                {
                    context.ProductVariants.DeleteAllOnSubmit(productVariants);
                }

                // Xóa Product
                var product = context.Products.SingleOrDefault(p => p.product_id == productId);
                if (product != null)
                {
                    context.Products.DeleteOnSubmit(product);
                }

                // SubmitChanges để lưu thay đổi
                context.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting product: {ex.Message}");
                return false;
            }
        }



        public bool HasDependencies(int productId)
        {
            try
            {
                // Kiểm tra nếu Product tồn tại trong Feedback
                bool hasFeedback = context.Feedbacks.Any(fb => fb.product_id == productId);

                // Kiểm tra nếu Product tồn tại trong OrderDetails (thông qua ProductVariants)
                bool hasOrderDetails = context.ProductVariants
                    .Where(pv => pv.product_id == productId)
                    .Any(pv => context.OrderDetails.Any(od => od.variant_id == pv.variant_id));

                // Trả về true nếu tồn tại phụ thuộc
                return hasFeedback || hasOrderDetails;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking dependencies for product {productId}: {ex.Message}");
                return true; // Giả định có phụ thuộc nếu xảy ra lỗi
            }
        }



    }
}
