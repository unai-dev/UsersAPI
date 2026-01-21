using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Entitys
{
    public class User
    {

        public int Id { get; set; }

        [Required]
        public required string Username { get; set; }

        public List<Posts> Posts { get; set; } = new List<Posts>();


    }
}
