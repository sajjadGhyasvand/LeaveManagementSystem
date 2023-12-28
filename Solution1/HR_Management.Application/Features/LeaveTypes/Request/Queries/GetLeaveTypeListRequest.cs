using HR_Management.Application.DTOs.LeaveAllocation;
using HR_Management.Application.DTOs.LeaveType;
using MediatR;
namespace HR_Management.Application.Features.LeaveTypes.Request.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDTO>>
    {
    }
}
