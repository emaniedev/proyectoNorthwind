using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using inicio.Models;

namespace inicio.Controllers
{
    public class EmpleadoEFController : Controller
    {
        private conNorthwind db = new conNorthwind();
        //    private String MensajeError = "";   // Cuando hago un RedirectToAction se pierde el valor
        // GET: EmpleadoEF
        public ActionResult Index()
        {
            Session["TamPagina"] = 3;
            Session["NumRegistro"] = 0;
            return View();
        }
        // POST: EmpleadoEF
        [HttpPost]
        public ActionResult Index(String Apellido, String Nombre)
        {
            try
            {
                Session["filtroApellido"] = Apellido;
                Session["filtroNombre"] = Nombre;
                //  SELECT * FROM Employees WHERE LastName like '%" + Ape + "%' AND FirstName like '%" + Nom + "%'"
                moEmpleadoEF omoEmpleadoEF = new moEmpleadoEF();
                int NumRegistros = omoEmpleadoEF.NumRegistrosfiltro(Apellido, Nombre);

                //       int NumRegistros = (from emp in db.Employees where emp.LastName.Contains(Apellido) && emp.FirstName.Contains(Nombre) select emp).Count();
                Session["NumRegistrosfiltro"] = NumRegistros;
                return RedirectToAction("ListaFiltroEF");
            }
            catch (Exception ex)
            {
                String Mensaje = "Error filtro: " + ex;
                Session["MensajeError"] = Mensaje;
                return RedirectToAction("PaginaDeErrorEF");
         //       return RedirectToAction("PaginaDeErrorEF", new { Mensaje = Mensaje });
            }
        }
            // GET: EmpleadoEF
        public ActionResult ListaFiltroEF()
        {
            try
            {
                String Apellido = Session["FiltroApellido"].ToString();
                String Nombre = Session["FiltroNombre"].ToString(); 
           //           int TamPagina = 3, NumRegistro = 3;
                int TamPagina = (int)Session["TamPagina"];
                int NumRegistro = (int)Session["NumRegistro"];
                moEmpleadoEF omoEmpleadoEF = new moEmpleadoEF();
                List<Employees> listaEmpleados = omoEmpleadoEF.ListarFiltro(TamPagina, NumRegistro, Apellido, Nombre);
                ViewBag.NumRegistrosFiltro = Session["NumRegistrosfiltro"];
                ViewBag.Empleados = listaEmpleados;
                return View();
            }
            catch (Exception ex)
            {
              //  ViewBag.Mensaje = "Error filtro: " + ex;
                String Mensaje = "Error filtro: " + ex;
                Session["MensajeError"] = Mensaje;
                return RedirectToAction("PaginaDeErrorEF");
            } 
        }
   
        // GET: EmpleadoEF/SiguientePagina
        public ActionResult SiguientePagina()
        {
            int NumRegistro = (int)Session["NumRegistro"];
            int TamPagina = (int)Session["TamPagina"];
            int RegistroMostrar = NumRegistro + TamPagina;
            if ((int)Session["NumRegistrosfiltro"] > RegistroMostrar)
            {
                Session["NumRegistro"] = RegistroMostrar;
            }
            return RedirectToAction("ListaFiltroEF");
        }

        // GET: EmpleadoEF
        public ActionResult Index2()
        {
            List<Employees> listaEmpleados = (from emp in db.Employees select emp).ToList();
            ViewBag.empleados = listaEmpleados;
            return View();
        }
        // GET: EmpleadoEF
        public ActionResult EditarEF(int? ID)
        {
            Employees oEmpleado = new Employees();
            try
            {
                moEmpleadoEF omoEmpleado = new moEmpleadoEF();
                oEmpleado = omoEmpleado.ConsEmpleadoPorID(ID);
                ViewBag.Empleado = oEmpleado;
                return View();
            }
            catch (Exception ex)
            {
                String Mensaje = "Error EditarEF: " + ex;
                Session["MensajeError"] = Mensaje;
                return RedirectToAction("PaginaDeErrorEF");
            }
        }

        // POST: EmpleadoEF
        [HttpPost]
        public ActionResult EditarEF(int? ID, String Apellido, String Nombre)
        {
            Employees oEmpleado = new Employees();
            oEmpleado.EmployeeID = (int)ID;
            oEmpleado.LastName = Apellido;
            oEmpleado.FirstName = Nombre;
            try
            {
                moEmpleadoEF omoEmpleado = new moEmpleadoEF();
                omoEmpleado.Editar(oEmpleado);
                return RedirectToAction("ListaFiltroEF");
            }
            catch (Exception ex)
            {
                String Mensaje = "Error EditarEF: " + ex;
                Session["MensajeError"] = Mensaje;
                return RedirectToAction("PaginaDeErrorEF");
            }
        }

        public ActionResult BorrarEF(int? ID)
        {
            try
            {
                moEmpleadoEF omoEmpleado = new  moEmpleadoEF();
                omoEmpleado.BajaEmpleado(ID);
                return RedirectToAction("ListaFiltroEF");
            }
            catch (Exception ex)
            {
                String Mensaje = "Error EditarEF: " + ex;
                Session["MensajeError"] = Mensaje;
                return RedirectToAction("PaginaDeErrorEF");
            }
        }

        public ActionResult DetalleEF(int? ID)
        {
            Employees oEmpleado = new Employees();
            try
            {
                moEmpleadoEF omoEmpleado = new moEmpleadoEF();
                oEmpleado = omoEmpleado.ConsEmpleadoPorID(ID);
                ViewBag.Empleado = oEmpleado;
                return View();
            }
            catch (Exception ex)
            {
                String Mensaje = "Error EditarEF: " + ex;
                Session["MensajeError"] = Mensaje;
                return RedirectToAction("PaginaDeErrorEF");
            }
        }

        // GET: EmpleadoMan
        [HttpGet]
        public ActionResult CrearEF()
        {
            return View();
        }

        // POST: EmpleadoMan
        [HttpPost]
        public ActionResult CrearEF(String Apellido, String Nombre)
        {
            Employees oEmpleado = new Employees
            {
                LastName = Apellido,
                FirstName = Nombre
            };
            try
            {
                moEmpleadoEF omoEmpleado = new moEmpleadoEF();
                omoEmpleado.AltaEmpleado(oEmpleado);
                return RedirectToAction("ListaFiltroEF");
            }
            catch (Exception ex)
            {
                String Mensaje = "Error EditarEF: " + ex;
                Session["MensajeError"] = Mensaje;
                return RedirectToAction("PaginaDeErrorEF");
            }
        }

        //  PaginaDeError
        //  public ActionResult PaginaDeErrorEF(String Mensaje)
        public ActionResult PaginaDeErrorEF()
        {
            String Mensaje = Session["MensajeError"].ToString();
            ViewBag.Mensaje = Mensaje; 
            return View();
        }
    }
}