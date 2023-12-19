using EmployeeManagementSystem.Service.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Service.Models.ViewModels
{
    public class EmployeeWithDetailListVM
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string PhotoUrl { get; set; }
        public string Department { get; set; }
        public string StartDate { get; set; }

        public EmployeeDetail EmployeeDetail { get; set; }
    }
}
