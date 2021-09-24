using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Globalization;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using CsvHelper;
using CsvHelper.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ABCReportingSystem.RecollectorService
{
    public class Program
    {
        static void Main(string[] args)
        {

            var factory = new ConnectionFactory() { HostName = "localhost" };
            var records = new List<Sales>();

            using (var streamReader = new StreamReader(@"C:\Users\isaac\Documents\files\sales.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<SalesClassMap>();
                    records = csvReader.GetRecords<Sales>().ToList();
                    Sales[] sales = records.ToArray();
                    try
                    {
                        using (var connection = factory.CreateConnection())
                        {
                            var _channel = connection.CreateModel();
                            _channel.QueueDeclare(queue: "init",
                                          durable: false,
                                          exclusive: false,
                                          autoDelete: false,
                                          arguments: null);

                            _channel.QueueDeclare(queue: "transaction", //aqui recibo de gateway la transaction id
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

                            int count = records.Count;
                            Task[] tasks = new Task[count / 50 + 1];

                            var body = Encoding.UTF8.GetBytes((count / 50 + 1).ToString());

                            _channel.BasicPublish(exchange: "",
                              routingKey: "init",
                              basicProperties: null,
                              body: body);

                            var consumer = new EventingBasicConsumer(_channel);

                            consumer.Received += (model, ea) => {
                                var body = ea.Body.ToArray();
                                var transactionid = Encoding.UTF8.GetString(body);
                                Console.WriteLine(transactionid);
                                for (int i = 0; i < tasks.Length; i++)
                                {
                                    int current = i;
                                    tasks[i] = Task.Factory.StartNew(() => {
                                        int max = (current < count / 50) ? 50 : count % 50;
                                        for (int j = current * 50; j < current * 50 + max; j++)
                                        {
                                            using (var channel = connection.CreateModel())
                                            {
                                                channel.QueueDeclare(
                                                    queue: current.ToString(),
                                                    durable: false,
                                                    exclusive: false,
                                                    autoDelete: false,
                                                    arguments: null);
                                                string registro_json = JsonSerializer.Serialize(sales[j]);
                                                Console.WriteLine(registro_json);
                                                var body = Encoding.UTF8.GetBytes(registro_json);
                                                channel.BasicPublish(
                                                  exchange: "",
                                                  routingKey: current.ToString(),
                                                  basicProperties: null,
                                                  body: body);
                                            }
                                        }
                                    });
                                }
                            };

                            _channel.BasicConsume(queue: "transaction",
                                                 autoAck: true,
                                                 consumer: consumer);

                            Console.WriteLine("enter to exit");
                            Console.ReadLine();
                            //Task.WaitAll(tasks);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
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
