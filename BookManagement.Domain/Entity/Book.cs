using BookManagement.Domain.Common;

namespace BookManagement.Domain.Entity
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string AuthorName { get; set; }
        public int ViewCount { get; set; }
    }
}
