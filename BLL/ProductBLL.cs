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
        private readonly OrderDetailsDAL orderDetailsDAL = new OrderDetailsDAL();
        private readonly CategoryDAL categoryDAL = new CategoryDAL();
        private readonly SizeDAL sizeDAL = new SizeDAL();
        private readonly ColorDAL colorDAL = new ColorDAL();

        public List<Product> GetAllProducts()
        {
            return productDAL.GetAllProducts();
        }

        //public List<dynamic> SearchProducts(string searchText)
        //{
        //    var products = GetProductDetails();

        //    if (!string.IsNullOrWhiteSpace(searchText))
        //    {
        //        string lowerSearchText = searchText.ToLower();

        //        products = products.Where(p =>
        //            p.product_name.ToLower().Contains(lowerSearchText) ||
        //            p.Title.ToLower().Contains(lowerSearchText) ||
        //            p.CategoryName.ToLower().Contains(lowerSearchText)).ToList();
        //    }

        //    return products;
        //}
        //public List<object> SearchProducts(string searchText)
        //{
        //    var products = GetProductDetails();

        //    if (!string.IsNullOrWhiteSpace(searchText))
        //    {
        //        string lowerSearchText = searchText.ToLower();

        //        products = products
        //            .Where(p =>
        //            {
        //                var product = (dynamic)p; // Ép kiểu object về dynamic tạm thời để truy cập thuộc tính
        //                return product.ProductName.ToLower().Contains(lowerSearchText) ||
        //                       product.Title.ToLower().Contains(lowerSearchText) ||
        //                       product.CategoryName.ToLower().Contains(lowerSearchText);
        //            })
        //            .ToList();
        //    }

        //    return products;
        //}
        public List<ProductDetailDTO> SearchProducts(string searchText)
        {
            var products = GetProductDetails();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                string lowerSearchText = searchText.ToLower();
                products = products.Where(p =>
                    p.ProductName.ToLower().Contains(lowerSearchText) ||
                    p.Title.ToLower().Contains(lowerSearchText) ||
                    p.CategoryName.ToLower().Contains(lowerSearchText)
                ).ToList();
            }
            return products;
        }

        //public List<dynamic> SortProductsByPriceAscending()
        //{
        //    var products = GetProductDetails();
        //    return products.OrderBy(p => p.price).ToList();
        //}

        //public List<dynamic> SortProductsByPriceDescending()
        //{
        //    var products = GetProductDetails();
        //    return products.OrderByDescending(p => p.price).ToList();
        //}
        //public List<object> SortProductsByPriceAscending()
        //{
        //    var products = GetProductDetails();
        //    return products.OrderBy(p => ((dynamic)p).Price).ToList();
        //}

        //public List<object> SortProductsByPriceDescending()
        //{
        //    var products = GetProductDetails();
        //    return products.OrderByDescending(p => ((dynamic)p).Price).ToList();
        //}


        public List<ProductDetailDTO> SortProductsByPriceAscending()
        {
            var products = GetProductDetails();
            return products.OrderBy(p => p.Price).ToList();
        }

        public List<ProductDetailDTO> SortProductsByPriceDescending()
        {
            var products = GetProductDetails();
            return products.OrderByDescending(p => p.Price).ToList();
        }
        //public List<dynamic> FilterProductsByCategory(int categoryId)
        //{
        //    var products = GetProductDetails();

        //    if (categoryId > 0)
        //    {
        //        products = products.Where(p => p.category_id == categoryId).ToList();
        //    }

        //    return products;
        //}
        //public List<object> FilterProductsByCategory(int categoryId)
        //{
        //    var products = GetProductDetails();

        //    if (categoryId > 0)
        //    {
        //        products = products
        //            .Where(p => ((dynamic)p).CategoryId == categoryId)
        //            .ToList();
        //    }

        //    return products;
        //}

        public List<ProductDetailDTO> FilterProductsByCategory(int categoryId)
        {
            var products = GetProductDetails();

            if (categoryId > 0)
            {
                products = products
                    .Where(p => p.CategoryId == categoryId)
                    .ToList();
            }

            return products;
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
            // Kiểm tra phụ thuộc
            if (productDAL.HasDependencies(productId))
            {
                Console.WriteLine("Không thể xóa sản phẩm vì nó đang được sử dụng trong các bảng liên quan.");
                return false;
            }

            // Xóa Product và các ProductVariant liên quan
            return productDAL.DeleteProduct(productId);
        }
        //public List<dynamic> GetProductDetails()
        //{
        //    var products = from p in productDAL.GetAllProducts()
        //                   join pv in productVariantDAL.GetAllProductVariants() on p.product_id equals pv.product_id
        //                   join c in colorDAL.GetAllColors() on pv.color_id equals c.color_id
        //                   join s in sizeDAL.GetAllSizes() on pv.size_id equals s.size_id
        //                   join cat in categoryDAL.GetAllCategories() on p.category_id equals cat.category_id
        //                   select new
        //                   {
        //                       p.product_id,
        //                       p.product_name,
        //                       p.Title,
        //                       p.price,
        //                       p.Dateadd,
        //                       p.rating,
        //                       p.ImageSP,
        //                       CategoryName = cat.category_name,
        //                       ColorName = c.color_name,
        //                       SizeName = s.size_name,
        //                       pv.quantity
        //                   };
        //    return products.ToList<dynamic>();
        //}


        public List<ProductDetailDTO> GetProductDetails()
        {
            var products = from p in productDAL.GetAllProducts()
                           join pv in productVariantDAL.GetAllProductVariants() on p.product_id equals pv.product_id
                           join c in colorDAL.GetAllColors() on pv.color_id equals c.color_id
                           join s in sizeDAL.GetAllSizes() on pv.size_id equals s.size_id
                           join cat in categoryDAL.GetAllCategories() on p.category_id equals cat.category_id
                           select new ProductDetailDTO
                           {
                               ProductId = p.product_id,
                               ProductName = p.product_name,
                               Title = p.Title,
                               Price = p.price ?? 0.0,
                               DateAdd = p.Dateadd ?? DateTime.MinValue,
                               Rating = (float)(p.rating ?? 0.0),
                               ImageSP = p.ImageSP,
                               CategoryName = cat.category_name,
                               ColorName = c.color_name,
                               SizeName = s.size_name,
                               Quantity = pv.quantity ?? 0,
                               CategoryId = p.category_id ?? 0
                           };
            return products.ToList();
        }

        //public List<object> GetProductDetails()
        //{
        //    var products = from p in productDAL.GetAllProducts()
        //                   join pv in productVariantDAL.GetAllProductVariants() on p.product_id equals pv.product_id
        //                   join c in colorDAL.GetAllColors() on pv.color_id equals c.color_id
        //                   join s in sizeDAL.GetAllSizes() on pv.size_id equals s.size_id
        //                   join cat in categoryDAL.GetAllCategories() on p.category_id equals cat.category_id
        //                   select new
        //                   {
        //                       p.product_id,
        //                       p.product_name,
        //                       p.Title,
        //                       p.price,
        //                       p.Dateadd,
        //                       p.rating,
        //                       p.ImageSP,
        //                       CategoryName = cat.category_name,
        //                       ColorName = c.color_name,
        //                       SizeName = s.size_name,
        //                       pv.quantity,
        //                       p.category_id // Thêm cột category_id
        //                   };
        //    return products.ToList<object>();
        //}

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

        // Phương thức kiểm tra phụ thuộc cho sản phẩm
        public bool HasDependencies(int productId)
        {
            return productDAL.HasDependencies(productId);
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

        // Tính tồn kho của sản phẩm dựa vào product_id
        public List<dynamic> GetStockByProductId(int productId)
        {
            var productVariants = productVariantDAL.GetVariantsByProductId(productId);

            foreach (var variant in productVariants)
            {
                Console.WriteLine($"VariantId: {variant.variant_id}, Quantity: {variant.quantity}");
            }

            var stockData = productVariants.Select(variant =>
            {
                int totalSold = orderDetailsDAL.GetTotalSoldByVariantId(variant.variant_id);
                Console.WriteLine($"VariantId: {variant.variant_id}, TotalSold: {totalSold}");

                int quantity = variant.quantity ?? 0;

                var remainingStock = quantity - totalSold;
                Console.WriteLine($"RemainingStock for VariantId {variant.variant_id}: {remainingStock}");

                return new
                {
                    ProductId = productId,
                    VariantId = variant.variant_id,
                    TotalStock = remainingStock
                };
            }).ToList<dynamic>();

            return stockData;
        }
    }
}
