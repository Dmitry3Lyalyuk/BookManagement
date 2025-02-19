namespace BookManagement.Application.Books.Queries
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string AuthorName { get; set; }
        public int ViewCount { get; set; }

    }
}
