using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplyee_mvc.DataAccess.Models
{
    public enum Gender { Male, Female }
    public enum EmployeeType { FullTime, PartTime }

    public class Employee
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; } = "";
        [Range(18, 65)]
        public int Age { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; } = "";
        [Phone]
        public string? PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; } = DateTime.UtcNow;
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public EmployeeType EmployeeType { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }
        public bool IsActive { get; set; } = true;


        public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }


        public string? PhotoPath { get; set; }   

        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
