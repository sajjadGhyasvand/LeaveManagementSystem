using AutoMapper;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Application.Features.LeaveTypes.Handlers.Commands;
using HR_Management.Application.Features.LeaveTypes.Request.Commands;
using HR_Management.Application.Profiles;
using HR_Management.Application.Responses;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.UnitTest.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        IMapper _mapper;
        Mock<ILeaveTypeRepository> _mockRepository;
        CreateLeaveTypeDTO _leaveTypeDTO;
        public CreateLeaveTypeCommandHandlerTests()
        {
            _mockRepository = HR_Management.UnitTest.Mocks.MockRepository.GetLeaveTypeRepository();
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _leaveTypeDTO = new CreateLeaveTypeDTO()
            {
                DefaultDay = 15,
                Name = "Test Create DTO"
            };
        }
        [Fact]
        public async Task CreateLeaveType()
        {
            var handler = new CreateLeaveTypeCommandsHandler(_mockRepository.Object,_mapper);
            var result = await handler.Handle(new CreateLeaveTypeCommand()
            {
                LeaveTypeDTO = _leaveTypeDTO
            }, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse>();
            var leaveTypes = await _mockRepository.Object.GetAll();
            leaveTypes.Count.ShouldBe(3);
        }
    }
}
