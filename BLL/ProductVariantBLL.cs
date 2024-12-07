using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DAL;
using DTO;

namespace BLL
{
    public class ProductVariantBLL
    {
        private readonly ProductVariantDAL productVariantDAL = new ProductVariantDAL();

        public List<ProductVariantDTO> GetVariantsByProductId(int productId)
        {
            return productVariantDAL.GetVariantsByProductId(productId);
        }

        public bool AddProductVariant(ProductVariantDTO variant)
        {
            ValidateVariant(variant);
            return productVariantDAL.SaveProductVariant(variant);
        }
        public bool AddProductVariant(ProductVariant productVariant)
        {
            ValidateField(productVariant.product_id > 0, "Sản phẩm không hợp lệ.");
            ValidateField(productVariant.color_id > 0, "Màu sắc không hợp lệ.");
            ValidateField(productVariant.size_id > 0, "Kích cỡ không hợp lệ.");
            ValidateField(productVariant.quantity >= 0, "Số lượng không hợp lệ.");
            return productVariantDAL.AddProductVariant(productVariant); // Gọi đúng phương thức DAL
        }


        public bool EditProductVariant(ProductVariantDTO variant)
        {
            ValidateVariant(variant);
            return productVariantDAL.SaveProductVariant(variant);
        }

        public bool RemoveProductVariant(int variantId)
        {
            if (productVariantDAL.HasDependencies(variantId))
            {
                throw new Exception("Không thể xóa biến thể vì có phụ thuộc.");
            }

            return productVariantDAL.DeleteProductVariant(variantId);
        }

        public bool RemoveProductVariantsByProductId(int productId)
        {
            return productVariantDAL.RemoveProductVariantByProductId(productId);
        }

        public void ConfigureProductVariantGrid(DataGridView grid)
        {
            if (grid.Columns["VariantId"] != null) grid.Columns["VariantId"].Visible = false;
            if (grid.Columns["ProductId"] != null) grid.Columns["ProductId"].Visible = false;
            if (grid.Columns["SizeId"] != null) grid.Columns["SizeId"].Visible = false;
            if (grid.Columns["ColorId"] != null) grid.Columns["ColorId"].Visible = false;

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.ReadOnly = false;
        }

        public void ClearProductVariantGrid(DataGridView grid)
        {
            grid.DataSource = null;
            grid.Rows.Clear();
        }

        private void ValidateVariant(ProductVariantDTO variant)
        {
            ValidateField(!string.IsNullOrEmpty(variant.SizeName), "Kích cỡ không hợp lệ.");
            ValidateField(!string.IsNullOrEmpty(variant.ColorName), "Màu sắc không hợp lệ.");
            ValidateField(variant.Quantity > 0, "Số lượng phải lớn hơn 0.");
        }

        private void ValidateField(bool isValid, string errorMessage)
        {
            if (!isValid) throw new Exception(errorMessage);
        }
        public bool SaveProductVariant(ProductVariantDTO variant)
        {
            if (variant.VariantId == 0)
            {
                // Thêm mới
                return productVariantDAL.AddProductVariant(new ProductVariant
                {
                    product_id = variant.ProductId,
                    size_id = productVariantDAL.GetSizeIdByName(variant.SizeName),
                    color_id = productVariantDAL.GetColorIdByName(variant.ColorName),
                    quantity = variant.Quantity
                });
            }
            else
            {
                // Cập nhật
                return productVariantDAL.UpdateProductVariant(new ProductVariant
                {
                    variant_id = variant.VariantId,
                    product_id = variant.ProductId,
                    size_id = productVariantDAL.GetSizeIdByName(variant.SizeName),
                    color_id = productVariantDAL.GetColorIdByName(variant.ColorName),
                    quantity = variant.Quantity
                });
            }
        }

    }
}
