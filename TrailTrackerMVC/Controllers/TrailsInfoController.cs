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
            return View();
        }
    }
}