using System;

public class Copy // OpisStanu
{
    public int BookId { get; private set; }
    public DateTime ReleaseDate { get; private set; }
    public DateTime BuyDate { get; private set; }

    public Copy(int bookId, DateTime releaseDate, DateTime buyDate)
    {
        BookId = bookId;
        ReleaseDate = releaseDate;
        BuyDate = buyDate;            
    }
}