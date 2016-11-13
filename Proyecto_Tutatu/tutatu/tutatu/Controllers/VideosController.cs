using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tutatu.Controllers
{
    public class VideosController : Controller
    {
        // GET: Videos
        public ActionResult Index()
        {
            ViewBag.ACTIVO = "video";
            return View();
        }

        // GET: insertar
        public ActionResult insertar()
        {
            ViewBag.ACTIVO = "video";
            return View();
        }

        // POST: insertar

        public ActionResult insertar(string asunto, string txt)
        {
            ViewBag.ACTIVO = "video";


            return View();
        }



    }
}