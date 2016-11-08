using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tutatu.Models;

namespace tutatu.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.ACTIVO = "login";
            return View();
        }

        //GET: WEBUSER
        public ActionResult webuser()
        {
            ViewBag.ACTIVO = "login";
            return View();
        }

        //POST: WEBUSER
        [HttpPost]
        public ActionResult webuser(string nick, string pass)
        {
            
            


            return RedirectToAction("Index");
        }

    }
}