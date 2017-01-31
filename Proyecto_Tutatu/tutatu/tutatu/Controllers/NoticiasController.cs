using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tutatu.Models;

namespace tutatu.Controllers
{
    public class NoticiasController : Controller
    {
        // GET: Noticias
        public ActionResult Index()
        {
            ViewBag.ACTIVO = "noticia";
            return View();
        }

        // GET: insertar
        public ActionResult insertar()
        {
            ViewBag.ACTIVO = "video";
            ViewBag.OK = false;
            return View();
        }
        [HttpPost]
        // POST: insertar 
        public ActionResult insertar(string asunto, int zona,string txt)
        {

            ViewBag.ACTIVO = "video";
            HttpCookie cookie = Request.Cookies.Get("usr");
            short id = short.Parse( cookie.Value);
            
            
            EFnoticia moNoticia = new EFnoticia();
            moNoticia.crearNoticia(asunto, zona, txt, id);
            ViewBag.MENSAJE = "Se ha añadido la noticia correctamente.";
            return View("Index");
        }


    }
}