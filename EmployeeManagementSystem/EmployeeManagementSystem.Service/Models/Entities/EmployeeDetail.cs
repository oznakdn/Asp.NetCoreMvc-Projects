using EmployeeManagementSystem.Service.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Service.Models.Entities
{
    public class EmployeeDetail : IBaseEntity
    {
        public Guid Id { get; set ; }
        public DateTime BirthDate { get; set; }
        public bool MaritalStatus { get; set; }
        public short ChildCount { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }


        public Guid EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
