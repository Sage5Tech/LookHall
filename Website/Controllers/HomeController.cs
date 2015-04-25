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
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            SetViewBags();
            List<Venue> result = new List<Venue>();
            List<HallType> res = new List<HallType>();
            var data = db.Venues.Include(m => m.Area).Include(m => m.HallContactDetails).Include(m => m.Halls).ToList();
            if (Request.QueryString["Area"] != null)
            {
                var query = int.Parse(Request.QueryString["Area"]);
                result = result.Union(data.Where(m => m.AreaId == query)).ToList();
            }

            if (Request.QueryString["HallType"] != null)
            {
                var query = int.Parse(Request.QueryString["HallType"]);
                var hallType = db.HallTypes.Find(query);
                var halls = db.Halls.Include(m => m.HallTypes).ToList();
                result = result.Union(data.Where(m => data.Any(x => halls.Any(w => w.HallTypes.Contains(hallType)) == true))).ToList();
            }
            //ViewBag.HallCategory = new SelectList(db.cate.ToList(), "Id", "Name");
            //ViewBag.PriceRange = new SelectList()
            return View(result);
        }

        private void SetViewBags()
        {

            ViewBag.Area = new SelectList(db.Areas.ToList(), "Id", "Name");
            ViewBag.HallType = new SelectList(db.HallTypes.ToList(), "Id", "Type");
        }


        public ActionResult Search()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}