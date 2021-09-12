using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCReportingSystem.BranchOffice.Models
{
    public class Automobile
    {
        public Guid AutomobileId { get; set; }

        public Guid Vin { get; set; }

        public string Make{ get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int BranchOfficeId { get; set; }
    }
}
