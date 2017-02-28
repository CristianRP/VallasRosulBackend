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
    public class TareasController : Controller
    {
        private BarreraEntities db = new BarreraEntities();

        // GET: Tareas
        public ActionResult Index()
        {
            var tarea = db.Tarea.Include(t => t.Empleado).Include(t => t.Proyecto);
            return View(tarea.ToList());
        }

        // GET: Tareas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        // GET: Tareas/Create
        public ActionResult Create()
        {
            ViewBag.Codigo_Empleado = new SelectList(db.Empleado, "Codigo_Empleado", "Primer_Nombre");
            ViewBag.Codigo_Proyecto = new SelectList(db.Proyecto, "codigo_proyecto", "Descripcion");
            return View();
        }

        // POST: Tareas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo_Tarea,Nombre,Descripcion,Codigo_Empleado,Codigo_Proyecto,Fecha_Creacion,Fecha_Inicio,Fecha_Fin,Padre,Codigo_Empleado_Asignado,Estado")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                db.Tarea.Add(tarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Codigo_Empleado = new SelectList(db.Empleado, "Codigo_Empleado", "Primer_Nombre", tarea.Codigo_Empleado);
            ViewBag.Codigo_Proyecto = new SelectList(db.Proyecto, "codigo_proyecto", "Descripcion", tarea.Codigo_Proyecto);
            return View(tarea);
        }

        // GET: Tareas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo_Empleado = new SelectList(db.Empleado, "Codigo_Empleado", "Primer_Nombre", tarea.Codigo_Empleado);
            ViewBag.Codigo_Proyecto = new SelectList(db.Proyecto, "codigo_proyecto", "Descripcion", tarea.Codigo_Proyecto);
            return View(tarea);
        }

        // POST: Tareas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo_Tarea,Nombre,Descripcion,Codigo_Empleado,Codigo_Proyecto,Fecha_Creacion,Fecha_Inicio,Fecha_Fin,Padre,Codigo_Empleado_Asignado,Estado")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Codigo_Empleado = new SelectList(db.Empleado, "Codigo_Empleado", "Primer_Nombre", tarea.Codigo_Empleado);
            ViewBag.Codigo_Proyecto = new SelectList(db.Proyecto, "codigo_proyecto", "Descripcion", tarea.Codigo_Proyecto);
            return View(tarea);
        }

        // GET: Tareas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        // POST: Tareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarea tarea = db.Tarea.Find(id);
            db.Tarea.Remove(tarea);
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
