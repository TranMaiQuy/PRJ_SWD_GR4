using Microsoft.AspNetCore.Mvc;
using PRJ_SWD.Business.Service.BlogService;
using PRJ_SWD.Application.DTO;


namespace PRJ_SWD.Controllers.BlogController
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly BlogService service;
        public BlogController(BlogService service)
        {
            this.service = service;
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            var list = service.GetAllBlog();
            return Ok(list);
        }

        [HttpGet("detail")]
        public IActionResult Detail(int id) {
            var blog = service.GetBlogById(id);
            return Ok(blog);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] BlogDto dto)
        {
            try
            {
               service.AddBlog(dto);
                return Ok(new { message = "Blog created successfully" });
            }
            catch (Exception ex)
            {
                // log nếu cần
                return StatusCode(500, new { error = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var blog = service.GetBlogById(id); // Hoặc từ _context
            if (blog == null) return NotFound();
            return Ok(blog);
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromForm] BlogDto dto) { 
            var existedBlog = service.UpdateBlog(id, dto);
            return Ok(existedBlog);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) { 
            service.DeleteBlog(id);
            return Ok(new { message = "Blog deleted successfully" });
        }
    }
}
