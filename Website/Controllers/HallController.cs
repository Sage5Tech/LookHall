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
    [Authorize]
    public class HallController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Hall/
        public ActionResult Index()
        {
            var halls = db.Halls.Include(h => h.Venue);
            return View(halls.ToList());
        }

        // GET: /Hall/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall hall = db.Halls.Find(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            return View(hall);
        }

        // GET: /Hall/Create
        public ActionResult Create(int? venueId)
        {
            if (venueId == null)
            {
                ViewBag.VenueId = new SelectList(db.Venues.ToList(), "Id", "Name");
                return View("CreateHall");
            }
            var venue = db.Venues.Find((int)venueId);

            return View(new Hall { Venue = venue });


        }

        // POST: /Hall/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HallId,VenueId,Name,Price,Numberofperson")] Hall hall)
        {
            if (ModelState.IsValid)
            {
                db.Halls.Add(hall);
                db.SaveChanges();

                return RedirectToAction("Create", "HallType", new { hallId = db.Halls.Where(m => m.VenueId == hall.VenueId && m.Name == hall.Name).First().HallId });
            }

            ViewBag.VenueId = new SelectList(db.Venues, "Id", "Name", hall.VenueId);
            return View(hall);
        }

        // GET: /Hall/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall hall = db.Halls.Find(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            ViewBag.VenueId = new SelectList(db.Venues, "Id", "Name", hall.VenueId);
            return View(hall);
        }

        // POST: /Hall/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HallId,VenueId,Name,Price,Numberofperson")] Hall hall)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hall).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VenueId = new SelectList(db.Venues, "Id", "Name", hall.VenueId);
            return View(hall);
        }

        // GET: /Hall/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall hall = db.Halls.Find(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            return View(hall);
        }

        // POST: /Hall/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hall hall = db.Halls.Find(id);
            db.Halls.Remove(hall);
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
