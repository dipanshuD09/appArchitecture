using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efcore.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department department { get; set; }
    }
}