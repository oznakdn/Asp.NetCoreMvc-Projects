using EmployeeManagementSystem.WebMVC.Models.Enums;

namespace EmployeeManagementSystem.WebMVC.Models.ViewModels
{
    public class EmployeeDetailModel
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool Gender { get; set; }
        public string PhotoUrl { get; set; }
        public Department Department { get; set; }
        public DateTime StartDate { get; set; }
    }
}
