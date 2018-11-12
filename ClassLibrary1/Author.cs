public class Author : Person
{
    public string Description { get; private set; }

    public Author(int id, string name, string surname, string description) : base(id, name, surname)
    {
        Description = description;
    }
}