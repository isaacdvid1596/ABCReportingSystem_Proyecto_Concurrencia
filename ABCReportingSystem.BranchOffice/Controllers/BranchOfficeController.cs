using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCReportingSystem.BranchOffice.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABCReportingSystem.BranchOffice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BranchOfficeController : ControllerBase
    {
        private readonly IBranchOfficeRepository _branchOfficeRepository;
        private readonly IAutomobileRepository _automobileRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public BranchOfficeController(IBranchOfficeRepository branchOfficeRepository, IAutomobileRepository automobileRepository, IEmployeeRepository employeeRepository)
        {
            _branchOfficeRepository = branchOfficeRepository;
            _automobileRepository = automobileRepository;
            _employeeRepository = employeeRepository;
        }

        [HttpGet("{branchOfficeId}")]
        public async Task<ActionResult<Models.BranchOffice>> GetBranchOfficeById(int branchOfficeId)
        {
            var result = await _branchOfficeRepository.GetBranchOfficeByIdAsync(branchOfficeId);

            if (result == null)
            {
                return NotFound($"Branch office with id {branchOfficeId} not found");
            }

            return result;
        }
        
        [HttpGet("autos/{automobileId}")]
        public async Task<ActionResult<Automobile>> GetAutomobilesyId(Guid automobileId)
        {
            var result = await _automobileRepository.GetAutomobileByIdAsync(automobileId);

            if (result == null)
            {
                return NotFound($"Automobile with id {automobileId} not found");
            }

            return result;
        }

        [HttpGet("employees/{employeeUsername}")]
        public async Task<ActionResult<Employee>> GetEmployeesByUsername(string employeeUsername)
        {
            var result = await _employeeRepository.GetEmployeeByUsername(employeeUsername);

            if (result == null)
            {
                return NotFound($"Username with username {employeeUsername} not found");
            }

            return result;
        }
    }
}
