using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailTracker.Data
{
    public class TrailMeet
    {
        public enum TrailType
        {
            Bike = 1, Hike, Run, Other
        }
        [Key]
        public int TrailTrackerID { get; set; }
        [Required]
        public TrailType OfTrailType { get; set; }
        public string Picture { get; set; }
        public bool JoinTrail { get; set; }
        public DateTime MeetTime { get; set; }
        public string MeetComments { get; set; }
    }
}
