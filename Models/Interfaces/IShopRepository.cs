namespace DoAnThietKeWeb1.Models.Interfaces
{
    public interface IShopRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        IEnumerable<Product> SearchProducts(string searchQuery);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(string productId);
    }
}