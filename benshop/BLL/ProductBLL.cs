using System.Data;
using benshop.DAL;

namespace benshop.BLL
{
    public static class ProductBLL
    {
        public static DataTable GetCategories()
        {
            return ProductDAL.GetCategories();
        }

        public static DataTable GetAllProducts()
        {
            return ProductDAL.GetAllProducts();
        }

        public static bool IsProductNameExists(string name)
        {
            return ProductDAL.IsProductNameExists(name);
        }

        public static bool IsProductNameExistsExcludeId(string name, int excludeId)
        {
            return ProductDAL.IsProductNameExistsExcludeId(name, excludeId);
        }

        public static void AddProduct(string name, string category, decimal price, int stock)
        {
            ProductDAL.AddProduct(name, category, price, stock);
        }

        public static void UpdateProduct(int productId, string name, string category, decimal price, int stock)
        {
            ProductDAL.UpdateProduct(productId, name, category, price, stock);
        }

        public static void DeleteProduct(int productId)
        {
            ProductDAL.DeleteProduct(productId);
        }

    }
}
