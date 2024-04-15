using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BOL;

namespace BSP_MVC.Controllers
{
    public class CustomerController : Controller
    {

        public ActionResult HomePage()
        {
            BSP_CUSTOMER customer = null;
            if (TempData["customer"] != null)
            {
                customer = (BSP_CUSTOMER)TempData["customer"];
            }
            return View(customer);
        }

        public ActionResult SignUp()
        {
            return View();
        }


        //public ActionResult SignUp(string f_name, string l_name, DateTime date_of_birth, string gender,
        //                           double mobile, string email, string password)
        [HttpPost]
        public ActionResult SignUp(BSP_CUSTOMER customer)
        {
            Console.WriteLine(customer);
            CustomerManager.insert(customer);
            return RedirectToAction("SignedUp", "Customer");
        }

        public ActionResult SignedUp()
        {
            return View();
        }

        public ActionResult BookAppointment()
        {
            //BSP_CUSTOMER customer = null;
            //customer = (BSP_CUSTOMER)Session["customer"];
            
            return View(CustomerManager.slot_times());
        }

        [HttpPost]
        public ActionResult BookAppointment(DateTime? date, int? slot)
        {
            //BSP_CUSTOMER customer = null;
            //customer = (BSP_CUSTOMER)Session["customer"];
            Console.WriteLine(slot + " "+ date);
            CustomerManager.BookAppointment(date, slot);
            return RedirectToAction("Booked", "Customer");
        }

        public ActionResult AddAddress()
        {
            //BSP_CUSTOMER customer = null;
            //customer = (BSP_CUSTOMER)Session["customer"];

            return View();
        }

        public ActionResult Booked()
        {
            

            return View();
        }

        public ActionResult AddBike()
        {


            return View();
        }

        public ActionResult ShowAppointments()
        {
            //BSP_CUSTOMER customer = null;
            //customer = (BSP_CUSTOMER)Session["customer"];

            return View();
        }

    }
}