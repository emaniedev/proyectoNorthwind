using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using inicio.EntidadesNegocio;
using inicio.CapaNegocio;

namespace inicio.Controllers
{
    public class EmpleadoManController : Controller
    {
        //---INDEX--
        #region index
        // GET: EmpleadoMan
        [HttpGet]
        public ActionResult Index()
        {
            Session["TamPagina"] = 3;
            Session["NumRegistro"] = 0;
            ViewBag.OK = true;
            ViewBag.Mensaje = "";
            return View();
        }

        // POST: EmpleadoMan
        [HttpPost]
        public ActionResult Index(String Apellido, String Nombre)
        {
            try
            {
                Session["filtroApellido"] = Apellido;
                Session["filtroNombre"] = Nombre;
                int NumRegistros = 0;
                cnEmpleado ocnEmpleado = new cnEmpleado();
                NumRegistros = ocnEmpleado.NumRegistrosFiltro(Apellido, Nombre);
                if (NumRegistros > 0)
                    Session["NumRegistrosfiltro"] = NumRegistros;
                return RedirectToAction("ListaFiltro");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error filtro: " + ex;
                ViewBag.OK = false;
        //        return RedirectToAction("PaginaDeError");
            }
            return View();
        }
        #endregion
        //---LISTA FILTRO---
        #region listaFiltro
        //GET: listafiltro
        public ActionResult ListaFiltro()
        {
            List<enEmpleado> lenEmpleado = new List<enEmpleado>();
            try
            {
                cnEmpleado ocnEmpleado = new cnEmpleado();
                String Apellido = Session["FiltroApellido"].ToString();
                String Nombre = Session["FiltroNombre"].ToString();
                //      int TamPagina = 3, NumRegistro = 3;
                int TamPagina = (int)Session["TamPagina"];
                int NumRegistro = (int)Session["NumRegistro"];
                lenEmpleado = ocnEmpleado.ListaFiltro(TamPagina, NumRegistro, Apellido, Nombre);
                ViewBag.Datos = lenEmpleado;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error filtro: " + ex;
                ViewBag.OK = false;
     //           return RedirectToAction("PaginaDeError");
            }
            ViewBag.NumRegistrosFiltro = Session["NumRegistrosfiltro"];
            return View();
        }

        // GET: SiguientePagina
        public ActionResult SiguientePagina()
        {
            int NumRegistro = (int)Session["NumRegistro"];
            int TamPagina = (int)Session["TamPagina"];
            int RegistroMostrar = NumRegistro + TamPagina;
            if ((int)Session["NumRegistrosfiltro"] > RegistroMostrar)
            {
                Session["NumRegistro"] = RegistroMostrar;
            }
            return RedirectToAction("ListaFiltro");
        }
        #endregion
        //---EDITAR---

        // GET: EmpleadoMan
        public ActionResult Editar(int? ID)
        {
            enEmpleado oenEmpleado = new enEmpleado();
            try
            {
                cnEmpleado ocnEmpleado = new cnEmpleado();
                oenEmpleado = ocnEmpleado.ConsEmpleadoPorID(ID);
                ViewBag.OK = true;
                ViewBag.Datos = oenEmpleado;
                ViewBag.Mensaje = "";
            }
            catch (Exception ex)
            {
                ViewBag.OK = false;
                ViewBag.Datos = null;
                ViewBag.Mensaje = "Error controlador ConsEmpleadoPorID() = " + ex.Message;
            }
            return View();
        }

        // POST: EmpleadoMan
        [HttpPost]
        public ActionResult Editar(int? ID, String Apellido, String Nombre)
        {
            enEmpleado oenEmpleado = new enEmpleado();
            oenEmpleado.IdEmpleado = ID;
            oenEmpleado.Apellido = Apellido;
            oenEmpleado.Nombre = Nombre;
            try
            {
                cnEmpleado ocnEmpleado = new cnEmpleado();
                int resultado = ocnEmpleado.Editar(oenEmpleado);
                if (resultado == 1)
                {
                    return RedirectToAction("ListaFiltro");
                }
                else
                {
                    ViewBag.OK = false;
                    ViewBag.Mensaje = "Nos se ha modificado el registro";
                }
            }
            catch (Exception ex)
            {
                ViewBag.OK = false;
                ViewBag.Datos = null;
                ViewBag.Mensaje = "Error controlador ConsEmpleadoPorID() = " + ex.Message;
            }
            return View();
        }

        //---BORRAR---

        // GET: EmpleadoMan
        public ActionResult Borrar(int? ID)
        {
            int resultado = -1;
            try
            {
                cnEmpleado ocnEmpleado = new cnEmpleado();
                resultado = ocnEmpleado.BajaEmpleado(ID);
                if (resultado == 1)
                {
                    return RedirectToAction("ListaFiltro");
                }
                else
                {
                    ViewBag.OK = false;
                    ViewBag.Mensaje = "Nos se ha dado de baja";
                }
            }
            catch (Exception ex)
            {
                ViewBag.OK = false;
                ViewBag.Datos = null;
                ViewBag.Mensaje = "Error controlador ConsEmpleadoPorID() = " + ex.Message;
            }
            return View();
        }

        //---DETALLE---

        // GET: EmpleadoMan
        public ActionResult Detalle(int? ID)
        {
            enEmpleado oenEmpleado = new enEmpleado();
            try
            {
                cnEmpleado ocnEmpleado = new cnEmpleado();
                oenEmpleado = ocnEmpleado.ConsEmpleadoPorID(ID);
                ViewBag.OK = true;
                ViewBag.Datos = oenEmpleado;
            }
            catch (Exception ex)
            {
                ViewBag.OK = false;
                ViewBag.Datos = null;
                ViewBag.Mensaje = "Error controlador Detalle(int? ID) = " + ex.Message;
            }
            return View();
        }

        //--CREAR--

        // GET: EmpleadoMan
        [HttpGet]
        public ActionResult Crear()
        {
            ViewBag.OK = true;
            return View();
        }

        // POST: EmpleadoMan
        [HttpPost]
        public ActionResult Crear(String Apellido, String Nombre)
        {
            enEmpleado oenEmpleado = new enEmpleado
            {
                Apellido = Apellido,
                Nombre = Nombre
            };
            int resultado = -1;
            try
            {
                cnEmpleado ocnEmpleado = new cnEmpleado();
                resultado = ocnEmpleado.AltaEmpleado(oenEmpleado);
                if (resultado == 1)
                {
                    return RedirectToAction("ListaFiltro");
                }
                else
                {
                    ViewBag.OK = false;
                    ViewBag.Mensaje = "Nos se ha dado de alta";
                }
            }
            catch (Exception ex)
            {
                ViewBag.OK = false;
                ViewBag.Datos = null;
                ViewBag.Mensaje = "Error controlador Crear(String Apellido, String Nombre) = " + ex.Message;
            }
            return View();
        }
    }
}