using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DoAnThietKeWeb1.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly GorocoDatabaseContext _context;
        private readonly IFavoriteProducts favoriteProducts;

        public FavoriteController(GorocoDatabaseContext context, IFavoriteProducts favoriteProducts)
        {
            _context = context;
            this.favoriteProducts = favoriteProducts;
        }

        public IActionResult FavoriteIndex()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return RedirectToAction("Login", "Account");
            var favoriteProductsList = favoriteProducts.GetFavoriteProducts(userId);
            ViewBag.ModelFavorites = favoriteProductsList.Select(p => p.ProductId).ToList();
            return View(favoriteProductsList);
        }

        [HttpPost]
        public IActionResult AddToFavorite([FromBody] FavoriteRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Json(new { redirectUrl = Url.Action("Login", "Account") });
            }

            if (string.IsNullOrEmpty(request.ProductId) || !_context.Products.Any(p => p.ProductId == request.ProductId))
            {
                return Json(new { success = false, message = "Sản phẩm không hợp lệ." });
            }

            var updatedFavorites = favoriteProducts.AddFavoriteProducts(userId, request.ProductId);
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult RemoveFromFavorite([FromBody] FavoriteRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Json(new { redirectUrl = Url.Action("Login", "Account") });
            }

            if (string.IsNullOrEmpty(request.ProductId))
            {
                return Json(new { success = false, message = "Sản phẩm không hợp lệ." });
            }

            var updatedFavorites = favoriteProducts.RemoveFavoriteProducts(userId, request.ProductId);
            return Json(new { success = true });
        }
    }

    public class FavoriteRequest
    {
        public string ProductId { get; set; }
    }
}