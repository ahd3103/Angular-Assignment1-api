using EmployeeManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class EFDbContext:DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options)
         : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
    
}
