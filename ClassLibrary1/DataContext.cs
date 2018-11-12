using System.Collections.Generic;
using System.Collections.ObjectModel;

public class DataContext
{
    public List<Reader> Readers { get; private set; } // Wykaz - nie rozumiem dlaczego lista, a nie słownik tak jak w przypadku książek...
    public List<Author> Authors { get; private set; } // Dodatek od nas - lista j.w. żeby zachowadź spójność
    public Dictionary<int, Book> Books { get; private set; } // Katalog - książki w słowniku, int to ID
    public ObservableCollection<Copy> Copies { get; private set; } // Opisy Stanu - tu może być dowolna konstrukcja, wybrałem ObservableCollection
    public ObservableCollection<Event> Events { get; private set; } // Zadrzenia

    public DataContext()
    {
        Readers = new List<Reader>();
        Authors = new List<Author>();
        Books = new Dictionary<int, Book>();
        Copies = new ObservableCollection<Copy>();
        Events = new ObservableCollection<Event>();
    }
}