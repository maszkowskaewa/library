using System;

public class Copy // OpisStanu
{
    public int CopyId { get; private set; }
    public int BookId { get; private set; }
    public DateTime? ReleaseDate { get; set; } //znak zapytania mówi, ¿e w tej zmiennej mo¿e byæ NULL
    public DateTime BuyDate { get; private set; }

    public Copy(int copyId, int bookId, DateTime? releaseDate, DateTime buyDate)
    {
        CopyId = copyId;
        BookId = bookId;
        ReleaseDate = releaseDate;
        BuyDate = buyDate;            
    }

    public override string ToString()
    {
        return "Copy: " + BookId + ", ReleaseDate: " + ReleaseDate + ", BuyDate: " + BuyDate;
    }
}