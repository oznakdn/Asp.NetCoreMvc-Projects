using AutoMapper;
using EmployeeManagementSystem.Service.Models.Entities;
using EmployeeManagementSystem.Service.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Service.MappingProfiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeListVM>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.ToShortDateString()))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.ToString()))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender == true ? "Female" : "Male"));


            CreateMap<Employee, EmployeeWithDetailListVM>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.ToShortDateString()))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.ToString()))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender == true ? "Female" : "Male"));

            CreateMap<EmployeeCreateVM, Employee>();
            CreateMap<EmployeeEditVM, Employee>();
           
        }
    }
}
