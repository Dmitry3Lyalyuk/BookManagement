using System.ComponentModel.DataAnnotations;

namespace BookManagement.Application.Users.Queries
{
    public class UserDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
