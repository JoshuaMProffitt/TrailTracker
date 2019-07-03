using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailTracker.Models;
using TrailTracker.Services;

namespace TrailTrackerMVC.Controllers
{ //1
    [Authorize]
    public class TrailsInfoController : Controller
    {
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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrailsInfoCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTrailsInfoService();

            if (service.CreateTrailsInfo(model))
            {
                TempData["SaveResult"] = "Your trail info was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Trail Info could not be added.");

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
                    TrailInfoID = detail.TrailInfoID,
                    Rating = detail.Rating,
                    TrailComments = detail.TrailComments,
                    NoteableSites = detail.NoteableSites
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TrailsInfoEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.TrailInfoID != id)
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