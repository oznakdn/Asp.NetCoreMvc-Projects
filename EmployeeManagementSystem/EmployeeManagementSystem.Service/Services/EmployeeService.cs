using AutoMapper;
using EmployeeManagementSystem.Service.Models.Entities;
using EmployeeManagementSystem.Service.Models.ViewModels;
using EmployeeManagementSystem.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeCreateVM> AddAsync(EmployeeCreateVM createVM)
        {
            var employee = _mapper.Map<Employee>(createVM);
            await _employeeRepository.AddAsync(employee);
            return createVM;
        }

        public async Task<IEnumerable<EmployeeListVM>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return _mapper.Map<List<EmployeeListVM>>(employees);
        }

        public async Task<Employee> GetByFullname(string firstName,string lastName)
        {
            return await _employeeRepository.GetByFullname(firstName,lastName);
        }

       

        public async Task<EmployeeListVM> GetByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetAsync(x => x.Id == id);
            return _mapper.Map<EmployeeListVM>(employee);
            
        }

        public async Task RemoveAsync(Guid id)
        {
            await _employeeRepository.RemoveAsync(id);
        }

        public async Task<Employee> UpdateAsync(Guid id,EmployeeEditVM editVM)
        {
            var employee = await _employeeRepository.GetAsync(x => x.Id == id);
            employee.Firstname = editVM.Firstname;
            employee.Lastname = editVM.Lastname;
            employee.Gender = editVM.Gender;
            employee.PhotoUrl = editVM.PhotoUrl;
            employee.Department = editVM.Department;
            employee.StartDate = editVM.StartDate;

            await _employeeRepository.UpdateAsync(employee);
            return employee;
        }
    }
}
