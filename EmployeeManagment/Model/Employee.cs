using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Model
{
    public class Employee
    {
        //public int Id { get; set; }
        //[Required]
        //public string Name { get; set; }
        //[Required]
        //public string Email { get; set; }
        ////public string Department { get; set; }
        //public Dept Department { get; set; }
        public int Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Display(Name = "Office Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid email format")]
        [Required]
        public string Email { get; set; }


        [Required]

        public Dept? Department { get; set; }

        public string PhotoPath { get; set; }
        //public  int SomeProperty { get; set; }
    }
}
