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
    }
}