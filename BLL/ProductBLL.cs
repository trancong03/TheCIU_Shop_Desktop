using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DTO;
using Validation;

namespace BLL
{
    public class ProductBLL
    {
        private readonly ProductDAL productDAL = new ProductDAL();
        private readonly ProductValidation productValidation = new ProductValidation();
        private readonly ProductVariantDAL productVariantDAL = new ProductVariantDAL(); 
        private readonly CategoryDAL categoryDAL = new CategoryDAL();
        private readonly SizeDAL sizeDAL = new SizeDAL();
        private readonly ColorDAL colorDAL = new ColorDAL();

        public List<Product> GetAllProducts()
        {
            return productDAL.GetAllProducts();
        }
        public List<dynamic> SearchProducts(string searchText)
        {
            var products = GetProductDetails();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                string lowerSearchText = searchText.ToLower();

                // LINQ to SQL hỗ trợ ToLower và Contains
                products = products.Where(p =>
                    p.product_name.ToLower().Contains(lowerSearchText) ||
                    p.Title.ToLower().Contains(lowerSearchText) ||
                    p.CategoryName.ToLower().Contains(lowerSearchText)).ToList();
            }

            return products;
        }



        public List<dynamic> FilterProductsByCategory(int categoryId)
        {
            var products = GetProductDetails();

            if (categoryId > 0)
            {
                products = products.Where(p => p.category_id == categoryId).ToList();
            }

            return products;
        }
        public List<dynamic> GetProductDetails()
        {
            var products = from p in productDAL.GetAllProducts()
                           join pv in productVariantDAL.GetAllProductVariants() on p.product_id equals pv.product_id
                           join c in colorDAL.GetAllColors() on pv.color_id equals c.color_id
                           join s in sizeDAL.GetAllSizes() on pv.size_id equals s.size_id
                           join cat in categoryDAL.GetAllCategories() on p.category_id equals cat.category_id
                           select new
                           {
                               p.product_id,
                               p.product_name,
                               p.Title,
                               p.price,
                               p.Dateadd,
                               p.rating,
                               CategoryName = cat.category_name,
                               ColorName = c.color_name,
                               SizeName = s.size_name,
                               pv.quantity
                           };
            return products.ToList<dynamic>();
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

        public List<ProductVariant> GetProductVariants()
        {
            return productVariantDAL.GetAllProductVariants();
        }

        public List<Category> GetAllCategories()
        {
            return categoryDAL.GetAllCategories();
        }

        public List<Size> GetAllSizes()
        {
            return sizeDAL.GetAllSizes();
        }

        public List<Color> GetAllColors()
        {
            return colorDAL.GetAllColors();
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
