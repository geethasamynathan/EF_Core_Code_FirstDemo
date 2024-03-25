using Microsoft.AspNetCore.Mvc.ModelBinding;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace EF_Core_Code_FirstDemo.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string  DepartmentName{ get; set; }
        public string Location { get; set; }
        [JsonIgnore]
        public IList<Employee> Employees { get; set; }
    }
}
