using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;


namespace BLL
{
    public class ProductBLL
    {
        private ProductDAL productDAL = new ProductDAL();
        private ProductValidation productValidation = new ProductValidation();

        public List<Product> GetAllProducts()
        {
            return productDAL.GetAllProducts();
        }

        // Get product by ID
        public Product GetProductById(int id)
        {
            return productDAL.GetProductById(id);
        }

        // Add a new product
        public void AddProduct(Product product)
        {
            if (!productValidation.ValidateProductName(product.product_name))
                throw new Exception("Tên sản phẩm không hợp lệ.");

            if (!productValidation.ValidateProductPrice(product.price))
                throw new Exception("Giá sản phẩm không hợp lệ.");

            if (!productValidation.ValidateProductCategory(product.category_id))
                throw new Exception("Danh mục sản phẩm không hợp lệ.");

            productDAL.InsertProduct(product);
        }

        public void EditProduct(Product product)
        {
            if (!productValidation.ValidateProductName(product.product_name))
                throw new Exception("Tên sản phẩm không hợp lệ.");

            if (!productValidation.ValidateProductPrice(product.price))
                throw new Exception("Giá sản phẩm không hợp lệ.");

            if (!productValidation.ValidateProductCategory(product.category_id))
                throw new Exception("Danh mục sản phẩm không hợp lệ.");

            productDAL.UpdateProduct(product);
        }

        // Remove a product
        public void RemoveProduct(int id)
        {
            productDAL.DeleteProduct(id);
        }
    }

}
