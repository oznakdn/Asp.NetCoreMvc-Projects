using EmployeeManagementSystem.WebMVC.Models.Enums;

namespace EmployeeManagementSystem.WebMVC.Models.ViewModels
{
    public class EmployeeListModel
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string PhotoUrl { get; set; }
        public string Department { get; set; }
        public string StartDate { get; set; }
    }
}
