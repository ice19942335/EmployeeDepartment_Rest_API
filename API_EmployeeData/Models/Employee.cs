using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_EmployeeData.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public string Salary { get; set; }
        public string Deplist { get; set; }
    }
}