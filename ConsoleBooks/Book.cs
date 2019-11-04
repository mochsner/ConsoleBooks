using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleBooks
{
    class Book
    {
        public String title;
        public String[] author;
        public String[] publisher;

        public Book(string title, string author, string publisher)
        {
            this.title = title;
            this.author[0] = author;
            this.publisher[0] = publisher;
        }
        public Book(string title, string author, string[] publisher)
        {
            this.title = title;
            this.author[0] = author;
            this.publisher = publisher;
        }
        public Book(string title, string[] author, string publisher)
        {
            this.title = title;
            this.author = author;
            this.publisher[0] = publisher;
        }
        public Book(string title, string[] author, string[] publisher)
        {
            this.title = title;
            this.author = author;
            this.publisher = publisher;
        }
    }
}
