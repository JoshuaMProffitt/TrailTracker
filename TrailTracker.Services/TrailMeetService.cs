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
        public TrailMeetDetail GetTrailMeetById(int trailId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TrailMeets
                        .Single(e => e.TrailTrackerID == trailId && e.OwnerID == _userId);
                return
                    new TrailMeetDetail
                    {
                        TrailTrackerID = entity.TrailTrackerID,
                        OfTrailType = entity.OfTrailType,
                        Picture = entity.Picture,
                        MeetTime = entity.MeetTime,
                        MeetComments = entity.MeetComments,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateTrailMeet(TrailMeetEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TrailMeets
                        .Single(e => e.TrailTrackerID == model.TrailTrackerID && e.OwnerID == _userId);
                entity.OfTrailType = model.OfTrailType;
                entity.Picture = model.Picture;
                entity.JoinTrail = model.JoinTrail;
                entity.MeetTime = model.MeetTime;
                entity.MeetComments = model.MeetComments;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTrailMeet(int TrailMeetId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TrailMeets
                        .Single(e => e.TrailTrackerID == TrailMeetId && e.OwnerID == _userId);

                ctx.TrailMeets.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

