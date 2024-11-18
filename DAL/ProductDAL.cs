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
                    existingProduct.price = product.price;
                    existingProduct.category_id = product.category_id;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // Xóa sản phẩm
        public bool DeleteProduct(int productId)
        {
            try
            {
                var product = context.Products.SingleOrDefault(p => p.product_id == productId);
                if (product != null)
                {
                    context.Products.DeleteOnSubmit(product);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
