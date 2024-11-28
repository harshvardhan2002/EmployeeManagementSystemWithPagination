using AutoMapper;
using EmployeeBackend.DTOs;
using EmployeeBackend.Models;
using EmployeeBackend.NewFolder1;
using EmployeeBackend.Pagination;
using EmployeeBackend.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBackend.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public int AddEmployee(EmployeeDTO employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            _employeeRepository.Add(employee);
            return employee.Id;
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.Get(id);
            if (employee != null)
            {
                _employeeRepository.Delete(employee);
                return true;
            }
            return false;
        }

        public PageList<EmployeeDTO> GetEmployees([FromQuery] PageParameters pageParameters)
        {
            var employees = _employeeRepository.GetAll().OrderBy(e => e.Id);
            var pagedEmployees = PageList<Employee>.ToPagedList(employees, pageParameters.PageNumber, pageParameters.PageSize);
            var employeeDTOs = _mapper.Map<List<EmployeeDTO>>(pagedEmployees);

            return new PageList<EmployeeDTO>(
                employeeDTOs,
                pagedEmployees.TotalCount,
                pagedEmployees.CurrentPage,
                pagedEmployees.PageSize
            );
        }


        public EmployeeDTO GetById(int id)
        {
            var employee = _employeeRepository.Get(id);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public EmployeeDTO Update(EmployeeDTO employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            var existingEmployee = _employeeRepository.GetAll()
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == employee.Id);
            if (existingEmployee != null)
            {
                _employeeRepository.Update(employee);
                return _mapper.Map<EmployeeDTO>(employee);
            }
            return null;
        }
    }
}
