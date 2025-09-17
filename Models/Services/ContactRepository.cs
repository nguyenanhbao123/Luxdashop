using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models;
using DoAnThietKeWeb1.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoAnThietKeWeb1.Models.Services
{
    public class ContactRepository : IContactRepository
    {
        private readonly GorocoDatabaseContext _context;
        public ContactRepository(GorocoDatabaseContext context)
        {
            _context = context;
        }

        public void Add(ContactMessage message) => _context.ContactMessages.Add(message);

        public List<ContactMessage> GetLatest(int count = 5)
        {
            return _context.ContactMessages
                .OrderByDescending(m => m.SentAt)
                .Take(count)
                .ToList();
        }

        public int CountUnread() => _context.ContactMessages.Count(m => !m.IsRead);

        public ContactMessage? GetById(int id) => _context.ContactMessages.Find(id);

        public List<ContactMessage> GetAll()
        {
            return _context.ContactMessages
                .OrderByDescending(m => m.SentAt)
                .ToList();
        }

        public void MarkAsRead(int id)
        {
            var msg = _context.ContactMessages.Find(id);
            if (msg != null)
            {
                msg.IsRead = true;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var msg = _context.ContactMessages.Find(id);
            if (msg != null)
            {
                _context.ContactMessages.Remove(msg);
                _context.SaveChanges();
            }
        }

        public void SaveChanges() => _context.SaveChanges();
    }
}
