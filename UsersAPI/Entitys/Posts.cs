using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Entitys
{
    public class Posts
    {

        public int Id { get; set; }

        [Required]
        public required string Description { get; set; }
        public int UserId { get; set; }

        public User? User {get; set; }


    }
}
