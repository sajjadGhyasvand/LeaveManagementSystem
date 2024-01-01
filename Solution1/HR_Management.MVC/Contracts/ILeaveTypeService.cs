﻿using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Contracts
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVM>> GetLeaveTypes();
        Task<LeaveTypeVM> GetLeaveTypeDetails(int id);
        Task<Response<int>> CreateLeaveType(LeaveTypeVM leaveType);
        Task UpdateLeaveType(LeaveTypeVM leaveeType);
        Task DeleteLeaveType(LeaveTypeVM leaveeType);
    }
}
