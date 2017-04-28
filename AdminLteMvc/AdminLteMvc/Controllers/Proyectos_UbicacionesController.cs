using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminLteMvc;

namespace AdminLteMvc.Controllers
{
    public class Proyectos_UbicacionesController : Controller
    {
        private PublicidadEntities_ db = new PublicidadEntities_();

        // GET: Proyectos_Ubicaciones
        public ActionResult Index()
        {
            return View(db.Proyectos_Ubicaciones.ToList());
        }

        // GET: Proyectos_Ubicaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyectos_Ubicaciones proyectos_Ubicaciones = db.Proyectos_Ubicaciones.Find(id);
            if (proyectos_Ubicaciones == null)
            {
                return HttpNotFound();
            }
            return View(proyectos_Ubicaciones);
        }

        // GET: Proyectos_Ubicaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proyectos_Ubicaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoProyecto,CodigoExterno,Descripcion")] Proyectos_Ubicaciones proyectos_Ubicaciones)
        {
            if (ModelState.IsValid)
            {
                db.Proyectos_Ubicaciones.Add(proyectos_Ubicaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proyectos_Ubicaciones);
        }

        // GET: Proyectos_Ubicaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyectos_Ubicaciones proyectos_Ubicaciones = db.Proyectos_Ubicaciones.Find(id);
            if (proyectos_Ubicaciones == null)
            {
                return HttpNotFound();
            }
            return View(proyectos_Ubicaciones);
        }

        // POST: Proyectos_Ubicaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoProyecto,Descripcion")] Proyectos_Ubicaciones proyectos_Ubicaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyectos_Ubicaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proyectos_Ubicaciones);
        }

        // GET: Proyectos_Ubicaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyectos_Ubicaciones proyectos_Ubicaciones = db.Proyectos_Ubicaciones.Find(id);
            if (proyectos_Ubicaciones == null)
            {
                return HttpNotFound();
            }
            return View(proyectos_Ubicaciones);
        }

        // POST: Proyectos_Ubicaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proyectos_Ubicaciones proyectos_Ubicaciones = db.Proyectos_Ubicaciones.Find(id);
            db.Proyectos_Ubicaciones.Remove(proyectos_Ubicaciones);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
