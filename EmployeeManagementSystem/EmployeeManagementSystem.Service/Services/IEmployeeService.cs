using EmployeeManagementSystem.Service.Models.Entities;
using EmployeeManagementSystem.Service.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Service.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeListVM>> GetAllAsync();
        Task<EmployeeListVM>GetByIdAsync(Guid id);
        Task<Employee> GetByFullname(string firstName,string lastName);
        Task<EmployeeCreateVM> AddAsync(EmployeeCreateVM createVM);
        Task<Employee> UpdateAsync(Guid id,EmployeeEditVM editVM);
        Task RemoveAsync(Guid id);
    }
}
