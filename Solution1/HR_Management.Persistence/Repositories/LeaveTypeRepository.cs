using HR_Management.Application.Persistence.Contracts;
using HR_Management.Domain;
using HR_Management.Persistence;
using HR_Management.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.Responses
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>,ILeaveTypeRepository
    {
        private readonly LeaveManagementDBContext _context;
        public LeaveTypeRepository(LeaveManagementDBContext context) : base(context) 
        {
            _context = context;
        }
    }
}
