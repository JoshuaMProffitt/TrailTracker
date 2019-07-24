using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TrailTracker.Models;
using TrailTracker.Services;

namespace TrailTrackerApi.Controllers
{
    [Authorize]
    public class TrailController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            TrailService trailService = CreateTrailService();
            var trails = trailService.GetTrails();
            return Ok(trails);
        }
        public IHttpActionResult Get(int id)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailById(id);
            return Ok(trail);
        }

        public IHttpActionResult Post(TrailCreate trail)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTrailService();

            if (!service.CreateTrail(trail))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(TrailEdit trail)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTrailService();

            if (!service.UpdateTrail(trail))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateTrailService();

            if (!service.DeleteTrail(id))
                return InternalServerError();

            return Ok();
        }
        // GET: Trail
        private TrailService CreateTrailService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var trailService = new TrailService(userId);
            return trailService;
        }
    }
}