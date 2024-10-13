using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductDAL
    {
        QuanLyShopDataContext db = new QuanLyShopDataContext();
        public ProductDAL(){ }
        public List<Product> GetAllProducts()
        {
            return db.Products.ToList();
        }

        // Get product by ID
        public Product GetProductById(int id)
        {
            return db.Products.SingleOrDefault(p => p.product_id == id);
        }

        public void InsertProduct(Product product)
        {
            db.Products.InsertOnSubmit(product);
            db.SubmitChanges();
        }
        public void UpdateProduct(Product product)
        {
            var existingProduct = db.Products.SingleOrDefault(p => p.product_id == product.product_id);
            if (existingProduct != null)
            {
                existingProduct.product_name = product.product_name;
                existingProduct.price = product.price;
                db.SubmitChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            var product = db.Products.SingleOrDefault(p => p.product_id == id);
            if (product != null)
            {
                db.Products.DeleteOnSubmit(product);
                db.SubmitChanges();
            }
        }
    }
}
