namespace BookManagement.Application.Books.Commands.CreateBulk
{
    public class CreateBookDTO
    {
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string AuthorName { get; set; }
    }
}
