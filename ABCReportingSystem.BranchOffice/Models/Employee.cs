using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCReportingSystem.BranchOffice.Models
{
    public class Employee
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid EmployeeId { get; set; }

        public int BranchOfficeId { get; set; }
    }
}
