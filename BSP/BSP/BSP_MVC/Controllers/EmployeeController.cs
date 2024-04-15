using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BOL;

namespace BSP_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult EmployeeLogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeLogIn(string f_name, string password)
        {
            BSP_EMPLOYEE employee =  UserManager.validateEmployee(f_name, password);
            if (employee!=null)
            {
                Session["employee"] = employee;
                return RedirectToAction("HomePage", "Employee");
            }
            else
            {
                return View(); //Back To EmployeeLoginPage
            }
        }

        public ActionResult HomePage()
        {
            BSP_EMPLOYEE employee = null;
            if (TempData["employee"] != null)
            {
                employee = (BSP_EMPLOYEE)TempData["employee"];
            }
            return View(employee);
        }

        public ActionResult AddBike()
        {
            return View();
        }

        public ActionResult AddAppointmentSlot()
        {
            return View();
        }

        
        public ActionResult ShowAppointments()
        {
            return View();
        }

        
        public ActionResult AddJobCard()
        {
            return View();
        }
    }
}