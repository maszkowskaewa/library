using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class DataRepositoryTests
    {
        [TestMethod()]
        public void AddBookTest()
        {
            Book newBook = new Book(1, 1, "title", "desc");
            DataRepository repo = new DataRepository();

            Assert.IsTrue(repo.AddBook(newBook));
        }

        [TestMethod()]
        public void AddBookTest2()
        {
            Book newBook = new Book(1, 1, "title", "desc");
            Book newBook2 = new Book(1, 2, "title2", "desc2");
            DataRepository repo = new DataRepository();
            repo.AddBook(newBook);

            Assert.IsFalse(repo.AddBook(newBook2));
        }

        [TestMethod()]
        public void GetBookTest()
        {
            Book newBook = new Book(1, 1, "title", "desc");
            DataRepository repo = new DataRepository();
            repo.AddBook(newBook);
            Book restoredBook = repo.GetBook(newBook.BookId);
            
            Assert.AreEqual(newBook, restoredBook);
        }

        [TestMethod()]
        public void GetAllBookTest()
        {
            Book newBook = new Book(1, 1, "title", "desc");
            Book newBook2 = new Book(2, 1, "title", "desc");
            DataRepository repo = new DataRepository();
            repo.AddBook(newBook);
            repo.AddBook(newBook2);
            var restoredBook = repo.GetAllBook();

            Assert.AreEqual(2,restoredBook.Count);
        }

        [TestMethod()]
        public void UpdateBookTest()
        {
            string newDesc = "new desc";
            Book newBook = new Book(1, 1, "title", "desc");
            DataRepository repo = new DataRepository();
            repo.AddBook(newBook);
            repo.UpdateBook(newBook.BookId,
                newBook.AuthorId, 
                newBook.Title,
                newDesc);
            Book restoredBook = repo.GetBook(newBook.BookId);

            Assert.AreEqual(newDesc, restoredBook.Description);
        }

        [TestMethod()]
        public void DeleteBookTest()
        {
            Book newBook = new Book(1, 1, "title", "desc");
            DataRepository repo = new DataRepository();
            repo.AddBook(newBook);

            Assert.IsTrue(repo.DeleteBook(newBook.BookId));
        }

        [TestMethod()]
        public void DeleteBookTest2()
        {
            Book newBook = new Book(1, 1, "title", "desc");
            DataRepository repo = new DataRepository();
            repo.AddBook(newBook);

            Assert.IsFalse(repo.DeleteBook(2));
        }


        [TestMethod()]
        public void AddReaderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetReaderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllReaderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DataRepositoryTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateReaderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteReaderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddAuthorTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAuthorTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllAuthorTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateAuthorTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteAuthorTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddCopyTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCopyTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllCopyTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateCopyTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteCopyTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddEventTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetEventTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllEventTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateEventTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteEventTest()
        {
            Assert.Fail();
        }
    }
}