using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using inicio.EntidadesNegocio;
using inicio.CapaNegocio;

namespace inicio.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<enEmpleado> lenEmpleado = new List<enEmpleado>();
            try
            {
                cnEmpleado ocnEmpleado = new cnEmpleado();
                lenEmpleado = ocnEmpleado.Listar();
                ViewBag.OK = true;
                ViewBag.Datos = lenEmpleado;
                ViewBag.Mensaje = "";
            }
            catch (Exception ex)
            {
                ViewBag.OK = false;
                ViewBag.Datos = null;
                ViewBag.Mensaje = "Error controlador Lista() = " + ex.Message;
            }
            return View();
        }
    }
}