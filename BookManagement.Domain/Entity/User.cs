using Microsoft.AspNetCore.Identity;

namespace BookManagement.Domain.Entity
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string UserName { get; set; }
        //[EmailAddress]
        //public string Email { get; set; }
    }
}
