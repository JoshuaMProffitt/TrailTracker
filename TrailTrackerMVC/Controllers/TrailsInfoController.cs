using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailTracker.Data;
using TrailTracker.Models;
using TrailTracker.Services;

namespace TrailTrackerMVC.Controllers
{ //1
    [Authorize]
    public class TrailsInfoController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: TrailInfo 2 3
        public ActionResult Index()
        {
            //4
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrailsInfoService(userId);
            var model = service.GetTrailsInfos();
            return View(model);
        }
        // GET 
        [HttpGet]
        public ActionResult Create()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());
            var TrailsInfoService = new TrailsInfoService(userId);

            //var TrailService = new TrailService(userId);

            //var TrailsInfos = TrailService.GetTrails();

            ViewBag.TrailTrackerID = new SelectList(TrailsInfoService.GetTrails(), "TrailTrackerID", "TrailName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrailsInfoCreate model)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            if (!ModelState.IsValid) return View(model);
            var service = CreateTrailsInfoService();
            //var trailService = new TrailService(userId);
            if (service.CreateTrailsInfo(model))
            {
                TempData["SaveResult"] = "Your trail info was added.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Trail Info could not be added.");
            ViewBag.TrailTrackerID = new SelectList(service.GetTrails(), "TrailTrackerID", "TrailName", model.TrailTrackerID);
            return View(model);
        }
        private TrailsInfoService CreateTrailsInfoService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrailsInfoService(userId);
            return service;
        }
        public ActionResult Details(int id)
        {
            var svc = CreateTrailsInfoService();
            var model = svc.GetTrailsInfoById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateTrailsInfoService();
            var detail = service.GetTrailsInfoById(id);
            var model =
                new TrailsInfoEdit
                {
                    TrailTrackerID = detail.TrailTrackerID,
                    TrailInfoID = detail.TrailInfoID,
                    //TrailName = detail.Trail.TrailName,
                    Rating = detail.Rating,
                    TrailComments = detail.TrailComments,
                    NoteableSites = detail.NoteableSites
                };
            ViewBag.TrailTrackerID = new SelectList(_db.Trails.ToList(), "TrailTrackerID", "TrailName");
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TrailsInfoEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TrailInfoID != id)
            {
                ModelState.AddModelError("", "Id Missmatch");
                return View(model);
            }

            var service = CreateTrailsInfoService();

            if (service.UpdateTrailsInfo(model))
            {
                TempData["SaveResult"] = "Your Trail Info was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your trail info could not be updated.");
            return View();
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTrailsInfoService();
            var model = svc.GetTrailsInfoById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTrailsInfoService();

            service.DeleteTrail(id);

            TempData["SaveResult"] = "Your trail info was deleted";

            return RedirectToAction("Index");
        }
    }
}