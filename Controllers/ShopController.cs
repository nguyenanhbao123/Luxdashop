using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoAnThietKeWeb1.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopRepository _shopRepository;
        private readonly GorocoDatabaseContext _context;
        public ShopController(IShopRepository shopRepository, GorocoDatabaseContext context)
        {
            _shopRepository = shopRepository;
            _context = context;
        }
        public IActionResult ShopIndex()
        {
            var products = _shopRepository.GetAllProducts();
            return View(products);
        }
        public IActionResult ShopCategory(string category)
        {
            var products = _shopRepository.GetProductsByCategory(category);
            return View("ShopIndex", products);
        }
        public IActionResult ShopSearch(string keyword)
        {
            var products = _shopRepository.SearchProducts(keyword);
            return View("ShopIndex", products);
        }

        public IActionResult ShopDetail(string id)
        {
            var product = _context.Products
             .FirstOrDefault(p => p.ProductId == id);

            if (product == null) return NotFound();

            return View(product);
        }
    }
}
