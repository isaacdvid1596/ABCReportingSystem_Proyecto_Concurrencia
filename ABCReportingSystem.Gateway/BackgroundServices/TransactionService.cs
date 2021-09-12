using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ABCReportingSystem.Gateway.BackgroundServices
{
    public class TransactionService : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly EventingBasicConsumer _consumer;

        public TransactionService()
        {
            var factory = new ConnectionFactory() {HostName = "localhost", Port = 5672};

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare("transaction", false, false, false, null);
            _consumer = new EventingBasicConsumer(_channel);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
