using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tutatu.Models;
using System.Web.Security;

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
        public ActionResult webuser(string nick, string pass, int? recordar)
        {
            bool check = false;
            if (recordar == 1)
            {
                check = true;
            }
            EFwebuser omWebuser = new EFwebuser();
           

            try
            {
                short idu = omWebuser.loguear(nick, pass, check);
                HttpCookie cookie = new HttpCookie("usr", idu.ToString());
                HttpCookie cookien = new HttpCookie("name", omWebuser.saludo(idu).ToString());
                cookie.Expires = DateTime.Now.AddYears(1);
                cookien.Expires = DateTime.Now.AddYears(1);
                HttpCookieCollection cooks = new HttpCookieCollection();
                cooks.Add(cookie);// Crea una cookie con el id del usuario.
                cooks.Add(cookien);// Crea una cookie con el nombre del usuario.
                Response.AppendCookie(cookie);
                Response.AppendCookie(cookien);
                ViewBag.LOGUED = true;
                


                return RedirectToAction("Index", "Admin");
                
            }
            catch (Exception e)
            {

                ViewBag.MENSAJE = "Usuario o contraseña no valida.\r" + e.Message;
                return View("Index");
            }

            
        }

        // GET: Logout
        public ActionResult logout()
        {
            ViewBag.ACTIVO = "login";

            HttpCookie cookie = Request.Cookies.Get("usr");
            cookie.Expires = DateTime.Now.AddDays(-1d);
            Response.AppendCookie(cookie);
            ViewBag.LOGUED = false;

            return View();
        }

    }
}