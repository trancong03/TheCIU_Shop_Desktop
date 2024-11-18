using System;
using System.Collections.Generic;
using DAL;
using DTO;
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

        public bool AddProduct(Product product)
        {
            ValidateProduct(product);
            return productDAL.AddProduct(product);
        }

        public bool EditProduct(Product product)
        {
            ValidateProduct(product);
            return productDAL.UpdateProduct(product);
        }

        public bool RemoveProduct(int productId)
        {
            return productDAL.DeleteProduct(productId);
        }

        private void ValidateProduct(Product product)
        {
            ValidateField(productValidation.ValidateProductName(product.product_name), "Tên sản phẩm không hợp lệ.");
            ValidateField(productValidation.ValidateProductPrice(product.price), "Giá sản phẩm không hợp lệ.");
            ValidateField(productValidation.ValidateProductCategory(product.category_id), "Danh mục sản phẩm không hợp lệ.");
        }

        private void ValidateField(ValidationResult validationResult, string errorMessage)
        {
            if (!validationResult.IsValid)
                throw new Exception(errorMessage);
        }
    }
}
