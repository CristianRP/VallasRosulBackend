using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminLteMvc.Models;

namespace AdminLteMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //Fletes_Vista_Fletes_Tarifas_Result result = new Fletes_Vista_Fletes_Tarifas_Result();
            //result.

           
            //if (Session["admin"] == null)
            //{
            //    return RedirectToAction("Login", "Account");
            //    //@Html.ActionLink("Create", "SetPassword")
            //}

            //ViewBag.Title = "El Frutal C.C.";

            //ViewData["Nombre"] = Session["nombre"];
            //ViewData["Apellido"] = Session["apellido"];

            return View();
             
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}