using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inicio.Models;

namespace Inicio.Controllers
{
    public class EmpleadoEFController : Controller
    {
        private modelNorthwindEF db = new modelNorthwindEF();

        #region index()
        // GET: EmpleadoEF
        public ActionResult Index()
        {
            Session["tPagina"] = 3;
            Session["nPagina"] = 0;//El offset de SQL comienza en 0.
            return View();
        }
        // POST: EmpleadoMan
        [HttpPost]//Ponemos esta etiqueta para que sea un post. Por defecto es get.
        public ActionResult Index(String Apellido, String Nombre)
        {
            try
            {
                //Usamos las variables de session para mantener nuestro filtro.
                Session["filtroApellido"] = Apellido;
                Session["filtroNombre"] = Nombre;
                int nRegistros = 0;
                modelEmpleadoEF ocnEmpleado = new modelEmpleadoEF();
                nRegistros = ocnEmpleado.nRegistroslistarFiltro(Apellido, Nombre);
                if (nRegistros > 0)
                {
                    Session["nRegistrosFiltro"] = nRegistros;
                }


                return RedirectToAction("listaFiltro");//Redirigimos la salida a otro metodo del controlador.
            }
            catch (Exception ex)
            {
                ViewBag.MENSAJE = "Error en: " + ex.Message;
                return View("paginaError");
            }

        }

        #endregion


        #region Listar 

        //Listar con filtro
        //GET:
        public ActionResult listaFiltro()
        {

            List<Employees> lenEmpleados = new List<Employees>();
            try
            {

                modelEmpleadoEF omEmpleado = new modelEmpleadoEF();
                //Utilizamos nuestras variables de session para pasarlas por atributo.
                String apellido = Session["filtroApellido"].ToString();
                String nombre = Session["filtroNombre"].ToString();
                int tPagina = (int)Session["tPagina"];
                int nPagina = (int)Session["nPagina"]; //El offset de SQL comienza en 0.

                lenEmpleados = omEmpleado.listarFiltro(tPagina, nPagina, apellido, nombre);

                ViewBag.OK = true;
                ViewBag.DATOS = lenEmpleados;
                ViewBag.COUNT = (int)Session["nRegistrosFiltro"];
                ViewBag.MENSAJE = "Patata Success";
                return View();
            }
            catch (Exception ex)
            {

                ViewBag.MENSAJE = "Error patata: " + ex.Message;
                ViewBag.OK = false;
                return View("paginaError");
            }

        }

        //Siguiente
        //GET:
        public ActionResult siguientePagina()
        {
            int nPagina = (int)Session["nPagina"];
            int tPagina = (int)Session["tPagina"];
            int registroMostrar = nPagina + tPagina;

            if ((int)Session["nRegistrosFiltro"] > registroMostrar)
            {
                Session["nPagina"] = registroMostrar;
            }

            return RedirectToAction("listaFiltro");
        }

        #endregion


        public ActionResult paginaError()
        {
            return View();

        }

        //Metodo para Editar

        #region Edit()
        //Mantenimiento
        //Editar
        //GET:

        public ActionResult Edit(int? id)
        {
            Employees oEmployee = new Employees();

            try
            {
                modelEmpleadoEF omEmpleados = new modelEmpleadoEF();
                oEmployee = omEmpleados.consEmpleadoPorId(id);
                ViewBag.OK = true;
                ViewBag.DATOS = omEmpleados;
                ViewBag.MENSAJE = "Patata Success";
                ViewBag.MODIF = false;

                return View();
            }

            catch (Exception e)
            {
                ViewBag.MODIF = false;
                ViewBag.OK = false;
                ViewBag.MENSAJE = "Patata con ERROR: " + e.Message;

                return View("paginaError");
            }


            
        }

        //Mantenimiento
        //Editar
        //POST:
        [HttpPost]
        public ActionResult Edit(int id, String apellido, String nombre)
        {
            try
            {
                Employees oEmployee = new Employees();
                modelEmpleadoEF omEmpleado = new modelEmpleadoEF();

                oEmployee.EmployeeID = id;
                oEmployee.LastName = apellido;
                oEmployee.FirstName = nombre;

                int resultado = omEmpleado.edit(oEmployee);

                if (resultado == 1)
                {

                    ViewBag.OK = true;
                    ViewBag.DATOS = oEmployee;
                    ViewBag.MENSAJE = "Se ha modificado el registro.";
                    ViewBag.MODIF = true;


                }
                else
                {
                    ViewBag.MODIF = false;
                    ViewBag.OK = false;
                    ViewBag.MENSAJE = "No se pudo editar el registro";
                }



            }
            catch (Exception e)
            {
                ViewBag.MODIF = false;
                ViewBag.OK = false;
                ViewBag.MENSAJE = "Patata con ERROR: " + e.Message;

                return View("paginaError");

            }


            return RedirectToAction("listaFiltro");
        }
        #endregion

        //Metodo para Borrar

        #region delete()
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                Employees oEmployee = new Employees();
                modelEmpleadoEF omEmpleado = new modelEmpleadoEF();
                oEmployee = omEmpleado.consEmpleadoPorId(ID);
                int resultado = omEmpleado.delete(oEmployee);

                if (resultado == 1)
                {

                    ViewBag.OK = true;
                    ViewBag.DATOS = oEmployee;
                    ViewBag.MENSAJE = "Se ha borrado el registro.";
                    ViewBag.MODIF = true;


                }
                else
                {
                    ViewBag.MODIF = false;
                    ViewBag.OK = false;
                    ViewBag.MENSAJE = "No se pudo borrar el registro";
                }



            }
            catch (Exception e)
            {
                ViewBag.MODIF = false;
                ViewBag.OK = false;
                ViewBag.MENSAJE = "Patata con ERROR: " + e.Message;

                return View("paginaError");

            }


            return RedirectToAction("listaFiltro");
        }
        #endregion

        //Metodo para mostrar detalles

        #region details()

        //Mantenimiento
        //Editar
        //GET:

        public ActionResult Details(int? id)
        {
            Employees oEmployee = new Employees();

            try
            {
                modelEmpleadoEF omEmpleados = new modelEmpleadoEF();
                oEmployee = omEmpleados.consEmpleadoPorId(id);
                ViewBag.OK = true;
                ViewBag.DATOS = omEmpleados;
                ViewBag.MENSAJE = "Patata Success";
                ViewBag.MODIF = false;

                return View("listaFiltro");
            }

            catch (Exception e)
            {
                ViewBag.MODIF = false;
                ViewBag.OK = false;
                ViewBag.MENSAJE = "Patata con ERROR: " + e.Message;

                return View("paginaError");
            }



        }

        


        #endregion

    }
}
