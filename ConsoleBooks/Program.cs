using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleBooks
{

    class Program
    {
        Requests requests = new Requests(); // Too Hacky - Update this to use a Class Library if time allows
        public static String[] expressionsForYes = new string[] { "yes", "y" };
        public static String[] expressionsForNo  = new string[] { "no", "n" };

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

        private Book[] SearchLibrary()
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

            // Search
            WebResponse response = requests.InvokeRequest(query);
            Book[] parsedResponse = requests.HandleResponse(response);
            return parsedResponse;
        }

        private String InputYesOrNo(String request, String[] permittedResponse)
        {
            String choice = "";
            Console.WriteLine(request);
            choice = Console.ReadLine();

            while (!Array.Exists(permittedResponse, permitted => 
                                permitted.ToLower() == choice.ToLower()))
            {
                Console.WriteLine("{0} is not a valid response. Please choose one of the following responses", choice);
                Console.WriteLine(request);
                choice = Console.ReadLine();
            }

            return choice;
        }

        /// <summary>
        /// Parses user input to decide what books to save
        /// </summary>
        /// <param name="request"></param>
        /// <param name="permittedResponse"></param>
        /// <returns>
        ///   Null array: user decided to quit a bit late
        ///   Empty array: poorly formatted input
        ///   Normal array: no issues
        /// </returns>

       private List<int> InputIntegerList(String request, List<String> permittedResponse)
        {
            List<String> choice;
            Console.WriteLine(request);
            choice = Console.ReadLine().Split(',').ToList();

            List<int> books = new List<int>();
            // Q means quit, numbers mean save. Ignore others
            foreach (var i in choice)
            {
                var c = i.Trim();
                if (c == "q" || c == "Q")
                {
                    // Return - User Quit
                    Console.WriteLine("You have decided not to edit anything, instead choosing to [Q]uit.");
                    return null;
                }
                else if (!int.TryParse(c, out int n))
                {
                    // Add Number
                    books.Add(int.Parse(c)); 
                } else
                {
                    // Return - User Error
                    Console.WriteLine("Invalid input given via character '{0}. Please re-submit your most recent entry (click up arrow + edit)?");
                    return books = new List<int>();
                }
            }
            return books;
        }

        private String Menu()
        {
            string[] permittedAnswers = { "s", "search", "v", "view", "q", "quit" };
            string choice = "";

            // Loop Menu until valid workflow
            do
            {
                Console.WriteLine("\r\n" +
                    "Would you like to:\r\n" +
                    "[s]earch:  Search the library\r\n" +
                    "[v]iew:    View your reading list\r\n" +
                    "[q]uit:    Quit");

                choice = Console.ReadLine();

                if (choice == "s" || choice == "search")
                {
                    Book[] bookQuery = SearchLibrary();

                    // Print Books with a Number
                    int i = 0;
                    foreach (Book book in bookQuery)
                    {
                        book.PrintBook(i+1);
                        i++;
                    }

                    // Ask if any books are interesting
                    String confirm = InputYesOrNo("Would you like to add any books to your reading List?\r\n" +
                        "Answer [Y]es, or [N]o.", new string[] { "yes", "y", "no", "n" });

                    if (expressionsForYes.Contains(confirm.ToLower()))
                    {
                        // Ask which books to add to "Reading List"
                        Console.WriteLine("Please enter the Book numbers you would like to add, comma separated.\r\n");
                        List<int> newReadingList = InputIntegerList("Please enter the Book numbers you would like to add, comma separated.",
                            new List<String> { "1", "2", "3", "4", "5" });

                        // Output what user added to reading list
                        Console.WriteLine("Books being added to reading list:"); 
                        foreach (int queryNumber in newReadingList)
                        {
                            bookQuery[queryNumber-1].PrintBook(queryNumber-1);
                        }
                        

                    }
                    else if (expressionsForNo.Contains(confirm.ToLower()))
                    {
                        Console.WriteLine("Redirecting back to the main menu.");
                        continue;
                    }


                }
                else if (choice == "v" || choice == "view")
                {
                }
                else if (choice == "q" || choice == "quit")
                {
                    Quit();
                }
                else
                {
                    Console.WriteLine(choice, " is not a valid action. Please try again.");
                }

            } while (Array.Exists(permittedAnswers, permitted => permitted == choice));

            return choice;
        }

        private void Quit()
        {
            Console.WriteLine("Quitting Application.");
            Environment.Exit(0);
        }

        private void View()
        {

        }
    }
}
