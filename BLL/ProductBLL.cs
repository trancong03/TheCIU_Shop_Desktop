using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class ProductBLL
    {
        private ProductDAL productDAL = new ProductDAL();

        // Lấy tất cả sản phẩm
        public List<Product> GetAllProducts()
        {
            return productDAL.GetAllProducts();
        }

        // Lấy sản phẩm theo tên
        public Product GetProductByName(string productName)
        {
            return productDAL.GetProductByName(productName);
        }

        // Thêm sản phẩm
        public void AddProduct(Product product)
        {
            productDAL.AddProduct(product);
        }

        // Sửa sản phẩm
        public void EditProduct(Product product)
        {
            productDAL.UpdateProduct(product);
        }

        // Xóa sản phẩm
        public void RemoveProduct(int productId)
        {
            productDAL.DeleteProduct(productId);
        }
    }
}
