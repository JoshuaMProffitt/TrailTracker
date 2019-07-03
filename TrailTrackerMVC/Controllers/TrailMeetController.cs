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
    [Authorize]
    public class TrailMeetController : Controller
    {
        // GET: TrailMeet
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrailMeetService(userId);
            var model = service.GetTrailMeets();
            return View(model);
        }
        // GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrailMeetCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTrailMeetService();

            if (service.CreateTrailMeet(model))
            {
                TempData["SaveResult"] = "Your Meet up was Created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Trail Meetup could not be Created.");

            return View(model);
        }
        private TrailMeetService CreateTrailMeetService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrailMeetService(userId);
            return service;
        }
        public ActionResult Details(int id)
        {
            var svc = CreateTrailMeetService();
            var model = svc.GetTrailMeetById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateTrailMeetService();
            var detail = service.GetTrailMeetById(id);
            var model =
                new TrailMeetEdit
                {
                    TrailTrackerID = detail.TrailTrackerID,
                    OfTrailType = detail.OfTrailType,
                    Picture = detail.Picture,
                    MeetTime = detail.MeetTime,
                    MeetComments = detail.MeetComments
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TrailMeetEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TrailTrackerID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTrailMeetService();

            if (service.UpdateTrailMeet(model))
            {
                TempData["SaveResult"] = "Your trail Meetup was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your trail Meetup could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTrailMeetService();
            var model = svc.GetTrailMeetById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTrailMeetService();

            service.DeleteTrailMeet(id);

            TempData["SaveResult"] = "Your trail meetup was deleted.";

            return RedirectToAction("Index");
        }
    }
}