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
        public static String[] expressionsForYes = new string[] { "yes", "y" };
        public static String[] expressionsForNo  = new string[] { "no", "n" };

        WebRequestHandler requests = new WebRequestHandler(); 
        ReadingList readingList = new ReadingList();

        static void Main(string[] args)
        {
            Program program = new Program();
            program.EnterLibrary();
            
            String action = "";
            while (action != "q" && action != "quit")
            {
                action = program.Menu();
            }
        }

        private void EnterLibrary()
        {
            Console.WriteLine(" ________________________");
            Console.WriteLine("|                        |");
            Console.WriteLine("| Welcome to the Library |");
            Console.WriteLine("|________________________|");
        }

        private List<Book> SearchLibrary()
        {
            String query;

            do
            {
                // Get Valid Response
                Console.WriteLine("Please search for a book you're interested in.");
                query = Console.ReadLine();

                if (query == "")
                {
                    Console.WriteLine("A valid search must contain at least one character. Please try again.");
                }

            } while (query.Length <= 0);

            // Search
            WebResponse response = requests.InvokeRequest(query);
            List<Book> parsedResponse = requests.HandleResponse(response);
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
        ///   -1: user decided to quit a bit late
        ///   0: poorly formatted input
        ///   N: no issues
        /// </returns>

       private int InputIntegerList(String request, List<String> permittedResponse)
        {
            Console.WriteLine(request);
            String choice = Console.ReadLine();

            // Q means quit, numbers mean save. Ignore others
            var c = choice.Trim();
            if (c == "q" || c == "Q")
            {
                // Return - User Quit
                Console.WriteLine("You have decided not to edit anything, instead choosing to [Q]uit.");
                return -1;
            }
            else if (int.TryParse(c, out int n))
            {
                // Add Number
                if (permittedResponse.Contains(c))
                {
                    Console.WriteLine("{0} exists as valid input!", c); /// TODO remove
                    return int.Parse(c);
                }
                else
                {
                    Console.WriteLine("{0} is an invalid integer.",c); /// TODO Optimize User experience?
                    return 0;
                }
            } else
            {
                // Return - User Error
                Console.WriteLine("Invalid character: {0}. Please re-submit with valid input.",c);
                return 0;
            }
        }

        private String Menu()
        {
            string[] permittedAnswers = { "s", "search", "v", "view", "q", "quit" };
            string choice = "";

            // Loop Menu until valid workflow
            do
            {
                Console.WriteLine(
                    " _________________\r\n" +
                    "|                 |\r\n" +
                    "|    MAIN MENU    |\r\n" +
                    "|_________________|\r\n" +
                    "[s]earch:  Search the library\r\n" +
                    "[v]iew:    View your reading list\r\n" +
                    "[q]uit:    Quit");

                choice = Console.ReadLine();

                if (choice == "s" || choice == "search")
                {
                    List<Book> bookQuery = SearchLibrary();

                    int index = 1;
                    foreach (Book book in bookQuery) { 
                        book.PrintBookWithIndex(index); ++index;
                    }

                    // Ask if any books are interesting
                    String confirm = InputYesOrNo("Would you like to add any books to your reading List?\r\n" +
                        "Answer [Y]es, or [N]o.", new string[] { "yes", "y", "no", "n" });

                    if (expressionsForYes.Contains(confirm.ToLower()))
                    {
                        // Ask which books to add to "Reading List"
                        int bookNumber = InputIntegerList("Please enter the number of the book you would like to add (1-5), or type 'r' to return to the main menu.",
                            new List<String> { "1", "2", "3", "4", "5" });

                        // Output what user added to reading list
                        Console.WriteLine("Book being added to reading list:"); 
                        bookQuery[bookNumber - 1].PrintBookWithIndex(bookNumber);
                        readingList.AddBook(bookQuery[bookNumber - 1]);
                    }
                    else //no "ELSE IF" needed; InputYesOrNo catches any other responses 
                    {
                        Console.WriteLine("No book was selected to add to the reading list.");
                    }
                    Console.WriteLine("Redirecting back to the main menu.");
                    continue;
                }
                else if (choice == "v" || choice == "view")
                {
                    Console.WriteLine(
                        " ____________________\r\n" +
                        "|                    |\r\n" +
                        "|    READING LIST    |\r\n" +
                        "|____________________|\r\n");
                    readingList.Print();
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
