using EmployeeBackend.DTOs;
using EmployeeBackend.Pagination;
using EmployeeBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] PageParameters pageParameters)
        {
            var pagedEmployees = _employeeService.GetEmployees(pageParameters);
            var response = new
            {
                items = pagedEmployees, // List of employees
                totalPages = pagedEmployees.TotalPages,
                currentPage = pagedEmployees.CurrentPage,
                pageSize = pagedEmployees.PageSize,
                totalCount = pagedEmployees.TotalCount,
                hasPrevious = pagedEmployees.HasPrevious,
                hasNext = pagedEmployees.HasNext
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee != null) 
                return Ok(employee);
            return NotFound("Employee not found!");
        }

        [HttpPost]
        public IActionResult Add(EmployeeDTO employeeDTO)
        {
            var id = _employeeService.AddEmployee(employeeDTO);
            return Ok(id);
        }

        [HttpPut]
        public IActionResult Update(EmployeeDTO employeeDTO)
        {
            var updatedEmployee = _employeeService.Update(employeeDTO);
            if (updatedEmployee != null) 
                return Ok(updatedEmployee);
            return NotFound("Employee not found!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_employeeService.DeleteEmployee(id))
                return Ok(new { responseMessage ="Employee deleted successfully!" });
            return NotFound();
        }
    }
}
