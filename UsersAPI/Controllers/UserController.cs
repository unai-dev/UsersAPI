using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Data;
using UsersAPI.Entitys;

namespace UsersAPI.Controllers
{

    [ApiController]
    [Route("api/users")]
    public class UserController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public UserController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            context.Add(user);
            await context.SaveChangesAsync();
            return Created();
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await context.Users.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user is null)
            {
                return NotFound($"User with id {id} not found");
            }

            return user;
        }

        

    }
}
