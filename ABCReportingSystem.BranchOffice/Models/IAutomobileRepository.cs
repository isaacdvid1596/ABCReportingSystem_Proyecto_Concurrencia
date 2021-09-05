using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCReportingSystem.BranchOffice.Models
{
    public interface IAutomobileRepository
    {
        Task<Automobile> GetAutomobileByIdAsync(Guid automobileId);
    }
}
