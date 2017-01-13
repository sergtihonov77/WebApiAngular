using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiAngular.Models;

namespace WebApiAngular.Controllers
{
    public class HomeController : Controller
    {
        public PetsOwnerController poc = new PetsOwnerController();
        public PetsController pet = new PetsController();

        public ActionResult Index()
        {

            ViewBag.Title = "Home Page";

            return View();
        }
    }

}
