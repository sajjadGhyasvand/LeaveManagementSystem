using HR_Management.Application.DTOs.LeaveAllocation;
using HR_Management.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveTypes.Request.Queries
{
    public class GetLeaveTypeDetailRequest : IRequest<LeaveTypeDTO>
    {
        public int Id { get; set; }

    }
}
