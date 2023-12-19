using EmployeeManagementSystem.Service.Models.ViewModels;
using EmployeeManagementSystem.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{firstName} {lastName}")]
        public async Task<IActionResult>GetByFullname(string firstName,string lastName)
        {
            var result = await _service.GetByFullname(firstName,lastName);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>Get(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            if(result==null)
            {
                return BadRequest("Not Found");
            }

            return Ok(result);
        }

        //[HttpGet]
        //[Route("GetWithDetail")]
        //public async Task<IActionResult>GetAllWithDetail()
        //{
        //    var result = await _service.GetAllWithDetailAsync();
        //    return Ok(result);
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeCreateVM createVM)
        {
            var employee=await _service.AddAsync(createVM);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id,[FromBody] EmployeeEditVM editVM)
        {
            var employeeFind = await _service.GetByIdAsync(id);
            if(employeeFind ==null)
            {
                return BadRequest();
            }

            var employee=await _service.UpdateAsync(id,editVM);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(Guid id)
        {
            var employee=await _service.GetByIdAsync(id);
            if(employee==null)
            {
                return BadRequest();
            }

            await _service.RemoveAsync(id);
            return Ok();
        }

    }
}
