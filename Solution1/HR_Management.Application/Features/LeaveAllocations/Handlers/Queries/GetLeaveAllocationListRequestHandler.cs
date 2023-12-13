using AutoMapper;
using HR_Management.Application.DTOs;
using HR_Management.Application.Features.LeaveAllocations.Request.Queries;
using HR_Management.Application.Features.LeaveTypes.Request.Queries;
using HR_Management.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationListRequestHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDTO>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationListRequestHandler(ILeaveTypeRepository leaveTypeRepository,IMapper mapper)
        {
           _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }


        public async Task<List<LeaveAllocationDTO>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypeList = await _leaveTypeRepository.GetAll();
            return _mapper.Map<List<LeaveAllocationDTO>>(leaveTypeList); 
        }
    }
}
