using EmployeeManagementSystem.Service.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Service.Repositories
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        Task<Employee> GetByFullname(string firstName,string lastName);
    }
}
