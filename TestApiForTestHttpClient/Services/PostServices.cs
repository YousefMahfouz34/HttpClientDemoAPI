using Microsoft.EntityFrameworkCore;
using TestApiForTestHttpClient.context;
using TestApiForTestHttpClient.Domains;

namespace TestApiForTestHttpClient.Services
{
    public class PostServices : IPostServices
    {
        private readonly HttpClientContextTest _context;
        public PostServices(HttpClientContextTest context)
        {

            _context=context;
        }
        public async Task<Post> AddAsync(Post post)
        {
            var res= await _context.posts.AddAsync(post);
            _context.SaveChanges();
            return res.Entity;
            
        }

        public async Task<bool> AddRangeAsync(List<Post> posts)
        {
            var res =  _context.posts.AddRangeAsync(posts);
            _context.SaveChanges();
            return res != null ? true : false;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var res= await _context.posts.FirstOrDefaultAsync(p=>p.id==id);
          
                _context.posts.Remove(res);
                _context.SaveChanges();
            return res != null ? true : false;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            var res =  _context.posts.ToList();
            return res; 
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            var res = await _context.posts.FirstOrDefaultAsync(p => p.id == id);
            return res;

        }

        public async Task<bool> UpdateAsync(Post post)
        {
               var res=  _context.posts.Update(post);
            _context.SaveChanges();
            return res != null ? true : false;

        }
    }
}
