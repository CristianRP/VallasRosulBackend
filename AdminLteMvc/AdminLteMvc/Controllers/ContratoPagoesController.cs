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
    public class ContratoPagoesController : Controller
    {
        private PublicidadEntities_ db = new PublicidadEntities_();

        // GET: ContratoPagoes
        public ActionResult Index()
        {
            var contratoPago = db.ContratoPago.Include(c => c.Contrato);
            return View(contratoPago.ToList());
        }

        // GET: ContratoPagoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoPago contratoPago = db.ContratoPago.Find(id);
            if (contratoPago == null)
            {
                return HttpNotFound();
            }
            return View(contratoPago);
        }

        // GET: ContratoPagoes/Create
        public ActionResult Create()
        {
            ViewBag.Codigo_Contrato = new SelectList(db.Contrato, "CodigoContrato", "Descripcion");
            return View();
        }

        // POST: ContratoPagoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Codigo_Contrato,Fecha,Monto,Pagado,NoFactura")] ContratoPago contratoPago)
        {
            if (ModelState.IsValid)
            {
                db.ContratoPago.Add(contratoPago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Codigo_Contrato = new SelectList(db.Contrato, "CodigoContrato", "Descripcion", contratoPago.Codigo_Contrato);
            return View(contratoPago);
        }

        // GET: ContratoPagoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoPago contratoPago = db.ContratoPago.Find(id);
            if (contratoPago == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo_Contrato = new SelectList(db.Contrato, "CodigoContrato", "Descripcion", contratoPago.Codigo_Contrato);
            return View(contratoPago);
        }

        // POST: ContratoPagoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Codigo_Contrato,Fecha,Monto,Pagado,NoFactura")] ContratoPago contratoPago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contratoPago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Codigo_Contrato = new SelectList(db.Contrato, "CodigoContrato", "Descripcion", contratoPago.Codigo_Contrato);
            return View(contratoPago);
        }

        // GET: ContratoPagoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoPago contratoPago = db.ContratoPago.Find(id);
            if (contratoPago == null)
            {
                return HttpNotFound();
            }
            return View(contratoPago);
        }

        // POST: ContratoPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContratoPago contratoPago = db.ContratoPago.Find(id);
            db.ContratoPago.Remove(contratoPago);
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
