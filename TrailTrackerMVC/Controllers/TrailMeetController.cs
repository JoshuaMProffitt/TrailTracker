using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailTracker.Models;

namespace TrailTrackerMVC.Controllers
{
    [Authorize]
    public class TrailMeetController : Controller
    {
        // GET: TrailMeet
        public ActionResult Index()
        {
            var model = new TrailMeetListItem[0];
            return View(model);
        }
        // GET
        public ActionResult Create()
        {
            return View();
        }
    }
}