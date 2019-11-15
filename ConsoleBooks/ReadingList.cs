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
        public void RemoveBook (int id, String title, List<String> author, String publisher)
        {
            Book book = new Book(title,author,publisher);
            db.readingList.Remove(book);
            db.SaveChanges();
        }
        public Book RemoveBook(Book book)
        {
            try{
                db.readingList.Remove(book);
                db.SaveChanges();
                return book;
            } catch (Exception e) {
                return null;
                throw new Exception (e.Message);
            }
        }
        public void Print()
        {
            var list = this.GetReadingList();
            list.ForEach(book => book.PrintBook());
        }
        public List<Book> GetReadingList()
        {
            var _readingList = db.readingList.ToList();
            return _readingList;
        }

        public DbSet<Book> GetReadingDbSet()
        {

            return db.readingList;
        }
    }
}
