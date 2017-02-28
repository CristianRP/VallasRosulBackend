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
    public class ContratoesController : Controller
    {
        private PublicidadEntities_ db = new PublicidadEntities_();

        // GET: Contratoes
        public ActionResult Index()
        {
            var contrato = db.Contrato.Include(c => c.Proveedores).Include(c => c.Proyectos_Ubicaciones);
            return View(contrato.ToList());
        }

        // GET: Contratoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // GET: Contratoes/Create
        public ActionResult Create()
        {
            ViewBag.CodigoProveedor = new SelectList(db.Proveedores, "Codigo", "Nombre");
            ViewBag.CodigoProyecto = new SelectList(db.Proyectos_Ubicaciones, "CodigoProyecto", "Descripcion");
            return View();
        }

        // POST: Contratoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoContrato,Descripcion,FechaInicio,FechaFIn,CodigoProveedor,CodigoProyecto,Estado,Precio")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Contrato.Add(contrato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoProveedor = new SelectList(db.Proveedores, "Codigo", "Nombre", contrato.CodigoProveedor);
            ViewBag.CodigoProyecto = new SelectList(db.Proyectos_Ubicaciones, "CodigoProyecto", "Descripcion", contrato.CodigoProyecto);
            return View(contrato);
        }

        // GET: Contratoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoProveedor = new SelectList(db.Proveedores, "Codigo", "Nombre", contrato.CodigoProveedor);
            ViewBag.CodigoProyecto = new SelectList(db.Proyectos_Ubicaciones, "CodigoProyecto", "Descripcion", contrato.CodigoProyecto);
            return View(contrato);
        }

        // POST: Contratoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoContrato,Descripcion,FechaInicio,FechaFIn,CodigoProveedor,CodigoProyecto,Estado,Precio")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contrato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoProveedor = new SelectList(db.Proveedores, "Codigo", "Nombre", contrato.CodigoProveedor);
            ViewBag.CodigoProyecto = new SelectList(db.Proyectos_Ubicaciones, "CodigoProyecto", "Descripcion", contrato.CodigoProyecto);
            return View(contrato);
        }

        // GET: Contratoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: Contratoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contrato contrato = db.Contrato.Find(id);
            db.Contrato.Remove(contrato);
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
