using DTO;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class ProductVariantDAL
    {
        private QuanLyShopDataContext db = new QuanLyShopDataContext();

        public List<ProductVariant> GetAllProductVariants()
        {
            return db.ProductVariants.ToList();
        }

        public ProductVariant GetProductVariantById(int id)
        {
            return db.ProductVariants.SingleOrDefault(v => v.variant_id == id);
        }

        public bool InsertProductVariant(ProductVariant productVariant)
        {
            return ExecuteDatabaseOperation(() =>
            {
                db.ProductVariants.InsertOnSubmit(productVariant);
                db.SubmitChanges();
            });
        }

        public bool UpdateProductVariant(ProductVariant productVariant)
        {
            return ExecuteDatabaseOperation(() =>
            {
                var existingVariant = db.ProductVariants.SingleOrDefault(v => v.variant_id == productVariant.variant_id);
                if (existingVariant != null)
                {
                    existingVariant.product_id = productVariant.product_id;
                    existingVariant.size_id = productVariant.size_id;
                    existingVariant.color_id = productVariant.color_id;
                    existingVariant.quantity = productVariant.quantity;
                    db.SubmitChanges();
                }
            });
        }

        public bool DeleteProductVariant(int id)
        {
            return ExecuteDatabaseOperation(() =>
            {
                var variant = db.ProductVariants.SingleOrDefault(v => v.variant_id == id);
                if (variant != null)
                {
                    db.ProductVariants.DeleteOnSubmit(variant);
                    db.SubmitChanges();
                }
            });
        }

        public bool RemoveProductVariantByProductId(int productId)
        {
            return ExecuteDatabaseOperation(() =>
            {
                var variants = db.ProductVariants.Where(v => v.product_id == productId).ToList();
                if (variants.Any())
                {
                    db.ProductVariants.DeleteAllOnSubmit(variants);
                    db.SubmitChanges();
                }
            });
        }

        // Helper method to handle common database operations
        private bool ExecuteDatabaseOperation(System.Action operation)
        {
            try
            {
                operation();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
