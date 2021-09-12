using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCReportingSystem.Gateway.Models;

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
                Description = "Error 1"
            },
            new Error()
            {
                ErrorId = 2,
                Description = "Error 2"
            },
            new Error()
            {
                ErrorId = 3,
                Description = "Error 3"
            }
        };

        private static readonly List<Transaction> Transactions = new List<Transaction>
        {
            new Transaction()
            {
                TransactionId = new Guid("1e8adbf8-1109-4f3e-bb2e-0bf278259022"),
                Errors = Errors
            }
        };


        [HttpGet]
        public ActionResult<Transaction> Get()
        {
            return Ok(Transactions);
        }

    }
}
