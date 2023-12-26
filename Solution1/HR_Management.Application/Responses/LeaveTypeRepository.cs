using HR_Management.Application.Persistence.Contracts;
using HR_Management.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.Responses
{
    public class LeaveTypeRepository : HR_Management.Persistence.GenericRepository<LeaveType>,ILeaveTypeRepository
    {
    }
}
