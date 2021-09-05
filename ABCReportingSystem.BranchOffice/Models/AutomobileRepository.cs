using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ABCReportingSystem.BranchOffice.Models
{
    public class AutomobileRepository : IAutomobileRepository
    {
        private readonly AppDbContext _appDbContext;

        public AutomobileRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Automobile> GetAutomobileByIdAsync(Guid automobileId)
        {
            return await _appDbContext.Automobiles.FirstOrDefaultAsync(a => a.AutomobileId == automobileId);
        }
    }
}
