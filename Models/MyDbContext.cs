using Microsoft.EntityFrameworkCore;
using EF_Core_Code_FirstDemo.VM;
using EF_Core_Code_FirstDemo.DTO;

namespace EF_Core_Code_FirstDemo.Models
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions options):base(options) 
        {
                
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }  
        public DbSet<EF_Core_Code_FirstDemo.DTO.DepartmentDTO> DepartmentDTO { get; set; } = default!;
       
    }
}
