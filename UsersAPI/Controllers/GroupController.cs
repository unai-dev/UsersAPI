using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Data;
using UsersAPI.Entitys;

namespace UsersAPI.Controllers
{
    
    [ApiController]
    [Route("api/groups")]
    public class GroupController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public GroupController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Group>> Post(Group group)
        {
            context.Add(group);
            await context.SaveChangesAsync();
            return Created();
        }

        [HttpGet]
        public async Task<IEnumerable<Group>> Get()
        {
            return await context.Groups.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Group>> Get(int id)
        {
            var group = await context.Groups.FirstOrDefaultAsync(x => x.Id == id);

            if (group is null)
            {
                return NotFound($"Group with id {id} not found");
            }

            return group;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Group>> Put(int id, Group group)
        {
            if (id != group.Id)
            {
                return BadRequest("Id's not sames");
            }

            context.Update(group);

            await context.SaveChangesAsync();

            return Accepted();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var registerDeleted = await context.Groups.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (registerDeleted == 0)
            {
                return NotFound($"User with id {id} not found");
            }

            return NoContent();
        }

    }
}
