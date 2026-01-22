using System.ComponentModel.DataAnnotations;
using UsersAPI.Validations;

namespace UsersAPI.Entitys
{
    public class User
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(50, MinimumLength = 3)]
        [FirstLetterUpper]
        public required string Username { get; set; }

        public List<Posts> Posts { get; set; } = new List<Posts>();


    }
}
