﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ConsoleBooks
{
    class Requests
    {
        /// <summary>
        /// Invokes a Web Request
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public WebResponse InvokeRequest(String query)
        {
            String baseURI = "https://www.googleapis.com/books/v1/";
            String method = "volumes?maxResults=1&q=";
            WebRequest request = WebRequest.Create(baseURI + method + query);
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusCode);

            return response;
        }
        public Book[] HandleResponse(WebResponse response)
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
            JObject queryObject = JObject.Parse(responseFromServer);
            JArray queryArray = (JArray)queryObject["items"];

            Book[] bookSearch = new Book[5];
            int i = 0;
            foreach (var obj in queryArray)
            {
                // Title
                String title = Convert.ToString(obj["volumeInfo"]["title"]);

                // Author
                String text = Convert.ToString(obj["volumeInfo"]["authors"]);
                JArray authorObject = JArray.Parse(text); // Overloading
                String[] authorArray = ConvertFromJArray(authorObject);

                // Publisher
                JArray publisherObject;
                JToken token = obj["volumeInfo"]["publisher"];
                if (token != null)
                {
                    text = Convert.ToString(obj["volumeInfo"]["publisher"]);
                    publisherObject = JArray.Parse(text); // Overloading
                }
                else
                {
                    publisherObject = JArray.Parse("[]");
                }
                String[] publisherArray = ConvertFromJArray(publisherObject);
                
                //Book book = new Book(title, authorObject, publisherArray);
                Book book = new Book(title, authorArray, publisherArray);

                bookSearch[i] = book;
                ++i;
            }
            return bookSearch;
        }
        public String[] ConvertFromJArray(JArray jArray)
        {
            String[] array;
            array = jArray.Select(i => (String)i).ToArray();
            return array;
        }

    }
}