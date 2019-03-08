using CrudOperationInSinglePageMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOperationInSinglePageMVC.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDBEntities db = new EmployeeDBEntities();


        [HttpGet]
        public ActionResult CreateUpdateEmployee()
        {
            var empData = new EmployeeDTO()
            {
                EmployeeList = db.Employees.ToList()
            };
            return View(empData);
        }

        [HttpPost]
        public ActionResult CreateUpdateEmployee(EmployeeDTO employee)
        {
            if (employee.EmployeeData.EmployeeID == 0)
            {
                db.Employees.Add(employee.EmployeeData);
                db.SaveChanges();
            }
            else
            {
                var dataInDb = db.Employees.FirstOrDefault(a => a.EmployeeID == employee.EmployeeData.EmployeeID);
                dataInDb.Name = employee.EmployeeData.Name;
                dataInDb.Position = employee.EmployeeData.Position;
                dataInDb.Salary = employee.EmployeeData.Salary;
                dataInDb.Age = employee.EmployeeData.Age;
                dataInDb.Salary = employee.EmployeeData.Salary;
                db.SaveChanges();
            }
            
            return RedirectToAction("CreateUpdateEmployee");
        }


        public ActionResult Delete(int id)
        {
            var dataForDelete = db.Employees.FirstOrDefault(a => a.EmployeeID == id);
            db.Employees.Remove(dataForDelete);
            db.SaveChanges();
            return RedirectToAction("CreateUpdateEmployee");
        }

        public ActionResult Edit(int id)
        {
            var empdata = new EmployeeDTO()
            {
                EmployeeList = db.Employees.ToList(),
                EmployeeData = db.Employees.FirstOrDefault(a => a.EmployeeID == id)
            };

            return View("CreateUpdateEmployee", empdata);
        }
    }
}