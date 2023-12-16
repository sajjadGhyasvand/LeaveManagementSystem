using HR_Management.Application.DTOs;
using HR_Management.Application.DTOs.LeaveRequest;
using MediatR;
namespace HR_Management.Application.Features.LeaveRequests.Request.Queries
{
    public class GetLeaveRequestsListRequest : IRequest<List<LeaveRequestDTO>>
    {
    }
}
