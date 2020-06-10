using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class USUARIO2Controller : Controller
    {
        private ESCUELAEntities db = new ESCUELAEntities();

        
        public ActionResult Index()
        {
            return View(db.USUARIO2.ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO2 uSUARIO2 = db.USUARIO2.Find(id);
            if (uSUARIO2 == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO2);
        }

        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NOMBRE,CONTRASEÑA")] USUARIO2 uSUARIO2)
        {
            if (ModelState.IsValid)
            {
                db.USUARIO2.Add(uSUARIO2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uSUARIO2);
        }

       
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO2 uSUARIO2 = db.USUARIO2.Find(id);
            if (uSUARIO2 == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO2);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NOMBRE,CONTRASEÑA")] USUARIO2 uSUARIO2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uSUARIO2);
        }

        
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO2 uSUARIO2 = db.USUARIO2.Find(id);
            if (uSUARIO2 == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO2);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            USUARIO2 uSUARIO2 = db.USUARIO2.Find(id);
            db.USUARIO2.Remove(uSUARIO2);
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
