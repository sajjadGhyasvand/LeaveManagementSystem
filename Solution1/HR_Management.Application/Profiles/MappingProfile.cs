using AutoMapper;
using HR_Management.Application.DTOs.LeaveAllocation;
using HR_Management.Application.DTOs.LeaveRequest;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region LeaveRequest
            CreateMap<LeaveRequest,LeaveRequestListDTO>().ReverseMap();
            CreateMap<LeaveRequest,LeaveRequestDTO>().ReverseMap();
            CreateMap<LeaveRequest,CreateLeaveRequestDTO>().ReverseMap();
            CreateMap<LeaveRequest,UpdateLeaveRequestDTO>().ReverseMap();

            #endregion
            #region LeaveAllocation
            CreateMap<LeaveAllocation,LeaveAllocationDTO>().ReverseMap();
            CreateMap<LeaveAllocation,CreateLeaveAllocationDTO>().ReverseMap();
            CreateMap<LeaveAllocation,UpdateLeaveAllocationDTO>().ReverseMap();

            #endregion
            #region LeaveType
            CreateMap<LeaveType,LeaveTypeDTO>().ReverseMap();
            CreateMap<LeaveType,CreateLeaveTypeDTO>().ReverseMap();

            #endregion
        }
    }
}
