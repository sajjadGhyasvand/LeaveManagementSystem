using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDBContext _context;
        public LeaveAllocationRepository(LeaveManagementDBContext context):base(context)
        {
            _context = context;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetail()
        {
            var leaveAllocation = await _context.LeaveAllocations.Include(t=>t.LeaveType).ToListAsync();
            return leaveAllocation;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetail(int id)
        {
            var leaveAllocations = await _context.LeaveAllocations.Include(t => t.LeaveType).FirstOrDefaultAsync(i=>i.Id==id);
            return leaveAllocations;
        }
    }
}
