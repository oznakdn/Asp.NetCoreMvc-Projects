using EmployeeManagementSystem.Service.Models.Base;
using EmployeeManagementSystem.Service.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Service.Models.Entities
{
    public class Employee : IBaseEntity
    {
        public Guid Id { get; set ; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool Gender { get; set; }
        public string PhotoUrl { get; set; }
        public Department Department { get; set; }
        public DateTime StartDate { get; set; }

        //public EmployeeDetail EmployeeDetail { get; set; }


    }
}
