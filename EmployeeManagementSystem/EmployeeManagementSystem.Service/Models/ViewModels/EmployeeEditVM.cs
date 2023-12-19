using EmployeeManagementSystem.Service.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Service.Models.ViewModels
{
    public class EmployeeEditVM
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool Gender { get; set; }
        public string PhotoUrl { get; set; }
        public Department Department { get; set; }
        public DateTime StartDate { get; set; }
    }
}
