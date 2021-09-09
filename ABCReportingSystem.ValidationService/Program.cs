using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace ABCReportingSystem.RecollectorService
{
    public class Program
    {
        static void Main(string[] args)
        {

            var records = new List<Sales>();

            using (var streamReader = new StreamReader(@"C:\Users\isaac\Documents\files\sales.csv"))
            {
                
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<SalesClassMap>();
                    records = csvReader.GetRecords<Sales>().ToList();
                }
            }
        }
    }

    public class SalesClassMap : ClassMap<Sales>
    {
        public SalesClassMap()
        {
            Map(m => m.AutomobileId).Name("car_id");
            Map(m => m.BuyerId).Name("buyer_id");
            Map(m => m.DivisionId).Name("division_id");
            Map(m => m.FirstName).Name("buyer_first_name");
            Map(m => m.LastName).Name("buyer_last_name");
            Map(m => m.Price).Name("price");
            Map(m => m.Username).Name("username");
            Map(m => m.Vin).Name("vin");
        }
    }


}
