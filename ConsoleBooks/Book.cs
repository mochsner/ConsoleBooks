using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleBooks
{
    public class Book
    {
        public Guid id { get; set; }
        public String title { get; set; }
        public String author { get; set; }
        public String publisher { get; set; }

        // public int readingList_id { get; set; }
        // public ReadingList readingList { get; set; }

        public Book()
        {
            this.title = "";
            this.author = "";
            this.publisher = "";
        }
        public Book(string title, List<String> author, String publisher)
        {
            this.title = title;
            this.author = String.Join(",", author.ToArray());
            this.publisher = publisher;

            //this.PrintBook(); /// TODO Remove this line
        }

        public void addTitle(string title)
        {
            this.title = title;
        }
        public void addAuthor(List<String> author)
        {
            this.author = String.Join(",", author.ToArray());
        }
        public void addPublisher(String publisher)
        {
            this.publisher = publisher;
        }
        public void PrintBook()
        {
            
            Console.WriteLine("  Title:  {0}", this.title);  /// TODO : Box Books in Text (read up on DOTNET output streams)
            Console.WriteLine(this.author, "    Author", "Authors");
            Console.WriteLine("    Publisher:  {0}", this.publisher);

            //book.author.Select(a => (String)a)).ToauthorArray();
        }
        public void PrintBookWithIndex(int number)
        {
            Console.WriteLine("  Book Number: {0}", number);
            Console.WriteLine("    Title:  {0}", this.title);
            this.PluralPrint(this.author, "    Author", "    Authors");
            Console.WriteLine("    Publisher:  {0}", this.publisher);

            //book.author.Select(a => (String)a)).ToauthorArray();
        }

        public void PluralPrint(String authorDelimited, String singular, String plural)
        {
            List<String> authorList = authorDelimited.Split(",").ToList();
            if (authorList.Count <= 0)
            {
                Console.WriteLine(singular,"  : N/A");
            }
            else if (authorList.Count <= 1)
            {
                Console.WriteLine("{0}:  {1}",singular, authorDelimited);
            }
            else
            {
                Console.WriteLine(plural,":\r\n");
                authorList.ForEach(i => Console.WriteLine("{0}",i));
            }
        }

       // public Book(string title, string author, string[] publisher)
       // {
       //     this.title = title;
       //     this.author[0] = author;
       //     this.publisher = publisher;
       // }
       // public Book(string title, string[] author, string publisher)
       // {
       //     this.title = title;
       //     this.author = author;
       //     this.publisher[0] = publisher;
       // }
       // public Book(string title, string[] author, string[] publisher)
       // {
       //     this.title = title;
       //     this.author = author;
       //     this.publisher = publisher;
       // }
    }
}
