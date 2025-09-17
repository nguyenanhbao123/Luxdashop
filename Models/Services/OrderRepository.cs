using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoAnThietKeWeb1.Models.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GorocoDatabaseContext _context;

        public OrderRepository(GorocoDatabaseContext context)
        {
            _context = context;
        }
       
        public IEnumerable<Invoice> GetOrdersByUserId(string userId)
        {
            return _context.Invoices
                .Include(i => i.User)
                .Include(i => i.InvoiceDetails)
                    .ThenInclude(d => d.Product)
                .Where(i => i.UserId == userId)
                .OrderByDescending(i => i.CreatedDate)
                .ToList();
        }
        public IEnumerable<Invoice> GetAllInvoices()
        {
            return _context.Invoices
                .Include(i => i.User)
                .Include(i => i.InvoiceDetails)
                 .ThenInclude(d => d.Product)
                .OrderByDescending(i => i.CreatedDate)
                .ToList();
        }
        public IEnumerable<Invoice> GetPagedInvoices(string userId, int page, int pageSize)
        {
            return _context.Invoices
                .Include(i => i.User)
                .Include(i => i.InvoiceDetails)
                    .ThenInclude(d => d.Product)
                .Where(i => i.UserId == userId)
                .OrderByDescending(i => i.CreatedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int GetTotalInvoiceCount(string userId)
        {
            return _context.Invoices.Count(i => i.UserId == userId);
        }
        public bool CancelInvoice(string invoiceId)
        {
            var invoice = _context.Invoices.FirstOrDefault(i => i.InvoiceId == invoiceId);
            if (invoice != null)
            {
                invoice.Status = "Đã hủy";
                _context.SaveChanges();
                return true;
            }

            return false;
        }
        public IEnumerable<Invoice> GetAllInvoicesbyStatus(string userId, string status)
        {
            return _context.Invoices
                .Include(i => i.User)
                .Include(i => i.InvoiceDetails)
                    .ThenInclude(d => d.Product)
                .Where(i => i.UserId == userId && i.Status == status)
                .OrderByDescending(i => i.CreatedDate)
                .ToList();
        }

        public bool ConfirmInvoice(string invoiceId)
        {
            var invoice = _context.Invoices.FirstOrDefault(i => i.InvoiceId == invoiceId);
            if (invoice != null)
            {
                invoice.Status = "Đã xác nhận";
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
