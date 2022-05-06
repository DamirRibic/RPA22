using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrvaMVC.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Pozdravljen(string ime, int st=3)
        {
            ViewBag.Message = "Pozdravljen " + ime;
            ViewBag.Num = st;
            return View();
        }
        
    }
}