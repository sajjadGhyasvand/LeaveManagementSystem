using AutoMapper;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Application.Features.LeaveTypes.Handlers.Queries;
using HR_Management.Application.Features.LeaveTypes.Request.Queries;
using HR_Management.Application.Profiles;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.UnitTest.LeaveTypes.Queries
{
    public class GetLeaveTypeListRequestHandlerTests
    {
        IMapper _mapper;
        Mock<ILeaveTypeRepository> _mockRepository;
        public GetLeaveTypeListRequestHandlerTests()
        {
            _mockRepository = HR_Management.UnitTest.Mocks.MockRepository.GetLeaveTypeRepository();
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypeListRequestHandler(_mockRepository.Object,_mapper);
            var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);
            result.ShouldBeOfType<List<LeaveTypeDTO>>();
            result.Count.ShouldBe(2);
        }
    }
}
