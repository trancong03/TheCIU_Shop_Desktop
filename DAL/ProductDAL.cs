using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class ProductDAL
    {
        private QuanLyShopDataContext db;

        public ProductDAL()
        {
            db = new QuanLyShopDataContext();
        }

        // Lấy tất cả sản phẩm
        public List<Product> GetAllProducts()
        {
            return db.Products.ToList();
        }

        // Lấy sản phẩm theo tên
        public Product GetProductByName(string productName)
        {
            return db.Products.FirstOrDefault(p => p.product_name == productName);
        }

        // Thêm sản phẩm
        public void AddProduct(Product product)
        {
            db.Products.InsertOnSubmit(product);
            db.SubmitChanges();
        }

        // Sửa sản phẩm
        public void UpdateProduct(Product product)
        {
            Product existingProduct = db.Products.FirstOrDefault(p => p.product_id == product.product_id);
            if (existingProduct != null)
            {
                existingProduct.product_name = product.product_name;
                existingProduct.price = product.price;
                existingProduct.category_id = product.category_id;
                existingProduct.Title = product.Title;

                db.SubmitChanges();
            }
        }

        // Xóa sản phẩm và reset lại product_id
        public void DeleteProduct(int productId)
        {
            Product product = db.Products.FirstOrDefault(p => p.product_id == productId);
            if (product != null)
            {
                db.Products.DeleteOnSubmit(product);
                db.SubmitChanges();
                ResetProductIds();
            }
        }

        // Reset lại các product_id để không có khoảng trống
        private void ResetProductIds()
        {
            var products = db.Products.OrderBy(p => p.product_id).ToList();
            int newId = 1;
            foreach (var product in products)
            {
                product.product_id = newId;
                newId++;
            }
            db.SubmitChanges();
        }
    }
}
