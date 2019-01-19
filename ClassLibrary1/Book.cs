public class Book // Katalog
{
    public int BookId { get; private set; }
    public int AuthorId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public Book(int bookId, int authorId, string title, string description)
    {
        BookId = bookId;
        AuthorId = authorId;
        Title = title;
        Description = description;
    }

    public override string ToString() {
        return "Book: " + Title + ", description: " + Description + ", author id: " + AuthorId;
    }

}