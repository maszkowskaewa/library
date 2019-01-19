using System;

public class Author : Person, IEquatable<Author>
{
    public string Description { get; set; }

    public Author(int id, string name, string surname, string description) : base(id, name, surname)
    {
        Description = description;
    }

    public bool Equals(Author other)
    {
        if (Description != other.Description)
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
        return "Author{ " + base.ToString() + ", Description: " + Description + " }";
    }
}