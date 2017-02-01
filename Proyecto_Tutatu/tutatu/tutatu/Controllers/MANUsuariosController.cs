using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tutatu.Models;

namespace tutatu.Controllers
{
    public class MANUsuariosController : Controller
    {
        // GET: MANUsuarios
        public ActionResult Index()
        {
            return View();
        }

        // GET:
        public ActionResult mostrarTodosUsuariosWeb()
        {
            EFusuarios oefUsuarios = new EFusuarios();
            List<usuarios> lUsuarios = oefUsuarios.listaUsuarios();

            ViewBag.LISTA = lUsuarios;

            return View("lista");
        }

        // GET:
       
        public ActionResult mostrarInfoWeb(int id)
        {
            EFwebuser oefwebuser = new EFwebuser();

            webuser info = oefwebuser.conseguirUsuario(id);
            
            ViewBag.INFO = info;

            return View("datos");

        }
    }
}