using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailTracker.Data;

namespace TrailTracker.Models
{
    public class TrailMeetDetail
    {
        [Display(Name = "Trail Meet ID")]
        public int TrailMeetID { get; set; }
        [Display(Name = "Trail Tracker ID")]
        public int TrailTrackerID { get; set; }
        [Display(Name = "Trail Name")]
        public string TrailName { get; set; }
        public TrailType OfTrailType { get; set; }
        public string Picture { get; set; }
        [Display(Name = "Meetup Time")]
        public DateTime MeetTime { get; set; }
        [Display(Name = "Meet Comments")]
        public string MeetComments { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
        [ForeignKey("Photo")]
        public int PhotoId { get; set; }
        public virtual ICollection<Photo> Files { get; set; }
        public override string ToString() => $"[{TrailMeetID}]  {TrailTrackerID} {TrailName} {OfTrailType} {Picture} {MeetTime} {MeetComments}";
    }
}
