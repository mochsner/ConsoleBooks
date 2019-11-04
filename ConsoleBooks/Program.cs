using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace ConsoleBooks
{
    class Program
    {
        /// <summary>
        /// Entering the Program starts here. This is the main class.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Initialize();

            String action = "";
            while (action != "q" && action != "quit")
            {
                action = program.Menu();
            }
        }
        private void Initialize()
        {
            Console.WriteLine("Welcome to the Library");
        }

        private void Search()
        {
            String query;

            // Loop until valid input is given
            do
            {
                Console.WriteLine("Please search for a book you're interested in.");
                query = Console.ReadLine();

                if (query == "")
                {
                    Console.WriteLine("A valid search must contain at least one character. Please try again.");
                    //TODO Unit test on other potentially invalid searches
                }

            } while (query.Length <= 0);

            //TODO Search!
            
        }

   
        private String Menu()
        {
            string[] permittedAnswers = { "s", "search", "v", "view", "q", "quit" };
            string choice = "";
            do
            {
                Console.WriteLine("`" +
                    "Would you like to:`" +
                    "[s]earch:  Search the library`" +
                    "[v]iew:    View your reading list`" +
                    "[q]uit:    Quit");

                choice = Console.ReadLine();

                if (choice == "s" || choice == "search")
                {
                    Search();

                }
                else if (choice == "v" || choice == "view")
                {

                }
                else if (choice == "q" || choice == "quit")
                {

                }
                else
                {
                    Console.WriteLine(choice, " is not a valid action. Please try again.");
                }

            } while (Array.Exists(permittedAnswers, permittedAnswer => permittedAnswer == choice));

            return choice;
        }
        private void View()
        {

        }
    }
}
