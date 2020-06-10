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
    public class LIBRERIASController : Controller
    {
        private ESCUELAEntities db = new ESCUELAEntities();

        public ActionResult Index()
        {
            var lIBRERIAS = db.LIBRERIAS.Include(l => l.LIBRO2).Include(l => l.USUARIO2);
            return View(lIBRERIAS.ToList());
    

    
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIBRERIAS lIBRERIAS = db.LIBRERIAS.Find(id);
            if (lIBRERIAS == null)
            {
                return HttpNotFound();
            }
            return View(lIBRERIAS);
        }

        public ActionResult Create()
        {
            ViewBag.ID_LIBRO = new SelectList(db.LIBRO2, "ID", "NOMBRE");
            ViewBag.NOMBRE_USUARIO = new SelectList(db.USUARIO2, "NOMBRE", "CONTRASEÑA");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE_USUARIO,ID_LIBRO")] LIBRERIAS lIBRERIAS)
        {
            if (ModelState.IsValid)
            {
                db.LIBRERIAS.Add(lIBRERIAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_LIBRO = new SelectList(db.LIBRO2, "ID", "NOMBRE", lIBRERIAS.ID_LIBRO);
            ViewBag.NOMBRE_USUARIO = new SelectList(db.USUARIO2, "NOMBRE", "CONTRASEÑA", lIBRERIAS.NOMBRE_USUARIO);
            return View(lIBRERIAS);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIBRERIAS lIBRERIAS = db.LIBRERIAS.Find(id);
            if (lIBRERIAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_LIBRO = new SelectList(db.LIBRO2, "ID", "NOMBRE", lIBRERIAS.ID_LIBRO);
            ViewBag.NOMBRE_USUARIO = new SelectList(db.USUARIO2, "NOMBRE", "CONTRASEÑA", lIBRERIAS.NOMBRE_USUARIO);
            return View(lIBRERIAS);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE_USUARIO,ID_LIBRO")] LIBRERIAS lIBRERIAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lIBRERIAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_LIBRO = new SelectList(db.LIBRO2, "ID", "NOMBRE", lIBRERIAS.ID_LIBRO);
            ViewBag.NOMBRE_USUARIO = new SelectList(db.USUARIO2, "NOMBRE", "CONTRASEÑA", lIBRERIAS.NOMBRE_USUARIO);
            return View(lIBRERIAS);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIBRERIAS lIBRERIAS = db.LIBRERIAS.Find(id);
            if (lIBRERIAS == null)
            {
                return HttpNotFound();
            }
            return View(lIBRERIAS);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LIBRERIAS lIBRERIAS = db.LIBRERIAS.Find(id);
            db.LIBRERIAS.Remove(lIBRERIAS);
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
