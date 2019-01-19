using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class SmallCollectionGenerator : IFillWithDefaultValues //klasa WypelnianieStalymi
    //implementuje interfejs IFillWithDefaultValues
    {
        public List<Author> GenerateAuthorCollection()
        {
            List<Author> authorList = new List<Author>();

            authorList.Add(new Author(1, "a", "aa", "aaa"));
            authorList.Add(new Author(2, "b", "bb", "bbb"));
            authorList.Add(new Author(3, "c", "cc", "ccc"));
            authorList.Add(new Author(4, "d", "dd", "ddd"));
            authorList.Add(new Author(5, "e", "ee", "eee"));

            return authorList;
        }

        public Dictionary<int, Book> GenerateBookCollection()
        {
            Dictionary<int, Book> bookDict = new Dictionary<int, Book>();

            bookDict.Add(1,new Book(1, 1, "a", "aa"));
            bookDict.Add(2,new Book(2, 2, "b", "bb"));
            bookDict.Add(3,new Book(3, 2, "c", "cc"));
            bookDict.Add(4,new Book(4, 4, "d", "dd"));
            bookDict.Add(5,new Book(5, 5, "e", "ee"));

            return bookDict;
        }

        public ObservableCollection<Copy> GenerateCopyCollection()
        {
            ObservableCollection<Copy> copyColl = new ObservableCollection<Copy>();

            copyColl.Add(new Copy(1, 1, new DateTime(2008, 3, 9, 1, 30, 0), new DateTime(2008, 3, 9, 1, 30, 0)));
            copyColl.Add(new Copy(2, 2, new DateTime(2008, 3, 9, 1, 30, 0), new DateTime(2008, 3, 9, 1, 30, 0)));
            copyColl.Add(new Copy(3, 3, null, new DateTime(2008, 3, 9, 1, 30, 0)));
            copyColl.Add(new Copy(4, 4, null, new DateTime(2008, 3, 9, 1, 30, 0)));
            copyColl.Add(new Copy(5, 5, new DateTime(2008, 3, 9, 1, 30, 0), new DateTime(2008, 3, 9, 1, 30, 0)));

            return copyColl;
        }

        public ObservableCollection<Event> GenerateEventCollection()
        {
            ObservableCollection<Event> eventColl = new ObservableCollection<Event>();

            eventColl.Add(new Event(1, 1, new DateTime(2008, 3, 9, 1, 30, 0), Event.EventType.Wypozyczenie));
            eventColl.Add(new Event(2, 2, new DateTime(2008, 3, 9, 1, 30, 0), Event.EventType.Wypozyczenie));
            eventColl.Add(new Event(3, 3, new DateTime(2008, 3, 9, 1, 30, 0), Event.EventType.Wypozyczenie));
            eventColl.Add(new Event(4, 4, new DateTime(2008, 3, 9, 1, 30, 0), Event.EventType.Wypozyczenie));
            eventColl.Add(new Event(5, 5, new DateTime(2008, 3, 9, 1, 30, 0), Event.EventType.Wypozyczenie));

            return eventColl;
        }

        public List<Reader> GenerateReaderCollection()
        {
            List<Reader> readerList = new List<Reader>();

            readerList.Add(new Reader(1, "a", "aa", 12345));
            readerList.Add(new Reader(2, "b", "bb", 23456));
            readerList.Add(new Reader(3, "c", "cc", 34567));
            readerList.Add(new Reader(4, "d", "dd", 45678));
            readerList.Add(new Reader(5, "e", "ee", 56789));

            return readerList;
        }
    }
}
