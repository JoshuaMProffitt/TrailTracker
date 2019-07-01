using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailTracker.Models;

namespace TrailTrackerMVC.Controllers
{
    //1
    [Authorize]
    public class TrailController : Controller
    {
        // GET: Trail 2 3
        public ActionResult Index()
        {
            //4
            var model = new TrailListItem[0];
            return View(model);
        }
        // G E T 
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrailCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}