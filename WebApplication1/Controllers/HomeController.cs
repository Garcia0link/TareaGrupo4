using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "En esta pagina podremos Crear, Leer, Actualizar y Borrar las tablas.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Pagina de contacto";

            return View();
        }
    }
}