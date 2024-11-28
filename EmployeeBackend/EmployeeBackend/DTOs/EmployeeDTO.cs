using System.ComponentModel.DataAnnotations;

namespace EmployeeBackend.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public int Age { get; set; }
    }
}
