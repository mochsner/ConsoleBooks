using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleBooks
{
    class Book
    {
        public String title;
        public JArray author;
        public JArray publisher;

        public Book(string title, JArray author, JArray publisher)
        {
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            Console.WriteLine(this.title, this.author, this.publisher);
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
