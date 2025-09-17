using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoAnThietKeWeb1.Models.Services
{
    public class FavoriteProducts : IFavoriteProducts
    {
        private readonly GorocoDatabaseContext _context;

        public FavoriteProducts(GorocoDatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetFavoriteProducts(string userId)
        {
            return _context.Favorites
                .Where(fp => fp.UserId == userId)
                .Select(fp => fp.Product)
                .ToList();
        }

        public IEnumerable<Product> AddFavoriteProducts(string userId, string productId)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(productId))
                throw new ArgumentException("UserId hoặc ProductId không hợp lệ.");

            if (!_context.Products.Any(p => p.ProductId == productId))
                throw new ArgumentException("Sản phẩm không tồn tại.");

            if (_context.Favorites.Any(fp => fp.UserId == userId && fp.ProductId == productId))
                return GetFavoriteProducts(userId); // Tránh thêm trùng lặp

            var favorite = new Favorite
            {
                FavoriteId = "YT" + DateTime.Now.ToString("yyyyMMddHHmmss") + Guid.NewGuid().ToString("N").Substring(0, 4),
                UserId = userId,
                ProductId = productId
            };

            try
            {
                _context.Favorites.Add(favorite);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm sản phẩm vào danh sách yêu thích: " + ex.Message);
            }

            return GetFavoriteProducts(userId);
        }

        public IEnumerable<Product> RemoveFavoriteProducts(string userId, string productId)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(productId))
                throw new ArgumentException("UserId hoặc ProductId không hợp lệ.");

            var favorite = _context.Favorites
                .FirstOrDefault(fp => fp.UserId == userId && fp.ProductId == productId);

            if (favorite != null)
            {
                try
                {
                    _context.Favorites.Remove(favorite);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi xóa sản phẩm khỏi danh sách yêu thích: " + ex.Message);
                }
            }

            return GetFavoriteProducts(userId);
        }
    }
}