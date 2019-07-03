using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailTracker.Data;
using TrailTracker.Models;

namespace TrailTracker.Services
{
    public class TrailMeetService
    {
        private readonly Guid _userId;

        public TrailMeetService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateTrailMeet(TrailMeetCreate model)
        {
            var entity =
                new TrailMeet()
                {
                    OwnerID = _userId,
                    OfTrailType = model.OfTrailType,
                    Picture = model.Picture,
                    JoinTrail = model.JoinTrail,
                    MeetTime = model.MeetTime,
                    MeetComments = model.MeetComments,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.TrailMeets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TrailMeetListItem> GetTrailMeets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TrailMeets
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new TrailMeetListItem
                                {
                                    TrailTrackerID = e.TrailTrackerID,
                                    OfTrailType = e.OfTrailType,
                                    Picture = e.Picture,
                                    JoinTrail = e.JoinTrail,
                                    MeetTime = e.MeetTime,
                                    MeetComments = e.MeetComments,
                                    CreatedUtc = e.CreatedUtc
                                }
                      );
                return query.ToArray();
            }
        }
    }
}
