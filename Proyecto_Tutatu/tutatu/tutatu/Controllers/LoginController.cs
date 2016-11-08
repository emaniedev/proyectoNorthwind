using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            EFwebuser omWebuser = new EFwebuser();
            try
            {
                omWebuser.crearWebUser(nick, pass, nombre, apellido, mail, fecha, sexo);
            }
            catch (Exception e)
            {
                ViewBag.MENSAJE = e.Message;
                return View("paginaError");

            }


            return RedirectToAction("Index");
        }

    }
}