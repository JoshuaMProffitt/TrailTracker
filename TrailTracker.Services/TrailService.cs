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
                    Created = DateTimeOffset.Now
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
                                    Created = e.Created
                                }
                               );
                return query.ToArray();
            }
        }
    }
}
