using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class ProductVariantDAL
    {
        private readonly QuanLyShopDataContext db = new QuanLyShopDataContext();

        public List<ProductVariantDTO> GetVariantsByProductId(int productId)
        {
            return db.ProductVariants
                     .Where(v => v.product_id == productId)
                     .Select(v => new ProductVariantDTO
                     {
                         VariantId = v.variant_id,
                         ProductId = v.product_id ?? 0,
                         SizeId = v.size_id ?? 0,
                         ColorId = v.color_id ?? 0,
                         Quantity = v.quantity ?? 0,
                         SizeName = v.Size.size_name,
                         ColorName = v.Color.color_name
                     }).ToList();
        }
        public List<ProductVariant> GetAllProductVariants()
        {
            return db.ProductVariants.ToList();
        }
        public ProductVariant GetProductVariantById(int variantId)
        {
            return db.ProductVariants.SingleOrDefault(v => v.variant_id == variantId);
        }


        public bool UpdateProductVariant(ProductVariant productVariant)
        {
            try
            {
                var existingVariant = db.ProductVariants.SingleOrDefault(v => v.variant_id == productVariant.variant_id);
                if (existingVariant != null)
                {
                    existingVariant.size_id = productVariant.size_id;
                    existingVariant.color_id = productVariant.color_id;
                    existingVariant.quantity = productVariant.quantity;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product variant: {ex.Message}");
                return false;
            }
        }
        public bool AddProductVariant(ProductVariant variant)
        {
            try
            {
                // Thêm ProductVariant mới vào cơ sở dữ liệu
                db.ProductVariants.InsertOnSubmit(variant);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product variant: {ex.Message}");
                return false;
            }
        }

        public bool SaveProductVariant(ProductVariantDTO variant)
        {
            try
            {
                if (variant.VariantId == 0) // Thêm mới
                {
                    var newVariant = new ProductVariant
                    {
                        product_id = variant.ProductId,
                        size_id = GetSizeIdByName(variant.SizeName),
                        color_id = GetColorIdByName(variant.ColorName),
                        quantity = variant.Quantity
                    };

                    db.ProductVariants.InsertOnSubmit(newVariant);
                }
                else // Cập nhật
                {
                    var existingVariant = db.ProductVariants.FirstOrDefault(v => v.variant_id == variant.VariantId);
                    if (existingVariant == null) return false;

                    existingVariant.size_id = GetSizeIdByName(variant.SizeName);
                    existingVariant.color_id = GetColorIdByName(variant.ColorName);
                    existingVariant.quantity = variant.Quantity;
                }

                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu ProductVariant: {ex.Message}");
                return false;
            }
        }

        public bool DeleteProductVariant(int variantId)
        {
            try
            {
                var variant = db.ProductVariants.FirstOrDefault(v => v.variant_id == variantId);
                if (variant == null) return false;

                db.ProductVariants.DeleteOnSubmit(variant);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa ProductVariant: {ex.Message}");
                return false;
            }
        }

        public bool RemoveProductVariantByProductId(int productId)
        {
            try
            {
                var variants = db.ProductVariants.Where(v => v.product_id == productId).ToList();
                if (!variants.Any()) return true;

                db.ProductVariants.DeleteAllOnSubmit(variants);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa các biến thể theo ProductId: {ex.Message}");
                return false;
            }
        }

        public bool HasDependencies(int variantId)
        {
            return db.OrderDetails.Any(od => od.variant_id == variantId);
        }

        public int GetSizeIdByName(string sizeName)
        {
            return db.Sizes.FirstOrDefault(s => s.size_name == sizeName)?.size_id ?? 0;
        }

        public int GetColorIdByName(string colorName)
        {
            return db.Colors.FirstOrDefault(c => c.color_name == colorName)?.color_id ?? 0;
        }
    }
}
