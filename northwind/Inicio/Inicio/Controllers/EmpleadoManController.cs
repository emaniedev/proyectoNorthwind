using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inicio.Negocio;
using Inicio.Entidades;

namespace Inicio.Controllers
{
    public class EmpleadoManController : Controller
    {

        #region Index()
        // GET: EmpleadoMan
        public ActionResult Index()
        {
            ViewBag.BORRADO = false;
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
                cnEmpleado ocnEmpleado = new cnEmpleado();
                nRegistros = ocnEmpleado.nRegistrosFiltro(Apellido, Nombre);
                if (nRegistros > 0)
                {
                    Session["nRegistrosFiltro"] = nRegistros;
                }


                return RedirectToAction("listaFiltro");//Redirigimos la salida a otro metodo del controlador.
            }
            catch (Exception ex)
            {
                ViewBag.MENSAJE = "Patata con ERROR en EmpleadoManController.Index: " + ex.Message;
                return RedirectToAction("PaginaDeError");
            }
           
        }
        #endregion

        #region listaFiltro()
        public ActionResult listaFiltro(){
            
            List<enEmpleados> lenEmpleados = new List<enEmpleados>();
            try {

                cnEmpleado ocnEmpleado = new cnEmpleado();
                //Utilizamos nuestras variables de session para pasarlas por atributo.
                String apellido = Session["filtroApellido"].ToString();
                String nombre = Session["filtroNombre"].ToString();
                int tPagina = (int) Session["tPagina"];
                int nPagina = (int) Session["nPagina"]; //El offset de SQL comienza en 0.

                lenEmpleados = ocnEmpleado.listarFiltro(tPagina,nPagina,apellido, nombre);

                ViewBag.OK = true;
                ViewBag.DATOS = lenEmpleados;
                ViewBag.COUNT = (int) Session["nRegistrosFiltro"];
                ViewBag.MENSAJE = "Patata Success"; 
            }
            catch (Exception ex){
                ViewBag.MENSAJE = "Patata con ERROR en EmpleadoManController.listaFiltro: " + ex.Message;
                ViewBag.OK = false;
                return RedirectToAction("PaginaDeError");
            }
            return View();
        }

        //Siguiente
        //GET:
        public ActionResult siguientePagina()
        {
            int nPagina = (int)Session["nPagina"];
            int tPagina = (int)Session["tPagina"];
            int registroMostrar = nPagina + tPagina;

            if ((int) Session["nRegistrosFiltro"] > registroMostrar )
            {
                Session["nPagina"] = registroMostrar;
            }

            return RedirectToAction("listaFiltro");
        }

        #endregion

        #region Edit()
        //Mantenimiento
        //Editar
        //GET:

        public ActionResult Edit(int? id)
        {
            enEmpleados oenEmpleados = new enEmpleados();

            try
            {
                cnEmpleado cnEmpleado = new cnEmpleado();
                oenEmpleados = cnEmpleado.consEmpleadoPorId(id);
                ViewBag.OK = true;
                ViewBag.DATOS = oenEmpleados;
                ViewBag.MENSAJE = "Patata Success";
                ViewBag.MODIF = false;
            }
            catch (Exception e)
            {
                ViewBag.MODIF = false;
                ViewBag.OK = false;
                ViewBag.MENSAJE = "Patata con ERROR en EmpleadoManController.Edit: " + e.Message;
                return RedirectToAction("PaginaDeError");
            }


            return View();
        }

        //Mantenimiento
        //Editar
        //POST:
        [HttpPost]
        public ActionResult Edit(int? id, String apellido, String nombre)
        {
            enEmpleados oenEmpleado = new enEmpleados();
            cnEmpleado ocnEmpleado = new cnEmpleado();
            try
            {
                oenEmpleado.IdEmpleado = id;
                oenEmpleado.Apellido = apellido;
                oenEmpleado.Nombre = nombre;

                int resultado = ocnEmpleado.edit(oenEmpleado);

                if (resultado == 1)
                {
                    ViewBag.OK = true;
                    ViewBag.DATOS = oenEmpleado;
                    ViewBag.MENSAJE = "Se ha modificado el registro.";
                    ViewBag.MODIF = true;
                }
                
            }
            catch (Exception e)
            {
                ViewBag.MODIF = false;
                ViewBag.OK = false;
                ViewBag.MENSAJE = "Patata con ERROR en EmpleadoManController.Edit: " + e.Message;
                return RedirectToAction("PaginaDeError");
            }


            return RedirectToAction("listaFiltro");
        }
        #endregion

        #region Borrar()

        //Mantenimiento
        //Borrar
        //GET:

        public ActionResult Borrar(int? ID)
        {
            int resultado = -1;
            ViewBag.BORRADO = false;
            try
            {
                cnEmpleado ocnEmpleado = new cnEmpleado();
                resultado = ocnEmpleado.borrarPorId(ID);
                if (resultado == 1)
                {
                    ViewBag.BORRADO = true;
                    ViewBag.MENSAJE = "Se ha borrado el registro";
                    return View();
                }
                else
                {
                    ViewBag.BORRADO = false;
                    ViewBag.OK = false;
                    ViewBag.Mensaje = "Nos se ha dado de baja";
                }
            }
            catch (Exception ex)
            {
                ViewBag.OK = false;
                ViewBag.Datos = null;
                ViewBag.Mensaje = "Error controlador ConsEmpleadoPorID() = " + ex.Message;
                return RedirectToAction("PaginaDeError");
            }
            return View();
        }

        //Mantenimiento
        //Borrar
        //POST:

        
        #endregion

        #region Altas()

        //Alta empleados


        // GET: EmpleadoMan
        public ActionResult Crear()
        {
            ViewBag.OK = true;
            return View();
        }

        // POST: EmpleadoMan
        [HttpPost]
        public ActionResult Crear(String apellido, String nombre)
        {
            enEmpleados oenEmpleado = new enEmpleados
            {
                Apellido = apellido,
                Nombre = nombre
            };
            int resultado = -1;
            try
            {
                cnEmpleado ocnEmpleado = new cnEmpleado();
                resultado = ocnEmpleado.altaEmpleado(oenEmpleado);
                if (resultado == 1)
                {
                    return RedirectToAction("listaFiltro");
                }
                else
                {
                    ViewBag.OK = false;
                    ViewBag.Mensaje = "No se ha dado de alta";
                }
            }
            catch (Exception ex)
            {
                ViewBag.OK = false;
                ViewBag.Datos = null;
                ViewBag.Mensaje = "Error EmpleadoManController.Crear = " + ex.Message;
            }
            return View();
        }
        #endregion

        public ActionResult Detail (int? id)
        {
            enEmpleados oenEmpleados = new enEmpleados();

            try
            {
                cnEmpleado cnEmpleado = new cnEmpleado();
                oenEmpleados = cnEmpleado.consEmpleadoPorId(id);
                ViewBag.OK = true;
                ViewBag.DATOS = oenEmpleados;
                ViewBag.MENSAJE = "Patata Success";
                ViewBag.MODIF = false;
            }
            catch (Exception e)
            {
                ViewBag.MODIF = false;
                ViewBag.OK = false;
                ViewBag.MENSAJE = "Patata con ERROR en EmpleadoManController.Detail: " + e.Message;
                return RedirectToAction("PaginaDeError");
            }


            return View();
        }
        
    }
    }
