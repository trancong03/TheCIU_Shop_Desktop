using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class ProductVariantBLL
    {
        private ProductVariantDAL productVariantDAL = new ProductVariantDAL();

        public List<ProductVariant> GetAllProductVariants()
        {
            return productVariantDAL.GetAllProductVariants();
        }

        public ProductVariant GetProductVariantById(int id)
        {
            return productVariantDAL.GetProductVariantById(id);
        }

        public bool AddProductVariant(ProductVariant productVariant)
        {
            ValidateField(productVariant.product_id > 0, "Sản phẩm không hợp lệ.");
            ValidateField(productVariant.color_id > 0, "Màu sắc không hợp lệ.");
            ValidateField(productVariant.size_id > 0, "Kích cỡ không hợp lệ.");
            ValidateField(productVariant.quantity >= 0, "Số lượng không hợp lệ.");
            return productVariantDAL.InsertProductVariant(productVariant);
        }

        public bool EditProductVariant(ProductVariant productVariant)
        {
            ValidateField(productVariant.product_id > 0, "Sản phẩm không hợp lệ.");
            ValidateField(productVariant.color_id > 0, "Màu sắc không hợp lệ.");
            ValidateField(productVariant.size_id > 0, "Kích cỡ không hợp lệ.");
            ValidateField(productVariant.quantity >= 0, "Số lượng không hợp lệ.");
            return productVariantDAL.UpdateProductVariant(productVariant);
        }
        public bool HasDependencies(int variantId)
        {
            return productVariantDAL.HasDependencies(variantId);
        }
        public bool RemoveProductVariant(int id)
        {
            return productVariantDAL.DeleteProductVariant(id);
        }

        private void ValidateField(bool isValid, string errorMessage)
        {
            if (!isValid)
                throw new Exception(errorMessage);
        }
    }
}
