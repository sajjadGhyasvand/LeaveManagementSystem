using AutoMapper;
using HR_Management.Application.Exception;
using HR_Management.Application.Features.LeaveRequests.Request.Commands;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Commands
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand,Unit>
    {
        private readonly ILeaveRequestRepository leaveRequestRepository;
        private readonly IMapper mapper;
        public DeleteLeaveRequestCommandHandler()
        {
            
        }
        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,
           IMapper mapper)
        {
            this.leaveRequestRepository = leaveRequestRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await leaveRequestRepository.Get(request.Id);

          if (leaveRequest == null)
                throw new NotFoundException(nameof(LeaveRequest), request.Id);

            await leaveRequestRepository.Delete(leaveRequest);
            return Unit.Value;
        }
    }
}
