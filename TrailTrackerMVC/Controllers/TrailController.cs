using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailTracker.Models;
using TrailTracker.Services;

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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrailService(userId);
            var model = service.GetTrails();
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
            if (!ModelState.IsValid) return View(model);

            var service = CreateTrailService();

            if (service.CreateTrail(model))
            {
                TempData["SaveResult"] = "Your trail was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Trail could not be added.");

            return View(model);
        }

        private TrailService CreateTrailService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrailService(userId);
            return service;
        }
    }
}