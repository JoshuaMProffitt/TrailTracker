using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailTracker.Data;

namespace TrailTracker.Models
{
    public class TrailMeetCreate
    {
        public int TrailTrackerID { get; set; }
        public TrailType OfTrailType { get; set; }
        public string Picture { get; set; }
        public DateTime MeetTime { get; set; }
        public string MeetComments { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
