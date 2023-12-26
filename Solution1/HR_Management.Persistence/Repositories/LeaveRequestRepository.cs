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
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>,ILeaveRequestRepository
    {
        private readonly LeaveManagementDBContext _context;

        public LeaveRequestRepository(LeaveManagementDBContext context) : base(context) 
        {
            _context = context;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? changeApprovalStatus)
        {
            leaveRequest.Approved = changeApprovalStatus;
            _context.Entry(leaveRequest).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await _context.LeaveRequests.Include(t => t.LeaveType).ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _context.LeaveRequests.Include(t => t.LeaveType).FirstOrDefaultAsync(i => i.Id == id);
            return leaveRequest;
        }
    }
}
