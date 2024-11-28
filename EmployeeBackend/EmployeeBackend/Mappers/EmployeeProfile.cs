using AutoMapper;
using EmployeeBackend.DTOs;
using EmployeeBackend.Models;

namespace EmployeeBackend.Mappers
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
