using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static Event;

namespace test
{
    class RandomCollectionGenerator : IFillWithDefaultValues
    {
        private int CONST_DAY = 1000;
        public int BookAmount { get; private set; } //ilość książek do wygenerowania
        public int CopyAmount { get; private set; }
        public int AuthorAmount { get; private set; }
        public int ReaderAmount { get; private set; }
        public int EventAmount { get; private set; }

        public RandomCollectionGenerator(int bookAmount, int copyAmount, 
            int authorAmount, int readerAmount, int eventAmount) {
            BookAmount = bookAmount;
            CopyAmount = copyAmount;
            AuthorAmount = authorAmount;
            ReaderAmount = readerAmount;
            EventAmount = eventAmount;
        }

        private static Random random = new Random(); //Random- klasa systemowa, zrwaca losową liczbę

        private string RandomString(int length) //długość
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());//generuje tablicę losowo wybranych znaków
        }

        public List<Author> GenerateAuthorCollection()
        {
            List<Author> authorList = new List<Author>(AuthorAmount);
            for (int i=1; i<=AuthorAmount; i++) {
                authorList.Add(new Author(i,          //wywołanie konstruktora z losową wartością, dla 3 parametrów z 4
                    RandomString(random.Next(3, 10)), //generują losowe stringi o losowej dłufości z przedziału 3-10
                    RandomString(random.Next(2, 15)), 
                    RandomString(random.Next(1,50))));
            }
            return authorList;
        }

        public Dictionary<int, Book> GenerateBookCollection()
        {
            Dictionary<int, Book> bookDict = new Dictionary<int, Book>();
            for (int i = 1; i <= BookAmount; i++)
            {
                bookDict.Add(i, new Book(i, 
                    random.Next(1, AuthorAmount), //losuje jedną liczbę z zakres 1-AuthorAmount jako AuthorID
                    RandomString(random.Next(2, 15)), 
                    RandomString(random.Next(2, 50))));
            }

            return bookDict;
        }

        public ObservableCollection<Copy> GenerateCopyCollection()
        {
            ObservableCollection<Copy> copyColl = new ObservableCollection<Copy>();
            DateTime now = DateTime.Now;
            for (int i = 1; i <= CopyAmount; i++)
            {
                DateTime buyDate = DateTime.Now.AddDays(- random.Next(CONST_DAY));
                int diff = (now - buyDate).Days;
                copyColl.Add(new Copy(i, 
                    random.Next(1, BookAmount),
                    DateTime.Now.AddDays(-random.Next(1,diff)),
                    buyDate));
            }
            return copyColl;
        }

        public ObservableCollection<Event> GenerateEventCollection()
        {
            var lastEventType = Enum.GetValues(typeof(EventType)).Cast<EventType>().Last();//zwraca ostatni element z enum
            ObservableCollection<Event> eventColl = new ObservableCollection<Event>();
            DateTime now = DateTime.Now;
            for (int i = 1; i <= EventAmount; i++)
            {
                DateTime buyDate = DateTime.Now.AddDays(-random.Next(1000));
                int diff = (now - buyDate).Days;
                eventColl.Add(new Event(random.Next(1, CopyAmount),
                    random.Next(1, ReaderAmount),
                    DateTime.Now.AddDays(-random.Next(1, diff)),
                    (EventType)random.Next(0, (int)lastEventType)));
            }
            return eventColl;
        }

        public List<Reader> GenerateReaderCollection()
        {
            List<Reader> readerList = new List<Reader>(AuthorAmount);
            for (int i = 1; i <= AuthorAmount; i++)
            {
                readerList.Add(new Reader(i,
                    RandomString(random.Next(3, 10)),
                    RandomString(random.Next(2, 15)),
                    66666+i));  //pesel
            }
            return readerList;
        }
    }
}
