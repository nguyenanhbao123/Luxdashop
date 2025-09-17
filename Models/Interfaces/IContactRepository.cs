namespace DoAnThietKeWeb1.Models.Interfaces
{
    public interface IContactRepository
    {
        void Add(ContactMessage message);
        List<ContactMessage> GetLatest(int count = 5);
        int CountUnread();
        ContactMessage? GetById(int id);
        List<ContactMessage> GetAll();
        void MarkAsRead(int id);
        void Delete(int id);
        void SaveChanges();
    }
}
