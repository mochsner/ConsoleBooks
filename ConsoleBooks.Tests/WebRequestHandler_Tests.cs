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

        [Theory(DisplayName = "WebRequestHandler.cs - Handle Different Searches")]
        [InlineData("The Power of Habit")]
        [InlineData("klajsdofkjopqiwkejalskmclkamsd")]
        [InlineData("")]
        [InlineData("^")]
        public void WebRequestHandler_Theory(String search)
        {
            WebResponse response = requests.InvokeRequest(query);
            List<Book> parsedResponse = requests.HandleResponse(response);
            return parsedResponse;
        }
    }
}
