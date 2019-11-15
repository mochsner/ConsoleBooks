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
        // [Fact]
        // public void FirstFact()
        // {
        // }

        [Theory(DisplayName = "Constructor + Add Book Equality Check")]
        [InlineData("The Power of Habit", new []{"Charles Duhigg"}, "Random House")]
        public void FirstTheory(String title, String[] author, String publisher)
        {
            ReadingList readingList1 = new ReadingList(title,author,publisher);

            ReadingList readingList2 = new ReadingList();
            readingList2.AddBook(title,author,publisher);

            Assert.Equal(readingList1,readingList2); // This should pass (but doesn't)
        }

        // [Fact(DisplayName = "Ignored Test - Library.cs", Skip = "")]
        // public void ThisIsIgnored()
        // {
        //     //TODO: Fix this test
        // }
    }
}
