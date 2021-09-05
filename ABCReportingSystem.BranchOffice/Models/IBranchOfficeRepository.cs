using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCReportingSystem.BranchOffice.DTOs;

namespace ABCReportingSystem.BranchOffice.Models
{
    public interface IBranchOfficeRepository
    {
        Task<BranchOffice> GetBranchOfficeByIdAsync(int branchOfficeId);
    }
}
