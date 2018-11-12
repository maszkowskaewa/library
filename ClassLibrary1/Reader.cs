public class Reader : Person // Wykaz
{
    public int Pesel { get; private set; }

    public Reader(int id, string name, string surname, int pesel) : base(id, name, surname)
    {
        Pesel = pesel
    }
}

