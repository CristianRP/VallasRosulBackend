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
    public class PublicidadsController : Controller
    {
        private PublicidadEntities_ db = new PublicidadEntities_();

        // GET: Publicidads
        public ActionResult Index()
        {
            var publicidad = db.Publicidad.Include(p => p.Contrato).Include(p => p.Proyectos_Ubicaciones).Include(p => p.ZonaGeografica);
            return View(publicidad.ToList());
        }

        // GET: Publicidads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicidad publicidad = db.Publicidad.Find(id);
            if (publicidad == null)
            {
                return HttpNotFound();
            }
            return View(publicidad);
        }

        // GET: Publicidads/Create
        public ActionResult Create()
        {
            ViewBag.CodigoContrato = new SelectList(db.Contrato, "CodigoContrato", "Descripcion");
            ViewBag.CodigoProyecto = new SelectList(db.Proyectos_Ubicaciones, "CodigoProyecto", "Descripcion");
            ViewBag.CodigoZona = new SelectList(db.ZonaGeografica, "CodigoZona", "Descripcion");
            return View();
        }

        // POST: Publicidads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoPublicidad,Descripcion,Latitud,Longitud,Estado,CodigoProyecto,CodigoContrato,Alto,Ancho,Direccion,FechaCambioImagen,imagen,Demo,CodigoZona,CodigoBusqueda,Calendario_Periodo")] Publicidad publicidad)
        {
            if (ModelState.IsValid)
            {
                db.Publicidad.Add(publicidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoContrato = new SelectList(db.Contrato, "CodigoContrato", "Descripcion", publicidad.CodigoContrato);
            ViewBag.CodigoProyecto = new SelectList(db.Proyectos_Ubicaciones, "CodigoProyecto", "Descripcion", publicidad.CodigoProyecto);
            ViewBag.CodigoZona = new SelectList(db.ZonaGeografica, "CodigoZona", "Descripcion", publicidad.CodigoZona);
            return View(publicidad);
        }

        // GET: Publicidads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicidad publicidad = db.Publicidad.Find(id);
            if (publicidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoContrato = new SelectList(db.Contrato, "CodigoContrato", "Descripcion", publicidad.CodigoContrato);
            ViewBag.CodigoProyecto = new SelectList(db.Proyectos_Ubicaciones, "CodigoProyecto", "Descripcion", publicidad.CodigoProyecto);
            ViewBag.CodigoZona = new SelectList(db.ZonaGeografica, "CodigoZona", "Descripcion", publicidad.CodigoZona);
            return View(publicidad);
        }

        // POST: Publicidads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoPublicidad,Descripcion,Latitud,Longitud,Estado,CodigoProyecto,CodigoContrato,Alto,Ancho,Direccion,FechaCambioImagen,imagen,Demo,CodigoZona,CodigoBusqueda,Calendario_Periodo")] Publicidad publicidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoContrato = new SelectList(db.Contrato, "CodigoContrato", "Descripcion", publicidad.CodigoContrato);
            ViewBag.CodigoProyecto = new SelectList(db.Proyectos_Ubicaciones, "CodigoProyecto", "Descripcion", publicidad.CodigoProyecto);
            ViewBag.CodigoZona = new SelectList(db.ZonaGeografica, "CodigoZona", "Descripcion", publicidad.CodigoZona);
            return View(publicidad);
        }

        // GET: Publicidads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicidad publicidad = db.Publicidad.Find(id);
            if (publicidad == null)
            {
                return HttpNotFound();
            }
            return View(publicidad);
        }

        // POST: Publicidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publicidad publicidad = db.Publicidad.Find(id);
            db.Publicidad.Remove(publicidad);
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

        public ActionResult Test()
        {
            return View();
        }
    }
}
