using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCReportingSystem.BranchOffice.DTOs;
using ABCReportingSystem.BranchOffice.Models;
using Microsoft.EntityFrameworkCore;

namespace ABCReportingSystem.BranchOffice.Models
{
    public class BranchOfficeRepository : IBranchOfficeRepository
    {
        private readonly AppDbContext _appDbContext;

        public BranchOfficeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<BranchOffice> GetBranchOfficeByIdAsync(int branchOfficeId)
        {
            return await _appDbContext.BranchOffices.FirstOrDefaultAsync(b => b.BranchOfficeId == branchOfficeId);
        }
    }
}
