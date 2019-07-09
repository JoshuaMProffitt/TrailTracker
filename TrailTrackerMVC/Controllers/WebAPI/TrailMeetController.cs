using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TrailTracker.Models;
using TrailTracker.Services;

namespace TrailTrackerMVC.Controllers.WebAPI
{
    [Authorize]
    [RoutePrefix("api/TrailMeet")]
    public class TrailMeetController : ApiController
    {
        private bool SetStarState(int trailMeetsId, bool newState)
        {
            // Create the service
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrailMeetService(userId);

            // Get the note
            var detail = service.GetTrailMeetById(trailMeetsId);

            // Create the NoteEdit model instance with the new star state
            var updateTrailMeets =
                new TrailMeetEdit
                {
                    TrailMeetID = detail.TrailMeetID,
                    TrailTrackerID = detail.TrailTrackerID,
                    TrailName = detail.TrailName,
                    OfTrailType = detail.OfTrailType,
                    Picture = detail.Picture,
                    MeetTime = detail.MeetTime,
                    MeetComments = detail.MeetComments,
                    JoinTrail = newState
                };

            // Return a value indicating whether the update succeeded
            return service.UpdateTrailMeet(updateTrailMeets);
        }

        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);
    }
}