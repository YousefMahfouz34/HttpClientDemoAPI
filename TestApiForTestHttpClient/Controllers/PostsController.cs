using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApiForTestHttpClient.Domains;
using TestApiForTestHttpClient.Services;

namespace TestApiForTestHttpClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostServices postServices;

        public PostsController(IPostServices postServices)
        {
            this.postServices = postServices;
        }


        [HttpGet]
        [Route("GetAllPosts")]

        public async Task<IActionResult> Get()
        {
            var res = await postServices.GetAllAsync();
            return Ok(res);
        }
        [HttpGet]
        [Route("GetPostById")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var res = await postServices.GetByIdAsync(id);
            return Ok(res);
        }
        [HttpPost]
        [Route("AddPost")]

        public async Task<IActionResult> Create(Post post)
        {
            try
            {
                await postServices.AddAsync(post);
                return Ok("Added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("Update")]

        public async Task<IActionResult> Update(Post post)
        {
            try
            {
                await postServices.UpdateAsync(post);
                return Ok("updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await postServices.DeleteAsync(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("AddRange")]

        public async Task<IActionResult> AddRange(List<Post> posts)
        {
            try
            {
                await postServices.AddRangeAsync(posts);
                return Ok("Added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
