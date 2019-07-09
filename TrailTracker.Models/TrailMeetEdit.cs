using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailTracker.Data;

namespace TrailTracker.Models
{
    public class TrailMeetEdit
    {
        public int TrailMeetID { get; set; }
        [Display(Name = "Trail Tracker ID")]
        public int TrailTrackerID { get; set; }
        [Display(Name = "Trail Name")]
        public string TrailName { get; set; }
        public TrailType OfTrailType { get; set; }
        public string Picture { get; set; }
        [Display(Name = "Join Trail")]
        public bool JoinTrail { get; set; }
        [Display(Name = "Meetup Time")]
        public DateTime MeetTime { get; set; }
        [Display(Name = "Meet Comments")]
        public string MeetComments { get; set; }
    }
}
