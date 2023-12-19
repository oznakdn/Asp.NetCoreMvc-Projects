using EmployeeManagementSystem.WebMVC.ClientService;
using EmployeeManagementSystem.WebMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmployeeManagementSystem.WebMVC.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly EmployeeApiService _employeeApi;

        public EmployeeController(EmployeeApiService employeeApi)
        {
            _employeeApi = employeeApi;
        }

        public IActionResult Index()
        {

            return View();
        }


        public async Task<JsonResult> GetAll()
        {
            var result =await _employeeApi.GetAllAsync();

            var jsonData = JsonConvert.SerializeObject(result);

            return Json(jsonData);
        }

        public async Task<JsonResult> Get(Guid id)
        {
            var result = await _employeeApi.GetByIdAsync(id);
            return Json(result);
        }

        public async Task<JsonResult> GetByName(string firstName, string lastName)
        {
            var result = await _employeeApi.GetByFullname(firstName, lastName);
            return Json(result);
        }
        public async Task<JsonResult> Remove(Guid id)
        {
            var result = await _employeeApi.RemoveAsync(id);
            return Json(result);
        }

        public async Task<JsonResult> Add(EmployeeCreateModel createModel)
        {

            var result = await _employeeApi.AddAsync(createModel);
            return Json(result);
        }

        public async Task<JsonResult> Update(Guid id,EmployeeEditModel editModel)
        {
            var result = await _employeeApi.UpdateAsync(id, editModel);
            return Json(result);
        }

    }
}
