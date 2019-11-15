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
    public class WebRequestHandler
    {
        public WebResponse InvokeRequest(String query)
        {
            String baseURI = "https://www.googleapis.com/books/v1/";
            String method = "volumes?maxResults=5&q=";
            WebRequest request = WebRequest.Create(baseURI + method + query);

            WebResponse response;
            try{
                response = request.GetResponse();
            } catch (WebException e) {
                response = null;
            }

            if (((HttpWebResponse)response).StatusCode==HttpStatusCode.OK){
                return response;
            } else {
                return null;
            }
        }
        public List<Book> HandleResponse(WebResponse response)
        {
            String responseFromServer = "";
            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream); 
                responseFromServer = reader.ReadToEnd();
            }

            // Display the content.  
            JObject queryObject = JObject.Parse(responseFromServer);
            JArray queryArray = (JArray)queryObject["items"];

            List<Book> bookSearch = new List<Book>();

            foreach (JObject jBookObj in queryArray)
            {

                // Title
                String title = Convert.ToString(jBookObj["volumeInfo"]["title"]);

                // Author
                String text = Convert.ToString(jBookObj["volumeInfo"]["authors"]);
                JArray authorObject = JArray.Parse(text); // Overloading
                List<String> authorArray = ConvertFromJArray(authorObject);

                // Publisher
                String publisher = "";
                JToken token = jBookObj["volumeInfo"]["publisher"];
                if (token != null)
                {
                    publisher = Convert.ToString(jBookObj["volumeInfo"]["publisher"]);
                }
                
                Book book = new Book(title, authorArray, publisher);

                bookSearch.Add(book);
            }
            return bookSearch;
        }
        public List<String> ConvertFromJArray(JArray jArray)
        {
            List<String> list;
            list = jArray.Select(i => (String)i).ToArray().ToList();
            list.ToList();
            return list;
        }

    }
}
