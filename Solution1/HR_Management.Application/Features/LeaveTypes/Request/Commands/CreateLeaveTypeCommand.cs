using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR_Management.Application.DTOs.LeaveType;
namespace HR_Management.Application.Features.LeaveTypes.Request.Commands
{
    public class CreateLeaveTypeCommand : IRequest<int>
    {
        public CreateLeaveTypeDTO LeaveTypeDTO { get; set; }
    }
}
