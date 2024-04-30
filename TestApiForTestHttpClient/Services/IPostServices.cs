using TestApiForTestHttpClient.Domains;

namespace TestApiForTestHttpClient.Services
{
    public interface IPostServices
    {
        Task<List<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(int id);
        Task<Post> AddAsync(Post post);
        Task<bool> AddRangeAsync(List<Post> posts);

        Task<bool> UpdateAsync(Post post);
        Task<bool> DeleteAsync(int id);
    }
}
