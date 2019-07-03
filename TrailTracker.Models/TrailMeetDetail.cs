using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailTracker.Data;

namespace TrailTracker.Models
{
    public class TrailMeetDetail
    {
        [Display(Name = "Trail Tracker ID")]
        public int TrailTrackerID { get; set; }
        public TrailType OfTrailType { get; set; }
        public string Picture { get; set; }
        public bool JoinTrail { get; set; }
        [Display(Name = "Meetup Time")]
        public DateTime MeetTime { get; set; }
        public string MeetComments { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
        public override string ToString() => $"[{TrailTrackerID}] {OfTrailType} {Picture} {JoinTrail} {MeetTime} {MeetComments}";
    }
}
