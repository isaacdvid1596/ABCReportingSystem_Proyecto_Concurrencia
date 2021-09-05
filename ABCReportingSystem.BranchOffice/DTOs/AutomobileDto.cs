using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCReportingSystem.BranchOffice.DTOs
{
    public class AutomobileDto
    {
        public Guid AutomobileId { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }
    }
}
