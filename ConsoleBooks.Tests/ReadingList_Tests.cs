using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using Xunit;
using LINQtoCSV;

using ConsoleBooks;

namespace ConsoleBooks
{
    public class ReadingList_Tests
    {
        static void Main() {}

        [Theory(DisplayName = "Constructor + Add Book Equality Check")]
        [InlineData("The Power of Habit", new []{"Charles Duhigg"}, "Random House")]
        public void CheckInitializationEquality_Theory(String title, String[] author, String publisher)
        {
            ConsoleBooks.ReadingList readingList1 = new ConsoleBooks.ReadingList(title,author,publisher);

            ConsoleBooks.ReadingList readingList2 = new ConsoleBooks.ReadingList();
            readingList2.AddBook(title,author,publisher);

            Assert.Equal(readingList1.GetReadingList()[0].title,        readingList2.GetReadingList()[0].title); // This should pass (but doesn't)
            Assert.Equal(readingList1.GetReadingList()[0].author,       readingList2.GetReadingList()[0].author); // This should pass (but doesn't)
            Assert.Equal(readingList1.GetReadingList()[0].publisher,    readingList2.GetReadingList()[0].publisher); // This should pass (but doesn't)

        }

        // [Fact(DisplayName = "Ignored Test - Library.cs", Skip = "")]
        // public void ThisIsIgnored()
        // {
        //     //TODO: Fix this test
        // }
    }
}
