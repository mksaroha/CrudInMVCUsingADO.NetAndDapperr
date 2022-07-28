using CrudInMVCUsingADO.Net_Dapper.Models;
using CrudInMVCUsingADO.Net_Dapper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudInMVCUsingADO.Net_Dapper.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmployeeRepository _repository=new EmployeeRepository();

  

        public ActionResult GetAllEmpDetails()
        {
            var employees = _repository.GetAllEmployees();
            return View(employees);
        }
        // GET: Employee/AddEmployee      
        public ActionResult AddEmployee()
        {
            return View();
        }

        // POST: Employee/AddEmployee      
        [HttpPost]
        public ActionResult AddEmployee(EmployeeModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.AddEmployee(obj);
                    ViewBag.Message = "Records added successfully.";
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Bind controls to Update details      
        public ActionResult EditEmpDetails(int id)
        {
            var employee=_repository.GetAllEmployees().Find(x=>x.Id== id); 
            return View(employee);

        }

        // POST:Update the details into database      
        [HttpPost]
        public ActionResult EditEmpDetails(int id, EmployeeModel obj)
        {
            try
            {
                _repository.UpdateEmployee(obj);
                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Delete  Employee details by id      
        public ActionResult Delete(int id)
        {
            try
            {                
                if (_repository.DeleteEmployee(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

                }
                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return RedirectToAction("GetAllEmpDetails");
            }
        }
    }
}