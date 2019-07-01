using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailTracker.Data;
using TrailTracker.Models;

namespace TrailTracker.Services
{
    public class TrailService
    {
        private readonly Guid _userId;

        public TrailService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateTrail(TrailCreate model)
        {
            var entity =
                new Trail()
                {
                    OwnerID = _userId,
                    TrailName = model.TrailName,
                    Description = model.Description,
                    Miles = model.Miles,
                    Location = model.Location,
                    Difficulty = model.Difficulty,
                    Elevation = model.Elevation,
                    SpotsAvailable = model.SpotsAvailable,
                    AverageTimeMinutes = model.AverageTimeMinutes,
                    Created = DateTimeOffset.Now,
                    Modified = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Trails.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TrailListItem> GetTrails()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Trails
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new TrailListItem
                                {
                                    TrailTrackerID = e.TrailTrackerID,
                                    TrailName = e.TrailName,
                                    Description = e.Description,
                                    Miles = e.Miles,
                                    Location = e.Location,
                                    Difficulty = e.Difficulty,
                                    Elevation = e.Elevation,
                                    SpotsAvailable = e.SpotsAvailable,
                                    AverageTimeMinutes = e.AverageTimeMinutes,
                                    Created = e.Created,
                                    Modified = e.Modified
                                }
                               );
                return query.ToArray();
            }
        }
        public TrailDetail GetTrailById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trails
                        .Single(e => e.TrailTrackerID == id && e.OwnerID == _userId);
                return
                    new TrailDetail
                    {
                        TrailTrackerID = entity.TrailTrackerID,
                        TrailName = entity.TrailName,
                        Description = entity.Description,
                        Miles = entity.Miles,
                        Location = entity.Location,
                        Difficulty = entity.Difficulty,
                        Elevation = entity.Elevation,
                        SpotsAvailable = entity.SpotsAvailable,
                        AverageTimeMinutes = entity.AverageTimeMinutes,
                        Created = entity.Created,
                        Modified = entity.Modified
                    };
            }
        }
    }
}
