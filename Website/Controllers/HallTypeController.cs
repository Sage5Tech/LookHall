using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class HallTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /HallType/
        public ActionResult Index()
        {
            return View(db.HallTypes.ToList());
        }

        // GET: /HallType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HallType halltype = db.HallTypes.Find(id);
            if (halltype == null)
            {
                return HttpNotFound();
            }
            return View(halltype);
        }

        // GET: /HallType/Create
        public ActionResult Create(int? hallId)
        {
            if (hallId == null)
            {
                ViewBag.TypeId = new SelectList(db.HallTypes.ToList(), "Id", "Type");
                return View();
            }
            ViewBag.TypeId = new SelectList(db.HallTypes.ToList(), "Id", "Type");
            var hall = db.Halls.Find((int)hallId);
            return View("CreateType", new HallTypeRelation { Hall = hall });
        }

        // POST: /HallType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type")] HallType halltype)
        {
            if (ModelState.IsValid)
            {
                db.HallTypes.Add(halltype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(halltype);
        }

        // GET: /HallType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HallType halltype = db.HallTypes.Find(id);
            if (halltype == null)
            {
                return HttpNotFound();
            }
            return View(halltype);
        }

        // POST: /HallType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type")] HallType halltype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(halltype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(halltype);
        }

        // GET: /HallType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HallType halltype = db.HallTypes.Find(id);
            if (halltype == null)
            {
                return HttpNotFound();
            }
            return View(halltype);
        }

        // POST: /HallType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HallType halltype = db.HallTypes.Find(id);
            db.HallTypes.Remove(halltype);
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
