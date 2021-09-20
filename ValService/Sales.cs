using System;
using System.Collections.Generic;
using System.Text;

namespace ValService
{
    public class Sales
    {
        public string Username { get; set; }

        public Guid AutomobileId { get; set; }

        public double Price { get; set; }

        public Guid Vin { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid BuyerId { get; set; }

        public int DivisionId { get; set; }
    }
}
