using HR_Management.Application.DTOs.Common;
using HR_Management.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.DTOs
{
    public class LeaveAllocationDTO :BaseDTO
    {
        public int NumberOfDays { get; set; }
        public LeaveAllocationDTO LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
