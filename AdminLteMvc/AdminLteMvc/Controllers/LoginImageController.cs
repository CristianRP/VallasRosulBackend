using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminLteMvc.Controllers
{
    public class LoginImageController : Controller
    {
        // GET: LoginImage
        public ActionResult LoginImage()
        {
            return View();
        }

        PublicidadEntities_ dba = new PublicidadEntities_();

        [HttpPost]
        public ActionResult LoginImage(string username, string password)
        {
            var supervisor = (from user in dba.Supervisor
                              where user.nombreUsuario.Equals(username)
                              && user.userPassword.Equals(password)
                              select user).FirstOrDefault();

            if (supervisor != null)
            {
                Session["nombre"] = supervisor.primerNombre;
                Session["apellido"] = supervisor.primerApellido;
                return RedirectToAction("BusquedaPorMapaIndex", "BusquedaPorMapas");
            }

            return View();

        }

        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("LoginImage", "LoginImage");
        }

    }
}