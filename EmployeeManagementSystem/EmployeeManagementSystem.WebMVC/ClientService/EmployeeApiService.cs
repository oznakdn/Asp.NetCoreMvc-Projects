using EmployeeManagementSystem.WebMVC.Models.ViewModels;
using System.Net.Http.Headers;

namespace EmployeeManagementSystem.WebMVC.ClientService
{
    
    public class EmployeeApiService
    {
        private readonly HttpClient _httpClient;
       
        public EmployeeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
           
        }

        public async Task<List<EmployeeListModel>>GetAllAsync()
        {
            var response =await _httpClient.GetFromJsonAsync<List<EmployeeListModel>>("employees");
            return response;
        }

        public async Task<EmployeeListModel>GetByFullname(string firstName,string lastName)
        {
            var response = await _httpClient.GetFromJsonAsync<EmployeeListModel>($"employees/{firstName}+{lastName}");
            return response;
        }

        public async Task<EmployeeListModel> GetByIdAsync(Guid id)
        {
            var response = await _httpClient.GetFromJsonAsync<EmployeeListModel>($"employees/{id}");
            return response;
        }

        public async Task<EmployeeCreateModel>AddAsync(EmployeeCreateModel createModel)
        {
           await _httpClient.PostAsJsonAsync("employees", createModel);
           return createModel;
        }

        public async Task<EmployeeEditModel>UpdateAsync(Guid id,EmployeeEditModel editModel)
        {
            await _httpClient.PutAsJsonAsync<EmployeeEditModel>($"employees/{id}", editModel);
            return editModel;
        }
        public async Task<string> RemoveAsync(Guid id)
        {
            var response= await _httpClient.DeleteAsync($"employees/{id}");
            return response.ToString();
        }


    }
}
