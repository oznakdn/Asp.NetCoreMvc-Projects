using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Service.Models.Base
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
    }
}
