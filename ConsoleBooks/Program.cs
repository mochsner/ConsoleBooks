using System;
using System.IO;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

            // Search
            WebResponse response = InvokeRequest(query);
            var parsedResponse = HandleResponse(response);
             
        }
        /// <summary>
        /// Invokes a Web Request
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        private WebResponse InvokeRequest(String query)
        {
            String baseURI = "https://www.googleapis.com/books/v1/";
            String method = "volumes?maxResults=1&q=";
            WebRequest request = WebRequest.Create(baseURI + method + query);
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusCode);

            return response;
        }
        private Book[] HandleResponse(WebResponse response)
        {
            String responseFromServer = "";
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                responseFromServer = reader.ReadToEnd();
            }

            // Display the content.  
            JObject jsonObject = JObject.Parse(responseFromServer);
            JArray jsonArray = (JArray)jsonObject["items"];

            Book[] bookSearch = new Book[5];
            int i = 0;
            foreach (var obj in jsonArray)
            {
                dynamic author = obj["volumeInfo"]["authors"]; // Overloading
                dynamic publisher;
                try
                {
                    publisher = obj["volumeInfo"]["publisher"];
                }
                catch (System.FormatException e)
                {
                    publisher = obj["volumeInfo]"]["author"];
                }
                dynamic title = obj["volumeInfo"]["title"];

                Book book = new Book(title, author, publisher);
                bookSearch[i] = book;
                ++i;
            }
            return bookSearch;
        }

        private String Menu()
        {
            string[] permittedAnswers = { "s", "search", "v", "view", "q", "quit" };
            string choice = "";
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
                    Search();
                }
                else if (choice == "v" || choice == "view")
                {
                }
                else if (choice == "q" || choice == "quit")
                {
                    Console.WriteLine("Quitting Application.");
                    //Console.WriteLine("Press any buttom to interrupt cancellation");
                }
                else
                {
                    Console.WriteLine(choice, " is not a valid action. Please try again.");
                }

            } while (Array.Exists(permittedAnswers, permittedAnswer => permittedAnswer == choice));

            return choice;
        }
        private static void Quit()
        {

        }
        private void View()
        {

        }
    }
}
