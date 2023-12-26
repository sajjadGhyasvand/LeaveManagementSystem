using AutoMapper;
using FluentValidation;
using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Features.LeaveRequests.Request.Commands;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.Responses;
using HR_Management.Domain;
using MediatR;
using HR_Management.Application.Contracts.Infrastructure;
using HR_Management.Application.Models;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository,IEmailSender emailSender)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
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

            var email = new Email
            {
                To = "imanMadaeny.Com",
                Subject = "LeaveRequest Submitted",
                Body = $"your leave request for {request.LeaveRequestDTO.StartDate} to {request.LeaveRequestDTO.EndDate} has been submitted!"
            };
            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (System.Exception)
            {
                //log
            }
            return response;
        }
    }
}
