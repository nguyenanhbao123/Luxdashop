using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models;
using DoAnThietKeWeb1.Models.Interfaces;

namespace DoAnThietKeWeb1.Models.Services
{
    public class ShopRepository : IShopRepository
    {
        private readonly GorocoDatabaseContext _context;

        public ShopRepository(GorocoDatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _context.Products
                .Where(p => p.Category == category)
                .ToList();
        }

        public IEnumerable<Product> SearchProducts(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
                return GetAllProducts();

            searchQuery = searchQuery.ToLower();
            return _context.Products
                .Where(p => p.ProductName.ToLower().Contains(searchQuery) ||
                            (p.Description != null && p.Description.ToLower().Contains(searchQuery)))
                .ToList();
        }

        public void AddProduct(Product product)
        {
            if (string.IsNullOrEmpty(product.ProductId))
            {
                product.ProductId = "SP" + DateTime.Now.ToString("yyyyMMddHHmmss") + Guid.NewGuid().ToString("N")[..4];
            }

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            if (product.AverageRating == null)
            {
                product.AverageRating = _context.Products
                    .Where(p => p.ProductId == product.ProductId)
                    .Select(p => p.AverageRating)
                    .FirstOrDefault();
            }
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(string productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}