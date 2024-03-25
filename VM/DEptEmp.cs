using EF_Core_Code_FirstDemo.Models;

namespace EF_Core_Code_FirstDemo.VM
{
    public class DEptEmp
    {
        public int ID { get; set; }
        public List<Department> Department { get; set; }
        public List<Employee> Employee { get; set; }
    }
}
