using EmployeeManagementSystem.Service.Data;
using EmployeeManagementSystem.Service.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Service.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Employee> GetByFullname(string firstName, string lastName)
        {
            var employee = await _context.Employees.Where(x => x.Firstname.ToLower().Trim() == firstName.ToLower().Trim() && x.Lastname.ToLower().Trim() == lastName.ToLower().Trim()).SingleOrDefaultAsync();
            return employee;
          
        }
    }
}
