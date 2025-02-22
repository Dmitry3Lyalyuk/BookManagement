using BookManagement.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Domain.Entity
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }

    }
}
