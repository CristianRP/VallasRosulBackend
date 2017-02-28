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
    public class ZonaGeograficasController : Controller
    {
        private PublicidadEntities_ db = new PublicidadEntities_();

        // GET: ZonaGeograficas
        public ActionResult Index()
        {
            return View(db.ZonaGeografica.ToList());
        }

        // GET: ZonaGeograficas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZonaGeografica zonaGeografica = db.ZonaGeografica.Find(id);
            if (zonaGeografica == null)
            {
                return HttpNotFound();
            }
            return View(zonaGeografica);
        }

        // GET: ZonaGeograficas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZonaGeograficas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoZona,Descripcion,Estado")] ZonaGeografica zonaGeografica)
        {
            if (ModelState.IsValid)
            {
                db.ZonaGeografica.Add(zonaGeografica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zonaGeografica);
        }

        // GET: ZonaGeograficas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZonaGeografica zonaGeografica = db.ZonaGeografica.Find(id);
            if (zonaGeografica == null)
            {
                return HttpNotFound();
            }
            return View(zonaGeografica);
        }

        // POST: ZonaGeograficas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoZona,Descripcion,Estado")] ZonaGeografica zonaGeografica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zonaGeografica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zonaGeografica);
        }

        // GET: ZonaGeograficas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZonaGeografica zonaGeografica = db.ZonaGeografica.Find(id);
            if (zonaGeografica == null)
            {
                return HttpNotFound();
            }
            return View(zonaGeografica);
        }

        // POST: ZonaGeograficas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZonaGeografica zonaGeografica = db.ZonaGeografica.Find(id);
            db.ZonaGeografica.Remove(zonaGeografica);
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
