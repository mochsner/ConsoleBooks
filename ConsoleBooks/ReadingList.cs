using System;
using System.Collections.Generic;
using System.Text;
using LINQtoCSV;

namespace ConsoleBooks
{
    // [Serializable()]
    public class ReadingList
    {
        public List<Book> readingList;

        public ReadingList ()
        {
            readingList = new List<Book>();
        }
        public ReadingList (String title, String[] author, String publisher)
        {
            Book book = new Book(title,author,publisher);
            readingList = new List<Book>();
            readingList.Add(book);
        }
        public void AddBook (String title, String[] author, String publisher)
        {
            Book book = new Book(title,author,publisher);
            readingList.Add(book);
        }

        public List<Book> GetReadingList()
        {
            return readingList;
        }
    }
}
