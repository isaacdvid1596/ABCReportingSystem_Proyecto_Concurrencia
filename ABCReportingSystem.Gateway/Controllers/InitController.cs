using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using ABCReportingSystem.Gateway.Models;
using RabbitMQ.Client;

namespace ABCReportingSystem.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InitController : ControllerBase
    {

        //list of errors

        private static readonly List<Error> Errors = new List<Error>
        {
            new Error()
            {
                ErrorId = 1,
                Description = "El empleado no existe en la sucursal"
            },
            new Error()
            {
                ErrorId = 2,
                Description = "El auto no existe en la sucursal"
            },
            new Error()
            {
                ErrorId = 3,
                Description = "El VIN del auto no es valido"
            },
            new Error()
            {
                ErrorId = 4,
                Description = "El apellido y ID del comprador esta vacio"
            }
        };

        private static readonly List<Transaction> Transactions = new List<Transaction>
        {
            new Transaction()
            {
                TransactionId = Guid.NewGuid(),
                Errors = Errors
            }
        };

        [HttpGet]
        public ActionResult<Transaction> Get()
        {

            var transaction = Transactions;
            Transaction body = null;

            foreach (var t in transaction)
            {
                body = t;
            }

            var binFormatter = new BinaryFormatter();
            var mStream = new MemoryStream();
            binFormatter.Serialize(mStream,body.TransactionId);
            var transac = mStream.ToArray();
                
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost", Port = 5672 };

                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare("transaction", false, false, false, null);
                        channel.BasicPublish(string.Empty,"transaction",null,transac);
                    }
                }

                return Ok(body.TransactionId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
