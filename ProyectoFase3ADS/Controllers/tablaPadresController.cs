using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFase2ADS;
using System.Text.RegularExpressions;

namespace ProyectoFase2ADS.Controllers
{
    public class tablaPadresController : Controller
    {
        private ProyectoFase2ADSEntities db = new ProyectoFase2ADSEntities();

        // GET: tablaPadres
        public ActionResult Index()
        {
            return View(db.tablaPadres.ToList());
        }

        // GET: tablaPadres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tablaPadres tablaPadres = db.tablaPadres.Find(id);
            if (tablaPadres == null)
            {
                return HttpNotFound();
            }
            return View(tablaPadres);
        }

        // GET: tablaPadres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tablaPadres/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,pago,fechaDePago")] tablaPadres tablaPadres)
        {
            Regex regularExpression1 = new Regex(@"^[A-z]{2,30}\s[A-z]{2,20}$|^[A-z]{2,20}\s[A-z]{2,20}\s[A-z]{2,20}$|^[A-z]{2,20}\s[A-z]{2,20}\s[A-z]{2,20}\s[A-z]{2,20}$/gm");
            if (ModelState.IsValid && tablaPadres.pago >= 200 && tablaPadres.pago <= 300 && regularExpression1.IsMatch(tablaPadres.nombre))
            {
                db.tablaPadres.Add(tablaPadres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tablaPadres);
        }

        // GET: tablaPadres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tablaPadres tablaPadres = db.tablaPadres.Find(id);
            if (tablaPadres == null)
            {
                return HttpNotFound();
            }
            return View(tablaPadres);
        }

        // POST: tablaPadres/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,pago,fechaDePago")] tablaPadres tablaPadres)
        {
            Regex regularExpression1 = new Regex(@"^[A-z]{2,30}\s[A-z]{2,20}$|^[A-z]{2,20}\s[A-z]{2,20}\s[A-z]{2,20}$|^[A-z]{2,20}\s[A-z]{2,20}\s[A-z]{2,20}\s[A-z]{2,20}$/gm");
            if (ModelState.IsValid && tablaPadres.pago >= 200 && tablaPadres.pago <= 300 && regularExpression1.IsMatch(tablaPadres.nombre))
            {
                db.Entry(tablaPadres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tablaPadres);
        }

        // GET: tablaPadres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tablaPadres tablaPadres = db.tablaPadres.Find(id);
            if (tablaPadres == null)
            {
                return HttpNotFound();
            }
            return View(tablaPadres);
        }

        // POST: tablaPadres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tablaPadres tablaPadres = db.tablaPadres.Find(id);
            db.tablaPadres.Remove(tablaPadres);
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
