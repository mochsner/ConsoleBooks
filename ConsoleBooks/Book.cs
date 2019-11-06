﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleBooks
{
    class Book
    {
        public String title;
        public String[] author;
        public String publisher;

        public Book(string title, String[] author, String publisher)
        {
            this.title = title;
            this.author = author;
            this.publisher = publisher;

            //this.PrintBook(); /// TODO Remove this line
        }
        public void PrintBook()
        {
            Console.WriteLine("  Title:  {0}",this.title);  /// TODO : Box Books in Text (read up on DOTNET output streams)
            this.PluralPrint(this.author, "    Author", "Authors");
            Console.WriteLine("    Publisher:  {0}",this.publisher);

            //book.author.Select(a => (String)a)).ToArray();
        }
        public void PrintBook(int number)
        {
            Console.WriteLine("  Book Number: {0}", number);
            Console.WriteLine("    Title:  {0}",this.title);
            this.PluralPrint(this.author, "    Author", "    Authors");
            Console.WriteLine("    Publisher:  {0}",this.publisher);

            //book.author.Select(a => (String)a)).ToArray();
        }

        public void PluralPrint(String[] array, String singular, String plural)
        {
            if (array.Length <= 0)
            {
                Console.WriteLine(singular,"  : N/A");
            }
            else if (array.Length <= 1)
            {
                Console.WriteLine("{0}:  {1}",singular, array[0]);
            }
            else
            {
                Console.WriteLine(plural,":\r\n");
                Array.ForEach(array, i => Console.WriteLine("{0}",i));
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
