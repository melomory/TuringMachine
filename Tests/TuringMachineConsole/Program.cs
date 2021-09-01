using System;
using System.Linq;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;


namespace TuringMachineConsole
{
    class Program
    {
        const string data_url = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

        private static async Task<Stream> GetDataStream()
        {
            HttpClient httpClient = new();
            HttpResponseMessage response = await httpClient.GetAsync(data_url, HttpCompletionOption.ResponseHeadersRead);
            return await response.Content.ReadAsStreamAsync();
        }

        private static IEnumerable<string> GetDataLines()
        {
            using var dataStream = GetDataStream().Result;
            using var dataReader = new StreamReader(dataStream);

            while (!dataReader.EndOfStream)
            {
                var line = dataReader.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                yield return line.Replace("Korea,", "Korea -");
            }
        }

        private static DateTime[] GetDates() => GetDataLines()
            .First()
            .Split(',')
            .Skip(4)
            .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
            .ToArray();


        private static IEnumerable<(string Country, string Province, int[] Counts)> GetData()
        {
            var lines = GetDataLines()
                .Skip(1)
                .Select(line => line.Split(','));

            foreach (var row in lines)
            {
                var provinceName = row[0].Trim();
                var countryName = row[1].Trim(' ', '"');
                var counts = row.Skip(5)
                    .Select(int.Parse)
                    .ToArray();
                yield return (countryName, provinceName, counts);
            }

        }

        static void Main(string[] args)
        {
            //WebClient client = new WebClient();

            //HttpClient httpClient = new();

            //HttpResponseMessage response = httpClient.GetAsync(data_url).Result;
            //string stCSV = response.Content.ReadAsStringAsync().Result;


            //foreach (var data_line in GetDataLines())
            //{
            //    Console.WriteLine(data_line);
            //}

            //var dates = GetDates();
            //Console.WriteLine(String.Join("\r\n",dates));


            var russiaData = GetData().First(v => v.Country.Equals("Russia", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine(String.Join("\r\n", GetDates().Zip(russiaData.Counts, (date, count) => $"{date:dd.MM} – {count}")));

            Console.ReadLine();
        }
    }
}
