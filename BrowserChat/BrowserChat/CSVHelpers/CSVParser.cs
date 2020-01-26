using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserChat.CSVHelpers
{
    public static class CSVParser
    {
        public static IEnumerable<Aapl> PraseCSV()
        {
            TextReader reader = new StreamReader("Resources/aapl.us.csv");
            var csvReader = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);
            var records = csvReader.GetRecords<Aapl>();
            return records.ToList();
        }

        public static string GetMessage(string stock_code)
        {
            string result = "Something wrong in your stock_code";
            try
            {
                var row = PraseCSV().Where(txt => txt.Symbol.Equals(stock_code, StringComparison.CurrentCultureIgnoreCase));
                if (row != null && row.Count() > 0)
                {
                    result = InterpretMessage(row.First());
                }
            }
            catch (Exception)
            {
                result = "Something wrong. Please contect your sistemd administrator";
            }
            return result;
        }

        private static string InterpretMessage(Aapl row)
        {
            string finalMessage = string.Empty;
            finalMessage = row.Symbol.Substring(0,4) switch
            {
                "AAPL" => $"{row.Symbol} quote is ${row.Open} per share.",
                "COST" => $"Total cost is ${row.Volume} per share.",
                "PRIN" => $"{row.Symbol} Open is ${row.Open} per share.",
                "HELL" => $"Just BOT greetings! ${row.Open} is thelow value.",
                "TOTA" => $"{row.Symbol} High is ${row.High}.",
                _ => $"{row.Symbol} => We have, {row.Volume}! For {row.Date}, at {row.Time}.",
            };
            return finalMessage;
        }
    }
}
