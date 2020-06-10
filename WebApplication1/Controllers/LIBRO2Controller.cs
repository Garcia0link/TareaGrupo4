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
    public class LIBRO2Controller : Controller
    {
        private ESCUELAEntities db = new ESCUELAEntities();

        
        public ActionResult Index()
        {
            return View(db.LIBRO2.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIBRO2 lIBRO2 = db.LIBRO2.Find(id);
            if (lIBRO2 == null)
            {
                return HttpNotFound();
            }
            return View(lIBRO2);
        }

        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,AUTOR,FECHA")] LIBRO2 lIBRO2)
        {
            if (ModelState.IsValid)
            {
                db.LIBRO2.Add(lIBRO2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lIBRO2);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIBRO2 lIBRO2 = db.LIBRO2.Find(id);
            if (lIBRO2 == null)
            {
                return HttpNotFound();
            }
            return View(lIBRO2);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,AUTOR,FECHA")] LIBRO2 lIBRO2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lIBRO2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lIBRO2);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIBRO2 lIBRO2 = db.LIBRO2.Find(id);
            if (lIBRO2 == null)
            {
                return HttpNotFound();
            }
            return View(lIBRO2);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LIBRO2 lIBRO2 = db.LIBRO2.Find(id);
            db.LIBRO2.Remove(lIBRO2);
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
