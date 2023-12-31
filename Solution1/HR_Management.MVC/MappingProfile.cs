﻿using AutoMapper;
using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateLeaveTypeDTO, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveTypeDTO, LeaveTypeVM>().ReverseMap();
            
        }
    }
}
