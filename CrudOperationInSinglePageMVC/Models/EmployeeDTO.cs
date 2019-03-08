using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudOperationInSinglePageMVC.Models
{
    public class EmployeeDTO
    {
        public Employee EmployeeData { get; set; }
        public List<Employee> EmployeeList { get; set; }
    }
}