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
    }
}