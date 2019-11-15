using System;
using System.Collections.Generic;
using System.Text;
using LINQtoCSV;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Design;

namespace ConsoleBooks
{
    // [Serializable()]
    public class BookContext : DbContext
    {
        public DbSet<Book> readingList { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=ReadingList.db");

    }
    public class ReadingList
    {
        public List<Book> readingList;
        BookContext db;

        public ReadingList ()
        {
            readingList = new List<Book>();
            db = new BookContext();
        }
        public ReadingList (String title, String[] author, String publisher)
        {
            Book book = new Book(title,author,publisher);
            readingList = new List<Book>();
            readingList.Add(book);
            db.Add(book);
            db.SaveChangesAsync();
        }
        public void AddBook (String title, String[] author, String publisher)
        {
            Book book = new Book(title,author,publisher);
            readingList.Add(book);
            db.Add(book);
            db.SaveChangesAsync();
        }

        public List<Book> GetReadingList()
        {
            return readingList;
        }
    }
}
