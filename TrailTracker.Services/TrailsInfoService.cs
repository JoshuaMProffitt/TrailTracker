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
                                    TrailTrackerID = e.TrailTrackerID,
                                    Rating = e.Rating,
                                    TrailComments = e.TrailComments,
                                    NoteableSites = e.NoteableSites,
                                    CreatedUtc = e.CreatedUtc,
                                    ModifiedUtc = e.ModifiedUtc
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
