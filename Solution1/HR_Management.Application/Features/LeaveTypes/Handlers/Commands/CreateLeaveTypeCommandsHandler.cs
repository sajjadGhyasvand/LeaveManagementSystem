﻿using AutoMapper;
using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Features.LeaveTypes.Request.Commands;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain;
using MediatR;
using System.ComponentModel.DataAnnotations;
using HR_Management.Application.Responses;

namespace HR_Management.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandsHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        private readonly IMapper _mapper;
        public CreateLeaveTypeCommandsHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            #region Validations
            var validator = new ILeaveTypeDTOValidator();
            var ValidationResult = await validator.ValidateAsync(request.LeaveTypeDTO);
            if (ValidationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = " Creation Filed";
                response.Errors = ValidationResult.Errors.Select(e=>e.ErrorMessage).ToList();
                /*throw new HR_Management.Application.Exception.ValidationException(ValidationResult);*/
               
            }
            else
            {
                var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDTO);
                leaveType = await _leaveTypeRepository.Add(leaveType);
                response.Success = true;
                response.Message = " Creation Success";
                response.Id = leaveType.Id;
            }
            #endregion
            return response;
        }
    }
}
