using System.ComponentModel.DataAnnotations;
using UsersAPI.Validations;

namespace UsersAPI.Entitys
{
    public class Group
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, MinimumLength = 10)]
        [FirstLetterUpper]
        public required string Name { get; set; }

        [Required]
        public required int MaxMembers { get; set; }
    }
}
