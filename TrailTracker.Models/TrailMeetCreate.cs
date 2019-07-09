using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailTracker.Data;

namespace TrailTracker.Models
{
    public class TrailMeetCreate
    {
        public int TrailMeetID { get; set; }
        public int TrailTrackerID { get; set; }
        [Display(Name = "Trail Name")]
        public string TrailName { get; set; }
        public TrailType OfTrailType { get; set; }
        public string Picture { get; set; }
        [Display(Name = "Meet Time")]
        public DateTime MeetTime { get; set; }
        [Display(Name = "Meet Comments")]
        public string MeetComments { get; set; }
        public override string ToString() => Picture;
    }
}
