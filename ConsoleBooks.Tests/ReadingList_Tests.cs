using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using LINQtoCSV;

namespace ConsoleBooks
{
    public class LinqToCSV
    {
        [Fact]
        public void FirstFact()
        {

        }

        [Theory]
        [InlineData(5, 3, 2)]
        public void FirstTheory(int expected, int addend1, int addend2)
        {
            Assert.Equal(expected, addend1 + addend2);
        }

        [Fact(DisplayName = "Ignored Test - Library.cs", Skip = "")]
        public void ThisIsIgnored()
        {
            //TODO: Fix this test
        }
    }
}
