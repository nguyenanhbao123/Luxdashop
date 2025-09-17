using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models;
using DoAnThietKeWeb1.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoAnThietKeWeb1.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutRepository aboutRepository;
        private readonly GorocoDatabaseContext gorocoDatabaseContext;
        public AboutController(IAboutRepository aboutRepository, GorocoDatabaseContext gorocoDatabaseContext)
        {
            this.aboutRepository = aboutRepository;
            this.gorocoDatabaseContext = gorocoDatabaseContext;
        }

        public IActionResult AboutIndex()
        {
            var galleries = aboutRepository.GetGallery();
            return View(galleries);
        }
    }
}
