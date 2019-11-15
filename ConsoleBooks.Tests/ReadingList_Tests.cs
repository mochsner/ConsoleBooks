using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

using Xunit;

using ConsoleBooks;

namespace ConsoleBooks
{
    public class ReadingList_Tests
    {

        [Theory(DisplayName = "\r\n\r\nBook.CS Constructor/DB Validation\r\n")]
        [InlineData("The Power of Habit", new String[]{"Charles Duhigg"}, "Random House")]
        public void CheckConstructorsToDatabase_Theory(String title, String[] author, String publisher)
        {
            Book book = new Book(title, author.ToList(), publisher);
            ConsoleBooks.ReadingList expected = new ConsoleBooks.ReadingList();
            expected.AddBook(book);

            ConsoleBooks.ReadingList actual = new ConsoleBooks.ReadingList(title, author.ToList(), publisher);

            var expectedReadingList = expected.GetReadingList();
            var actualReadingList = actual.GetReadingList();

            var diff = expectedReadingList.Zip(actualReadingList,(e,a) => new { Expected = e, Actual = a });
            foreach (var d in diff)
            {
                Assert.Equal(d.Expected.title, d.Actual.title);
                Assert.Equal(d.Expected.author, d.Actual.author);
                Assert.Equal(d.Expected.publisher, d.Actual.publisher);
                
                // Assert.Equal(expected.RemoveBook(d.Expected), d.Actual);
                // Assert.Equal(expected.RemoveBook(d.Expected), null);
            }
            // Cleanup DB
            expected.RemoveBook(book);
        }

        [Theory(DisplayName = "\r\n\r\nBook.CS - AddBook/DB Validation\r\n")]
        [InlineData("The Power of Habit", new String[]{"Charles Duhigg"}, "Random House")]
        public void CheckAddBookToDatabase_Theory(String title, String[] author, String publisher)
        {
            ReadingList expected = new ReadingList(title, author.ToList(), publisher);

            ConsoleBooks.ReadingList actual = new ConsoleBooks.ReadingList();
            actual.AddBook(title, author.ToList(), publisher);

            var expectedReadingList = expected.GetReadingList();
            var actualReadingList = actual.GetReadingList();

            var diff = expectedReadingList.Zip(actualReadingList,(e,a) => new { Expected = e, Actual = a });
            foreach (var d in diff)
            {
                Assert.Equal(d.Expected.title, d.Actual.title);
                Assert.Equal(d.Expected.author, d.Actual.author);
                Assert.Equal(d.Expected.publisher, d.Actual.publisher);
            }
            // Cleanup DB
            // expected.RemoveBook(title,author.ToList(), publisher);  <== This SHOULD work (TODO)
            expected.RemoveBook(new Book(title, author.ToList(), publisher));
        }
    }
}
