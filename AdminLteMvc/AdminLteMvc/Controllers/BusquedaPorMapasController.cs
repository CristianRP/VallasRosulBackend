using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminLteMvc.Controllers
{
    public class BusquedaPorMapasController : Controller
    {
        // GET: BusquedaPorMapas
        public ActionResult BusquedaPorMapaIndex()
        {
            ViewData["Nombre"] = Session["nombre"];
            ViewData["Apellido"] = Session["apellido"];
            return View();
        }
    }
}