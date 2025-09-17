namespace DoAnThietKeWeb1.Models.Interfaces
{
    public interface IFavoriteProducts
    {
        IEnumerable<Product> GetFavoriteProducts(string userId);
        IEnumerable<Product> AddFavoriteProducts(string userId, string productId);
        IEnumerable<Product> RemoveFavoriteProducts(string userId, string productId);
    }
}
