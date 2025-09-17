namespace DoAnThietKeWeb1.Models.Interfaces
{
    public interface IHomeRepository
    {
        IEnumerable<Product> GetTrendingProducts();
    }
}
