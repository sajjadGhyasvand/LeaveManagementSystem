﻿using AutoMapper;
using HR_Management.Application.Features.LeaveRequests.Request.Commands;
using HR_Management.Application.Features.LeaveTypes.Request.Commands;
using HR_Management.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest =  await _leaveRequestRepository.Get(request.LeaveRequestDTO.Id);
            _mapper.Map(request.LeaveRequestDTO, leaveRequest);
            await _leaveRequestRepository.Update(leaveRequest);
            return Unit.Value;
        }
    }
}
