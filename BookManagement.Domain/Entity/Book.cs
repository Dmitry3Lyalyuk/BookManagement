using BookManagement.Domain.Common;

namespace BookManagement.Domain.Entity
{
    public class Book : BaseAuditableEntity
    {
        public string title { get; set; }
        public int publicationYear { get; set; }
        public string authorName { get; set; }
        public int viewCount { get; set; }
    }
}
