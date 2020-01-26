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
    }
}
