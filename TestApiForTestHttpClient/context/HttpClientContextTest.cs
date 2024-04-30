using Microsoft.EntityFrameworkCore;
using TestApiForTestHttpClient.Domains;

namespace TestApiForTestHttpClient.context
{
    public class HttpClientContextTest:DbContext
    {
        public HttpClientContextTest(DbContextOptions<HttpClientContextTest> options):base(options) { }
        public DbSet<Post> posts { get; set; }  
}
}
