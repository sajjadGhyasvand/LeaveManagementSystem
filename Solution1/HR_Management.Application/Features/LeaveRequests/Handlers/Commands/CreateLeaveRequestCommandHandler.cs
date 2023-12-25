using AutoMapper;
using FluentValidation;
using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Features.LeaveRequests.Request.Commands;
using HR_Management.Application.Persistence.Contracts;
using HR_Management.Application.Responses;
using HR_Management.Domain;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDTOValidator(_leaveRequestRepository);
            var ValidationResult = await validator.ValidateAsync(request.LeaveRequestDTO);

            if (ValidationResult != null)
            {
                //    throw new HR_Management.Application.Exception.ValidationException(ValidationResult);
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = ValidationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDTO);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);
            response.Success = true;
            response.Message = "Creation Succesful";
            response.Id = leaveRequest.Id;
            return response;
        }
    }
}
