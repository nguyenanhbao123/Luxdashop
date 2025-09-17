using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoAnThietKeWeb1.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository blogRepository;
        private readonly GorocoDatabaseContext gorocoDatabaseContext;
        public BlogController(IBlogRepository blogRepository, GorocoDatabaseContext gorocoDatabaseContext)
        {
            this.blogRepository = blogRepository;
            this.gorocoDatabaseContext = gorocoDatabaseContext;
        }
        public IActionResult BlogIndex()
        {
            var blogs = blogRepository.GetBlogs();
            return View(blogs);
        }
    }
}
