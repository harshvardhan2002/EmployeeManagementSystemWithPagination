using EmployeeBackend.DTOs;
using EmployeeBackend.NewFolder1;
using EmployeeBackend.Pagination;

namespace EmployeeBackend.Services
{
    public interface IEmployeeService
    {
        public PageList<EmployeeDTO> GetEmployees(PageParameters pageParameters);
        public EmployeeDTO GetById(int id);
        public int AddEmployee(EmployeeDTO employee);
        public bool DeleteEmployee(int id);
        public EmployeeDTO Update(EmployeeDTO employeeDto);
    }
}
