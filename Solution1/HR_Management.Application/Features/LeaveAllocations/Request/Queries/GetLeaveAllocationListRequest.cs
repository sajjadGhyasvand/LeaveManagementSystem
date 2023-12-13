using HR_Management.Application.DTOs;
using MediatR;
namespace HR_Management.Application.Features.LeaveAllocations.Request.Queries
{
    public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDTO>>
    {
    }
}
