using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCReportingSystem.BranchOffice.Models
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeByUsername(string employeeUsername);
    }
}
