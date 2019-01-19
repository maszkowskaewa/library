using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using static Event;

internal class DataRepository
{
    private DataContext DataContext { get; set; }
    

    public DataRepository(IFillWithDefaultValues externalConstructor)
    // wstrzykiwanie zale¿noœci, w konstruktorze przekazywany jest obiekt, który implementuje interfejs IFillWithDefaultValues, czyli np smallCollection
    //wstrzykiwanie danych za pomoc¹ konstruktora, który zosta³ tu wykorzystany
    //dziêki temu, ¿e w parametrze jest interfejs mo¿na zaimplementowaæ kilka klas, które dziedzicz¹ interfejs
    {
        DataContext = new DataContext();

        DataContext.Authors = externalConstructor.GenerateAuthorCollection();
        DataContext.Readers = externalConstructor.GenerateReaderCollection();
        DataContext.Books = externalConstructor.GenerateBookCollection();
        DataContext.Copies = externalConstructor.GenerateCopyCollection();
        DataContext.Events = externalConstructor.GenerateEventCollection();

        DataContext.Copies.CollectionChanged += repo_CollectionChanged; 
        DataContext.Events.CollectionChanged += repo_CollectionChanged;
        // przy zmianie (dodaj, usuñ) obiektu typu ObservableCollection wywo³ywane jest metoda Copies.CollectionChanged i wszytsko co siê znajduje pod ni¹, czyli repo_CollectionChanged
    }

    public DataRepository()
    {
        DataContext = new DataContext();
    }

    public bool AddBook(Book book) {

        if (!DataContext.Books.ContainsKey(book.BookId))
        {
            DataContext.Books.Add(book.BookId, book);
            return true;
        }
        return false;
    }

    public Book GetBook(int bookId)
    {
        return DataContext.Books[bookId];
    }

    public Dictionary<int,Book> GetAllBook()
    {
        return DataContext.Books;
    }

    public bool UpdateBook(int bookId, 
        int authorId, 
        string title, 
        string desc)
    {
        if (DataContext.Books.ContainsKey(bookId))
        {
            DataContext.Books[bookId].AuthorId = authorId;
            DataContext.Books[bookId].Title = title;
            DataContext.Books[bookId].Description = desc;
            return true;
        }
        return false;
    }

    public bool DeleteBook(int bookId)
    {
        return DataContext.Books.Remove(bookId);
    }

    public bool AddReader(Reader reader)
    {
        if (DataContext.Readers.Contains(reader))
        {
            DataContext.Readers.Add(reader);
            return true;
        }
        return false;
    }

    public Reader GetReader(int Pesel)
    {
        return DataContext.Readers.Find(i => i.Pesel == Pesel);
    }

    public List<Reader> GetAllReader()
    {
        return DataContext.Readers;
    }

    public bool UpdateReader(int Pesel, string Name, string Surname)
    {
        var reader = DataContext.Readers.Find(i => i.Pesel == Pesel);
        if (reader != null)
        {
            reader.Name = Name;
            reader.Surname = Surname;
            return true;
        }
        return false;
    }

    public bool DeleteReader(int Pesel)
    {
        int count = DataContext.Readers.RemoveAll(i => i.Pesel == Pesel);
        return count==0?false:true;
    }

    public bool AddAuthor(Author author)
    {
        if (DataContext.Authors.Contains(author))
        {
            DataContext.Authors.Add(author);
            return true;
        }
        return false;
    }

    public Author GetAuthor(string Name, string Surname)
    {
        return DataContext.Authors.Find(i => (i.Name == Name) && (i.Surname == Surname));
    }

    public List<Author> GetAllAuthor()
    {
        return DataContext.Authors;
    }

    public bool UpdateAuthor(string Name, string Surname, string Description)
    {
        var author = DataContext.Authors.Find(i => (i.Name == Name) && (i.Surname == Surname));
        if (author != null)
        {
            author.Description = Description;
            return true;
        }
        return false;
    }

    public bool DeleteAuthor(string Name, string Surname)
    {
        int count = DataContext.Authors.RemoveAll(i => (i.Name == Name) && (i.Surname == Surname));
        return count == 0 ? false : true;
    }

    public bool AddCopy(Copy copy)
    {
        if (!DataContext.Copies.Contains(copy))
        { 
            DataContext.Copies.Add(copy);
            return true;
        }
        return false;
    }

    public Copy GetCopy(int CopyId)
    {
        return DataContext.Copies.FirstOrDefault(x => x.CopyId == CopyId);
    }

    public ObservableCollection<Copy> GetAllCopy()
    {
        return DataContext.Copies;
    }

    public bool UpdateCopy(int BookId, DateTime releaseDate)
    {

        var copy = DataContext.Copies.FirstOrDefault(i => i.BookId == BookId);
        if (copy != null)
        {
            copy.ReleaseDate = releaseDate;
            return true;
        }
        return false;
    }

    public bool DeleteCopy(Copy copy)
    {
        return DataContext.Copies.Remove(copy);
    }

    public bool AddEvent(Event newEvent)
    {
        if (!DataContext.Events.Contains(newEvent))
        {
            DataContext.Events.Add(newEvent);
            return true;
        }
        return false;
    }

    public Event GetEvent(int copyId, int readerId, DateTime Date, EventType Type)
    {
        return DataContext.Events.FirstOrDefault(x => (x.CopyId == copyId) && (x.ReaderId == readerId)
        && (x.Date == Date) && (x.Type == Type));
    }

    public ObservableCollection<Event> GetAllEvent()
    {
        return DataContext.Events;
    }

    public bool UpdateEvent(int copyId, int readerId, DateTime Date, EventType Type, DateTime newDate)
    {
        var eventObj = DataContext.Events.FirstOrDefault(x => (x.CopyId == copyId) && (x.ReaderId == readerId)
        && (x.Date == Date) && (x.Type == Type));
        if (eventObj != null)
        {
            eventObj.Date = Date;
            return true;
        }
        return false;
    }

    public bool DeleteEvent(Event eventObj)
    {
        return DataContext.Events.Remove(eventObj);
    }

    static void repo_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) //wywietla informacje o zmianach
    {
        if (e.Action == NotifyCollectionChangedAction.Add && e.NewItems != null)
        {
            foreach (var item in e.NewItems)
            {
                Console.WriteLine("Item added: " + item);
            }
        }

        if (e.Action == NotifyCollectionChangedAction.Remove && e.OldItems != null)
        {
            foreach (var item in e.OldItems)
            {
                Console.WriteLine("Items removed:" + item);
            }
        }
    }
}
//