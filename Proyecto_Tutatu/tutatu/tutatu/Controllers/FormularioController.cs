using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tutatu.Models;
using System.Web.Mvc;

namespace tutatu.Controllers
{
    public class FormularioController : Controller
    {
        // GET: Formulario
        public ActionResult Index()
        {
            return View();
        }
        //GET: WEBUSER
        public ActionResult webuser()
        {
            return View();
        }

        //POST: WEBUSER
        [HttpPost]
        public ActionResult webuser(string nick, string pass, string nombre, string apellido, string mail, DateTime fecha, string sexo)
        {
            EFwebuser omWebuser = new EFwebuser();
            try
            {
                omWebuser.crearWebUser(nick, pass, nombre, apellido, mail, fecha, sexo);
            }
            catch (Exception e)
            {
                ViewBag.MENSAJE =  e.Message;
                return View("paginaError");
               
            }
           

            return RedirectToAction("Index");
        }

        //GET: EMPRESA
        public ActionResult empresa()
        {
            return View();
        }

        //POST: Empresa
        [HttpPost]
        public ActionResult empresa(string nick, string pass, string nombre, string cif, string direccion, string telefono, string propietario, string email, string web, string serv, string trayectoria)
        {
            EFempresa omEmpresa = new EFempresa();
            try
            {
                omEmpresa.crearEmpresa(nick, pass, nombre, cif, direccion, telefono, propietario, email, web, serv, trayectoria);
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