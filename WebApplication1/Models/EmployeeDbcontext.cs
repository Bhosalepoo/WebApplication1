using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class EmployeeDbcontext:DbContext
    {
        public EmployeeDbcontext(DbContextOptions<EmployeeDbcontext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
