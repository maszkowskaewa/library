using System;

public class Event // Zdarzenie
{
    public int CopyId { get; private set; }
    public int ReaderId { get; private set; }
    public DateTime Date { get; private set; }
    public EventType Type { get; private set; }

    public Event(int copyId, int readerId, DateTime date, EventType type)
    {
        CopyId = copyId;
        ReaderId = readerId;
        Date = date;
        Type = type;
    }
    
    public enum EventType
    {
        Wypozyczenie, // Wypozyczenie
        Przedluzenie, // Przedluzenie
        Return // Zwrot
    }
}
