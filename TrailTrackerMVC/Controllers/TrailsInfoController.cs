using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailTracker.Models;

namespace TrailTrackerMVC.Controllers
{ //1
    [Authorize]
    public class TrailsInfoController : Controller
    {
        // GET: TrailInfo 2 3
        public ActionResult Index()
        {
            //4
            var model = new TrailsInfoListItem[0];
            return View(model);
        }
        // GET 
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrailsInfoCreate model)
        {
            if (!ModelState.IsValid)
            {

            }
            return View(model);
        }

    }
}