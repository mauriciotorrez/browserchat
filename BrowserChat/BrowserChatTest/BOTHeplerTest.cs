using BrowserChat.CSVHelpers;
using NUnit.Framework;

namespace BrowserChatTest
{
    public class BOTHelperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ParseHelp()
        {
            var csvFile = CSVParser.PraseCSV("../../../Resources/aapl.us.csv");
            Assert.IsNotNull(csvFile);
        }

        [Test]
        public void GetMessage()
        {
            var message = CSVParser.GetMessage("aapl.us", "../../../Resources/aapl.us.csv");
            Assert.Equals(message, "AAPL.US quote is $320.25 per share.");
        }
    }
}