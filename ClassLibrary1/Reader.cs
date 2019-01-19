using System;

public class Reader : Person, IEquatable<Reader>// Wykaz
{
    //TODO int za maly na PESEL
    public int Pesel { get; private set; }

    public Reader(int id, string name, string surname, int pesel) : base(id, name, surname)
    {
        Pesel = pesel;
    }

    public bool Equals(Reader other)
    {
        if (Pesel != other.Pesel)
            return false;
        if (Id != other.Id)
            return false;
        if (Name != other.Name)
            return false;
        if (Surname != other.Surname)
            return false;
        return true;
    }

    public override string ToString()
    {
        return $"Reader{{ {base.ToString()}, PESEL: {Pesel}}} ";
    }
}

