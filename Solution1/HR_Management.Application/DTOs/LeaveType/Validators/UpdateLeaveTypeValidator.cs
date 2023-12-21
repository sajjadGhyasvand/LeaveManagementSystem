using FluentValidation;

namespace HR_Management.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveTypeValidator : AbstractValidator<LeaveTypeDTO>
    {
        public UpdateLeaveTypeValidator()
        {
            Include(new ILeaveTypeDTOValidator());
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}
