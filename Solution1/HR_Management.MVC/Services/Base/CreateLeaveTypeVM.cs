using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HR_Management.MVC.Services.Base
{
    public class CreateLeaveTypeVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name="Default number of days")]
        public int DafaultDay { get; set; }
    }
}
