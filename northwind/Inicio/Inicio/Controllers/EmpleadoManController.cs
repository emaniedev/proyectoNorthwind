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
                ViewBag.MENSAJE = "Error en: " + ex.Message;
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
                ViewBag.MENSAJE = "Error patata: " + ex.Message;
                ViewBag.OK = false;
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
                cnEmpleado cnEmpleado = new Negocio.cnEmpleado();
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
                ViewBag.MENSAJE = "Patata con ERROR: " + e.Message;

            }


            return View();
        }

        //Mantenimiento
        //Editar
        //POST:
        [HttpPost]
        public ActionResult Edit(int? id, String apellido, String nombre)
        {
            try
            {
                enEmpleados oenEmpleado = new enEmpleados();
                cnEmpleado ocnEmpleado = new cnEmpleado();

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

            }


            return RedirectToAction("listaFiltro");
        }
        #endregion

        #region Borrar()

        //Mantenimiento
        //Borrar
        //GET:

        public ActionResult Borrar(int? id)
        {
            enEmpleados oenEmpleados = new enEmpleados();

            try
            {
                cnEmpleado cnEmpleado = new Negocio.cnEmpleado();
                oenEmpleados = cnEmpleado.consEmpleadoPorId(id);
                ViewBag.OK = true;
                ViewBag.DATOS = oenEmpleados;
                ViewBag.MENSAJE = "Patata Success";
                ViewBag.MODIF = false;
                ViewBag.RESULTADO = 0;
            }
            catch (Exception e)
            {
                ViewBag.MODIF = false;
                ViewBag.OK = false;
                ViewBag.MENSAJE = "Patata con ERROR: " + e.Message;

            }


            return View();
        }

        //Mantenimiento
        //Borrar
        //POST:

        [HttpPost]//Ponemos esta etiqueta para que sea un post. Por defecto es get.
        public ActionResult Borrar(int id)
        {
            int resultado = -1;
            try
            {
                cnEmpleado ocnEmpleado = new cnEmpleado();
                resultado = ocnEmpleado.borrarPorId(id);
                ViewBag.RESULTADO = resultado;
                if (resultado == 1)
                {
                    return View();
                }
                else
                {
                    ViewBag.MODIF = false;
                    ViewBag.MENSAJE = "Error en: Post de la action Borrar ( int? id)";
                    return RedirectToAction("PaginaDeError");
                }
            }
            catch (Exception ex)
            {
                ViewBag.MODIF = false;
                ViewBag.MENSAJE = "Error en: " + ex.Message;
                return RedirectToAction("PaginaDeError");
            }

        }
        #endregion
    }
}