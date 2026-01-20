using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Entitys
{
    public class Group
    {

        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required int MaxMembers { get; set; }
    }
}
