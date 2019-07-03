using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailTracker.Data;
using TrailTracker.Models;

namespace TrailTracker.Services
{
    public class TrailsInfoService
    {
        private readonly Guid _userId;

        public TrailsInfoService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateTrailsInfo(TrailsInfoCreate model)
        {
            var entity =
                new TrailsInfo()
                {
                    OwnerID = _userId,
                    Rating = model.Rating,
                    TrailComments = model.TrailComments,
                    NoteableSites = model.NoteableSites,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.TrailsInfos.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TrailsInfoListItem> GetTrailsInfos()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TrailsInfos
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new TrailsInfoListItem
                                {
                                    TrailInfoID = e.TrailInfoID,
                                    Rating = e.Rating,
                                    TrailComments = e.TrailComments,
                                    NoteableSites = e.NoteableSites,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }
        public TrailsInfoDetail GetTrailsInfoById(int trailId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TrailsInfos
                        .Single(e => e.TrailInfoID == trailId && e.OwnerID == _userId);
                return
                    new TrailsInfoDetail
                    {
                        TrailInfoID = entity.TrailInfoID,
                        Rating = entity.Rating,
                        TrailComments = entity.TrailComments,
                        NoteableSites = entity.NoteableSites,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateTrailsInfo(TrailsInfoEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TrailsInfos
                        .Single(e => e.TrailInfoID == model.TrailInfoID && e.OwnerID == _userId);

                entity.TrailInfoID = model.TrailInfoID;
                entity.Rating = model.Rating;
                entity.TrailComments = model.TrailComments;
                entity.NoteableSites = model.NoteableSites;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTrail(int trailId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx 
                        .TrailsInfos
                        .Single(e => e.TrailInfoID == trailId && e.OwnerID == _userId);

                ctx.TrailsInfos.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
