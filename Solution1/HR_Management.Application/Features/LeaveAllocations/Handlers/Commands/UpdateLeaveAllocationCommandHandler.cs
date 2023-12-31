﻿using AutoMapper;
using HR_Management.Application.DTOs.LeaveAllocation.Validators;
using HR_Management.Application.Features.LeaveAllocations.Request.Commands;
using HR_Management.Application.Contracts.Persistence;
using MediatR;

namespace HR_Management.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        private readonly IMapper _mapper;
        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDTOValidator(_leaveAllocationRepository);
            /*var ValidationResult = await validator.ValidateAsync(request.LeaveAllocationDTO);

            if (ValidationResult != null)
                throw new Exception();*/
            var leaveAllocation = await _leaveAllocationRepository.Get(request.LeaveAllocationDTO.Id);
            _mapper.Map(request.LeaveAllocationDTO, leaveAllocation);
            await _leaveAllocationRepository.Update(leaveAllocation);
            return Unit.Value;
        }
    }
}
