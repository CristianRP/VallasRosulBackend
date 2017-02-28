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
    public class Problema_VisitaController : Controller
    {
        private PublicidadEntities_ db = new PublicidadEntities_();

        // GET: Problema_Visita
        public ActionResult Index()
        {
            return View(db.Problema_Visita.ToList());
        }

        // GET: Problema_Visita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problema_Visita problema_Visita = db.Problema_Visita.Find(id);
            if (problema_Visita == null)
            {
                return HttpNotFound();
            }
            return View(problema_Visita);
        }

        // GET: Problema_Visita/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Problema_Visita/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoProblema,Descripcion,Estado")] Problema_Visita problema_Visita)
        {
            if (ModelState.IsValid)
            {
                db.Problema_Visita.Add(problema_Visita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(problema_Visita);
        }

        // GET: Problema_Visita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problema_Visita problema_Visita = db.Problema_Visita.Find(id);
            if (problema_Visita == null)
            {
                return HttpNotFound();
            }
            return View(problema_Visita);
        }

        // POST: Problema_Visita/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoProblema,Descripcion,Estado")] Problema_Visita problema_Visita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(problema_Visita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(problema_Visita);
        }

        // GET: Problema_Visita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problema_Visita problema_Visita = db.Problema_Visita.Find(id);
            if (problema_Visita == null)
            {
                return HttpNotFound();
            }
            return View(problema_Visita);
        }

        // POST: Problema_Visita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Problema_Visita problema_Visita = db.Problema_Visita.Find(id);
            db.Problema_Visita.Remove(problema_Visita);
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
