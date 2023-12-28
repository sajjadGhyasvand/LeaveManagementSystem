using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain;
using Microsoft.VisualStudio.TestPlatform.Common.Exceptions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.UnitTest.Mocks
{
    public static class MockRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>()
            {
                new LeaveType() {
                    Id = 1,
                   DefaultDay = 1,
                   Name = "Test",
                },
                new LeaveType()
                {
                    Id = 2,
                    DefaultDay = 2, 
                    Name = "Test2",
                }
            };
            var mockRepo = new Mock<ILeaveTypeRepository>();
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(leaveTypes);
            mockRepo.Setup(r => r.Add(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) => {
            leaveTypes.Add(leaveType);
                return leaveType;
            });
            return mockRepo;
        }
    }
}
