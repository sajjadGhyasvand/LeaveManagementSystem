using FluentValidation;
using HR_Management.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDTOValidator: AbstractValidator<UpdateLeaveRequestDTO>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public UpdateLeaveRequestDTOValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;

            Include(new ILeaveRequestDTOValidator(leaveRequestRepository));
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}
