using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailTracker.Data;

namespace TrailTrackerMVC.Controllers
{
    public class FileController : Controller
    {

        // GET: File
        public ActionResult Index(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var fileToRetrieve = ctx.Photos.Find(id);
                return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
            }

        }
    }
}