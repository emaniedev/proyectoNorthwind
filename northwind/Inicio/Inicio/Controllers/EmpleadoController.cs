using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inicio.Entidades;
using System.Data;
using Inicio.Negocio;

namespace Inicio.Datos
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<enEmpleados> lenEmpleados = new List<enEmpleados>();
            
            try{
                cnEmpleado cnEmpleado = new Negocio.cnEmpleado();
                lenEmpleados = cnEmpleado.listar();
                ViewBag.OK = true;
                ViewBag.DATOS = lenEmpleados;
                ViewBag.MENSAJE = "Patata Success"; 
            }
            catch (Exception e){
                ViewBag.OK = false;
                ViewBag.MENSAJE = "Patata con ERROR: " + e.Message;

            }

            
            return View();
        }
    }
}