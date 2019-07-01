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

        public ActionResult Details(int id)
        {
            var svc = CreateTrailService();
            var model = svc.GetTrailById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTrailService();
            var detail = service.GetTrailById(id);
            var model =
                new TrailEdit
                {
                    TrailTrackerID = detail.TrailTrackerID,
                    TrailName = detail.TrailName,
                    Description = detail.Description,
                    Miles = detail.Miles,
                    Location = detail.Location,
                    Difficulty = detail.Difficulty,
                    Elevation = detail.Elevation,
                    SpotsAvailable = detail.SpotsAvailable,
                    AverageTimeMinutes = detail.AverageTimeMinutes
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TrailEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.TrailTrackerID != id)
            {
                ModelState.AddModelError("", "Id Missmatch");
                return View(model);
            }

            var service = CreateTrailService();

            if (service.UpdateTrail(model))
            {
                TempData["SaveResult"] = "Your trail was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your trail could not be updated.");
            return View();
        }
    }
}