﻿using FluentValidation;
using HR_Management.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDTOValidator : AbstractValidator<ILeaveRequestDTO>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public ILeaveRequestDTOValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;

            RuleFor(p => p.StartDate).LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");
            RuleFor(p => p.EndDate).GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");
            RuleFor(p => p.LeaveTypeId).GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var leaveTypeExist = await _leaveRequestRepository.Exist(id);
                return !leaveTypeExist;
            }).WithMessage("{PropertyName} does not exist.}");
        }
    }
}
