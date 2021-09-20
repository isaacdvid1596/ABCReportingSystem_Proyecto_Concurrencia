using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Globalization;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using RabbiMQ.Client;

namespace ABCReportingSystem.RecollectorService
{
  public class Program {
      static void Main(string[] args) {
        Console.log("hola");

        var factory = new ConnectionFactory() { HostName = "localhost" };
        var records = new List<Sales>();

        using (var streamReader = new StreamReader(@"/home/diego/School/Unitec/Periodo8/Concu/proyecto/sales.csv")) {
            using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture)) {
              csvReader.Context.RegisterClassMap<SalesClassMap>();
              records = csvReader.GetRecords<Sales>().ToList();
              Sales[] sales = records.ToArray();
              try{
                using (var connection = factory.CreateConnection()) {
                  int count = records.Count();
                  Task[] tasks = new Task[count / 50 + 1];
                  for(int i = 0; i < tasks.Length; i++){
                    tasks[i] = Task.Factory.StartNew(() => {
                          int max = (i < count / 50) ? 50 : count % 50;
                          for(int j = i * 50; j < i * 50 + max; j++){
                            using (var channel = connection.CreateModel()) {
                              channel.QueueDeclare(queue: i.ToString(),
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);
                              string registro = sales[j].Username + ',' +
                                sales[i].AutomobileId + ',' + 
                                sales[i].Price + ',' + 
                                sales[i].Vin.ToString() +  ',' +
                                sales[i].FirstName + ',' + 
                                sales[i].LastName + ',' + 
                                sales[i].BuyerId.ToString() + ',' + 
                                sales[i].DivisionId.ToString() ;
                              var body = Encoding.UTF8.GetBytes(registro);
                              Console.Write($"thread{i}");
															channel.BasicPublish(exchange: "",
                                routingKey: i.ToString(),
                                basicProperties: null,
                                body: body);
                            }
                          }
                        });
                    }
                }
              }catch(Exception e) {
              }
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
