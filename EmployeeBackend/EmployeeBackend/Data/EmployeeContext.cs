using EmployeeBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeBackend.Data
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
