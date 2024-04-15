using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BOL;

namespace BSP_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string password)
        {

            BSP_CUSTOMER customer = UserManager.validateCustomer(email, password);
            if (customer!=null)
            {
                Session["customer"] = customer;
                return RedirectToAction("HomePage", "Customer");
            }
            else
            {
                return View(); //Back To LoginPage
            }
            
        }

    }
     
}