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
        private readonly SizeDAL sizeDAL = new SizeDAL();
        private readonly ColorDAL colorDAL = new ColorDAL();
        private readonly CategoryDAL categoryDAL = new CategoryDAL();

        public List<Product> GetAllProducts()
        {
            return productDAL.GetAllProducts();
        }

        public int UpdateProductAndGetId(ProductDetailDTO productDetail)
        {
            var product = new Product
            {
                product_id = productDetail.ProductId,
                product_name = productDetail.ProductName,
                Title = productDetail.Title,
                price = productDetail.Price,
                category_id = productDetail.CategoryId,
                Dateadd = productDetail.DateAdd,
                ImageSP = productDetail.ImageSP
            };

            return productDAL.UpdateProductAndGetId(product);
        }


        public int AddProductAndGetId(ProductDetailDTO productDetail)
        {
            var product = new Product
            {
                product_name = productDetail.ProductName,
                Title = productDetail.Title,
                price = productDetail.Price,
                category_id = productDetail.CategoryId,
                Dateadd = productDetail.DateAdd,
                ImageSP = productDetail.ImageSP
            };

            return productDAL.AddProductAndGetId(product);
        }


        // Lấy danh sách sản phẩm chi tiết
        public List<ProductDetailDTO> GetProductDetails()
        {
            return (from p in productDAL.GetAllProducts()
                    join pv in productVariantDAL.GetAllProductVariants() on p.product_id equals pv.product_id into pvGroup
                    from variant in pvGroup.DefaultIfEmpty()
                    join c in colorDAL.GetAllColors() on variant.color_id equals c.color_id into colorGroup
                    from color in colorGroup.DefaultIfEmpty()
                    join s in sizeDAL.GetAllSizes() on variant.size_id equals s.size_id into sizeGroup
                    from size in sizeGroup.DefaultIfEmpty()
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
                        ColorName = color?.color_name,
                        SizeName = size?.size_name,
                        Quantity = variant?.quantity ?? 0,
                        CategoryId = p.category_id ?? 0
                    }).ToList();
        }
        public List<ProductDetailDTO> GetBasicProductDetails()
        {
            return productDAL.GetBasicProductDetails();
        }

        // Thêm sản phẩm chi tiết
        public bool AddProduct(ProductDetailDTO productDetail)
        {
            // Xác thực dữ liệu
            ValidateProduct(productDetail);

            // Tạo đối tượng `Product`
            var product = new Product
            {
                product_name = productDetail.ProductName,
                Title = productDetail.Title,
                price = productDetail.Price,
                category_id = productDetail.CategoryId,
                Dateadd = productDetail.DateAdd,
                ImageSP = productDetail.ImageSP
            };

            // Tạo đối tượng `ProductVariant`
            var variant = new ProductVariant
            {
                size_id = sizeDAL.GetSizeIdByName(productDetail.SizeName),
                color_id = colorDAL.GetColorIdByName(productDetail.ColorName),
                quantity = productDetail.Quantity
            };

            // Thêm sản phẩm và biến thể
            return productDAL.AddProductWithVariant(product, variant);
        }

        // Cập nhật sản phẩm chi tiết
        public bool EditProduct(ProductDetailDTO productDetail)
        {
            // Xác thực dữ liệu
            ValidateProduct(productDetail);

            // Cập nhật sản phẩm
            var product = new Product
            {
                product_id = productDetail.ProductId,
                product_name = productDetail.ProductName,
                Title = productDetail.Title,
                price = productDetail.Price,
                category_id = productDetail.CategoryId,
                Dateadd = productDetail.DateAdd,
                ImageSP = productDetail.ImageSP
            };

            if (productDAL.UpdateProduct(product))
            {
                // Cập nhật biến thể sản phẩm
                var variant = productVariantDAL.GetProductVariantById(productDetail.ProductId);
                if (variant != null)
                {
                    variant.size_id = sizeDAL.GetSizeIdByName(productDetail.SizeName);
                    variant.color_id = colorDAL.GetColorIdByName(productDetail.ColorName);
                    variant.quantity = productDetail.Quantity;

                    return productVariantDAL.UpdateProductVariant(variant);
                }
            }
            return false;
        }

        // Xóa sản phẩm
        public bool RemoveProduct(int productId)
        {
            // Kiểm tra phụ thuộc
            if (productDAL.HasDependencies(productId))
            {
                Console.WriteLine("Không thể xóa sản phẩm vì nó đang được sử dụng trong các bảng liên quan.");
                return false;
            }

            // Xóa sản phẩm và biến thể
            return productDAL.DeleteProductWithVariants(productId);
        }

        // Tìm kiếm sản phẩm
        public List<ProductDetailDTO> SearchProducts(string searchText)
        {
            var products = GetProductDetails();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                string lowerSearchText = searchText.ToLower();
                products = products.Where(p =>
                    (!string.IsNullOrEmpty(p.ProductName) && p.ProductName.ToLower().Contains(lowerSearchText)) ||
                    (!string.IsNullOrEmpty(p.Title) && p.Title.ToLower().Contains(lowerSearchText)) ||
                    (!string.IsNullOrEmpty(p.CategoryName) && p.CategoryName.ToLower().Contains(lowerSearchText))
                ).ToList();
            }
            return products;
        }

        // Sắp xếp sản phẩm theo giá
      
        public List<ProductDetailDTO> SortProductsByPriceAscending()
        {
            return GetProductDetails().OrderBy(p => p.Price).ToList();
        }

        public List<ProductDetailDTO> SortProductsByPriceDescending()
        {
            return GetProductDetails().OrderByDescending(p => p.Price).ToList();
        }

        public int GetStockByProductId(int productId)
        {
            try
            {
                return productDAL.GetStockByProductId(productId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xử lý trong BLL: {ex.Message}");
                throw;
            }
        }

        public List<ProductDetailDTO> FilterProductsByPrice(float price)
        {
            return productDAL.FilterProductsByPrice(price);
        }
        // Xác thực sản phẩm
        private void ValidateProduct(ProductDetailDTO productDetail)
        {
            ValidateField(productValidation.ValidateProductName(productDetail.ProductName), "Tên sản phẩm không hợp lệ.");
            ValidateField(productValidation.ValidateProductPrice(productDetail.Price), "Giá sản phẩm không hợp lệ.");
            ValidateField(productValidation.ValidateProductCategory(productDetail.CategoryId), "Danh mục sản phẩm không hợp lệ.");
        }

        private void ValidateField(ValidationResult validationResult, string errorMessage)
        {
            if (!validationResult.IsValid)
                throw new Exception(errorMessage);
        }
    }
}
