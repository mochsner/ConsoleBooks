using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LINQtoCSV;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Design;

namespace ConsoleBooks
{
    // [Serializable()]
    public class BookContext : DbContext
    {
        //public DbSet<ReadingList> readingLists { get; set; }
        public DbSet<Book> readingList {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source=C:\\Users\\Owner\\Source\\Repos\\ConsoleBooks\\ConsoleBooks\\ReadingList.db");
    }

    public class ReadingList
    {
        public int id {get; set;}
        BookContext db = new BookContext();

        public ReadingList ()
        {
        }
        public ReadingList (String title, List<String> author, String publisher)
        {
            Book book = new Book(title,author,publisher);
            db.readingList.Add(book);
            db.SaveChanges();
        }
        public void AddBook (String title, List<String> author, String publisher)
        {
            Book book = new Book(title,author,publisher);
            db.readingList.Add(book);
            db.SaveChanges();
        }
        public void AddBook (Book book)
        {
            db.readingList.Add(book);
            db.SaveChanges();
        }

        public List<Book> GetReadingList()
        {
            var _readingList = db.readingList.ToList();
            // _readingList = _readingList.All(x => x.author = (x.author.Split("^"))); /// TODO: Remove or Revert Book.cs to use List/Array
            return _readingList;
        }

        public DbSet<Book> GetReadingDbSet()
        {
            //var aReadingList = db.readingList.(x => x.id != null);

            return db.readingList;
        }
    }
}
