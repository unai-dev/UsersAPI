using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Data;
using UsersAPI.Entitys;

namespace UsersAPI.Controllers
{

    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PostController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Posts>> Post(Posts post)
        {

            var user = await context.Users.AnyAsync(x => x.Id == post.UserId);

            if (!user)
            {
                return NotFound($"User with id {post.UserId} not found");
            }

            context.Add(post);
            await context.SaveChangesAsync();
            return Created();

        }

        [HttpGet]
        public async Task<IEnumerable<Posts>> Get()
        {
            return await context.Posts.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Posts>> Get(int id)
        {
            var post = await context.Posts.FirstOrDefaultAsync(x => x.Id == id);

            if (post is null)
            {
                return NotFound($"Post with id {id} not found");
            }

            return post;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Posts>> Put(int id, Posts post)
        {
            if (id != post.Id)
            {
                return BadRequest("Id's not same");
            }

            var user = await context.Users.AnyAsync(x => x.Id == post.UserId);

            if (!user)
            {
                return NotFound($"User with id {post.UserId} not found");
            }

            context.Update(post);

            await context.SaveChangesAsync();

            return Accepted();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var registerDeleted = await context.Posts.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (registerDeleted == 0)
            {

                return NotFound($"Post with id {id} not found");
            }

            return NoContent();
        }

    }
}
