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
    public class EmpleadosController : Controller
    {
        private BarreraEntities db = new BarreraEntities();

        // GET: Empleados
        public ActionResult Index()
        {
            var empleado = db.Empleado.Include(e => e.Empresa).Include(e => e.Puesto).Include(e => e.Departamento).Include(e => e.Empleado2);
            return View(empleado.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.Codigo_Empresa = new SelectList(db.Empresa, "Codigo_Empresa", "Descripcion");
            ViewBag.Codigo_Puesto = new SelectList(db.Puesto, "Codigo_Puesto", "Descripcion");
            ViewBag.Codigo_Departamento = new SelectList(db.Departamento, "CODIGO_DEPARTAMENTO", "Descripcion");
            ViewBag.ReportID = new SelectList(db.Empleado, "Codigo_Empleado", "Primer_Nombre");
            return View();
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo_Empleado,Codigo_Departamento,Codigo_Empresa,Codigo_Puesto,Primer_Nombre,Segundo_Nombre,Primer_Apellido,Segundo_Apellido,Sexo,Telefono,Extension,Correo,Codigo_Empleado_Externo,Estado,ReportID")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Codigo_Empresa = new SelectList(db.Empresa, "Codigo_Empresa", "Descripcion", empleado.Codigo_Empresa);
            ViewBag.Codigo_Puesto = new SelectList(db.Puesto, "Codigo_Puesto", "Descripcion", empleado.Codigo_Puesto);
            ViewBag.Codigo_Departamento = new SelectList(db.Departamento, "CODIGO_DEPARTAMENTO", "Descripcion", empleado.Codigo_Departamento);
            ViewBag.ReportID = new SelectList(db.Empleado, "Codigo_Empleado", "Primer_Nombre", empleado.ReportID);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo_Empresa = new SelectList(db.Empresa, "Codigo_Empresa", "Descripcion", empleado.Codigo_Empresa);
            ViewBag.Codigo_Puesto = new SelectList(db.Puesto, "Codigo_Puesto", "Descripcion", empleado.Codigo_Puesto);
            ViewBag.Codigo_Departamento = new SelectList(db.Departamento, "CODIGO_DEPARTAMENTO", "Descripcion", empleado.Codigo_Departamento);
            ViewBag.ReportID = new SelectList(db.Empleado, "Codigo_Empleado", "Primer_Nombre", empleado.ReportID);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo_Empleado,Codigo_Departamento,Codigo_Empresa,Codigo_Puesto,Primer_Nombre,Segundo_Nombre,Primer_Apellido,Segundo_Apellido,Sexo,Telefono,Extension,Correo,Codigo_Empleado_Externo,Estado,ReportID")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Codigo_Empresa = new SelectList(db.Empresa, "Codigo_Empresa", "Descripcion", empleado.Codigo_Empresa);
            ViewBag.Codigo_Puesto = new SelectList(db.Puesto, "Codigo_Puesto", "Descripcion", empleado.Codigo_Puesto);
            ViewBag.Codigo_Departamento = new SelectList(db.Departamento, "CODIGO_DEPARTAMENTO", "Descripcion", empleado.Codigo_Departamento);
            ViewBag.ReportID = new SelectList(db.Empleado, "Codigo_Empleado", "Primer_Nombre", empleado.ReportID);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleado.Find(id);
            db.Empleado.Remove(empleado);
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
