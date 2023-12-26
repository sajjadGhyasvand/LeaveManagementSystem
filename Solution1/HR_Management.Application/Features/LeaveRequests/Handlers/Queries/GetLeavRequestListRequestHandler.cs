using AutoMapper;
using HR_Management.Application.DTOs.LeaveRequest;
using HR_Management.Application.Features.LeaveRequests.Request.Queries;
using HR_Management.Application.Contracts.Persistence;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeavRequestListRequestHandler : IRequestHandler<GetLeaveRequestsListRequest, List<LeaveRequestDTO>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeavRequestListRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }


        public async Task<List<LeaveRequestDTO>> Handle(GetLeaveRequestsListRequest request, CancellationToken cancellationToken)
        {
            var leaveRequestsList = await _leaveRequestRepository.GetAll();
            return _mapper.Map<List<LeaveRequestDTO>>(leaveRequestsList);
        }
    }
}
