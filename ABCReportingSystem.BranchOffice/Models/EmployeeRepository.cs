using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ABCReportingSystem.BranchOffice.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Employee> GetEmployeeByUsername(string employeeUsername)
        {
            return await _appDbContext.Employees.FirstOrDefaultAsync(e => e.Username == employeeUsername);
        }
    }
}

