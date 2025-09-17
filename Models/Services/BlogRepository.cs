using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models.Interfaces;

namespace DoAnThietKeWeb1.Models.Services
{
    public class BlogRepository: IBlogRepository
    {
        private readonly GorocoDatabaseContext _context;
            public BlogRepository(GorocoDatabaseContext context)
            {
                _context = context;
            }
    
            public IEnumerable<Blog> GetBlogs()
            {
                return _context.Blogs.ToList();
            }
    
            public Blog GetBlogById(string id)
            {
                return _context.Blogs.FirstOrDefault(b => b.BlogId == id);
            }
    
            public void AddBlog(Blog blog)
            {
                _context.Blogs.Add(blog);
                _context.SaveChanges();
            }
    
            public void UpdateBlog(Blog blog)
            {
                _context.Blogs.Update(blog);
                _context.SaveChanges();
            }
    
            public void DeleteBlog(string id)
            {
                var blog = GetBlogById(id);
                if (blog != null)
                {
                    _context.Blogs.Remove(blog);
                    _context.SaveChanges();
                }
            }
            
            public void SaveChanges()
            {
                _context.SaveChanges();
            }

        public IEnumerable<Blog> SearchBlogs(string searchTerm)
            {
                return _context.Blogs.Where(b => b.Title.Contains(searchTerm) || b.Content.Contains(searchTerm)).ToList();
            }
    }
}
