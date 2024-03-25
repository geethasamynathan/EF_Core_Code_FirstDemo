using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_Code_FirstDemo.DTO
{
    public class EmployeeDTO
    {
       
        public int EmployeeId { get; set; }       
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
