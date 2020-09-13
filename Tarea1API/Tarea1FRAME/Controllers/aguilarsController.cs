using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tarea1FRAME.Models;

namespace Tarea1FRAME.Controllers
{
    public class aguilarsController : Controller
    {
        private DataContext db = new DataContext();
        [Authorize]
        // GET: aguilars
        public ActionResult Index()
        {
            return View(db.aguilars.ToList());
        }
        [Authorize]
        // GET: aguilars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aguilar aguilar = db.aguilars.Find(id);
            if (aguilar == null)
            {
                return HttpNotFound();
            }
            return View(aguilar);
        }
        [Authorize]
        // GET: aguilars/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: aguilars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "aguilar_ID,FriendofAguilar,Place_lista,email,Birthday")] aguilar aguilar)
        {
            if (ModelState.IsValid)
            {
                db.aguilars.Add(aguilar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aguilar);
        }
        [Authorize]
        // GET: aguilars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aguilar aguilar = db.aguilars.Find(id);
            if (aguilar == null)
            {
                return HttpNotFound();
            }
            return View(aguilar);
        }
        [Authorize]
        // POST: aguilars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "aguilar_ID,FriendofAguilar,Place_lista,email,Birthday")] aguilar aguilar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aguilar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aguilar);
        }
        [Authorize]
        // GET: aguilars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aguilar aguilar = db.aguilars.Find(id);
            if (aguilar == null)
            {
                return HttpNotFound();
            }
            return View(aguilar);
        }
        [Authorize]
        // POST: aguilars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            aguilar aguilar = db.aguilars.Find(id);
            db.aguilars.Remove(aguilar);
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
