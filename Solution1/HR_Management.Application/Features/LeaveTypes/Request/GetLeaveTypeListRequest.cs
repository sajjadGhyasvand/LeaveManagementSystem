using HR_Management.Application.DTOs;
using MediatR;
namespace HR_Management.Application.Features.LeaveTypes.Request
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDTO>>
    {
    }
}
