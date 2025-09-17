using DoAnThietKeWeb1.Models;
using DoAnThietKeWeb1.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoAnThietKeWeb1.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public IActionResult ContactIndex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendContact(IFormCollection form)
        {
            var message = new ContactMessage
            {
                Name = form["Name"],
                Email = form["Email"],
                Phone = form["Phone"],
                Subject = form["Subject"],
                Message = form["Message"],
                SentAt = DateTime.Now,
                IsRead = false
            };

            _contactRepository.Add(message);
            _contactRepository.SaveChanges();

            return RedirectToAction("HomeIndex", "Home");
        }


    }
}
