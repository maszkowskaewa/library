public class Book // Katalog
{
    public int AuthorId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }

    public Book(int authorId, string title, string description)
    {
        AuthorId = authorId;
        Title = title;
        Description = description;
    }
}