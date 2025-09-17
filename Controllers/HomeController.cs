using System.Diagnostics;
using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models;
using DoAnThietKeWeb1.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoAnThietKeWeb1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly ILogger<HomeController> _logger;
        private readonly GorocoDatabaseContext _context;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, GorocoDatabaseContext context, IHomeRepository homeRepository, ICartRepository cartRepository)
        {
            _logger = logger;
            _context = context;
            _homeRepository = homeRepository;
            _cartRepository = cartRepository;
        }
        public IActionResult HomeIndex()
        {
            var trendingProducts = _homeRepository.GetTrendingProducts();
            return View(trendingProducts);
        }
    }
}
