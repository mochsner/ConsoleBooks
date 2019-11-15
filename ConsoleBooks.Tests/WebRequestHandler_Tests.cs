using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

using Xunit;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ConsoleBooks;

namespace ConsoleBooks
{
    public class WebRequestHandler_Tests
    {
        [Theory(DisplayName = "WebRequestHandler.cs - Handle Valid Searches")]
        [InlineData("The Power of Habit")]
        public void WebRequestHandler_Valid_Theory(String search)
        {
          WebRequestHandler requests = new WebRequestHandler();
          WebResponse response = requests.InvokeRequest(search);
          Assert.NotNull(response);
          List<Book> parsedResponse = requests.HandleResponse(response);
          Assert.NotNull(parsedResponse);
        }

        [Theory(DisplayName = "WebRequestHandler.cs - Handle Different Searches")]
        [InlineData("klajsdofkjopqiwkejalskmclkamsd")]
        // [InlineData("^")]
        public void WebRequestHandler_Null_Theory(String search)
        {
          WebRequestHandler requests = new WebRequestHandler();
          WebResponse response = requests.InvokeRequest(search);
          Assert.Null(response);
          List<Book> parsedResponse = requests.HandleResponse(response);
          Assert.NotNull(parsedResponse);
        }

        [Theory(DisplayName = "WebRequestHandler.cs - Handle Different Searches")]
        [InlineData("")]
        public void WebRequestHandler_BadRequest_Theory(String search)
        {
          WebRequestHandler requests = new WebRequestHandler();

          WebResponse response = requests.InvokeRequest(search);
          Assert.Null(response);
        }
    }
}
