using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailTracker.Models
{
    public class TrailEdit
    {
        public int TrailTrackerID { get; set; }
        public string TrailName { get; set; }
        public string Description { get; set; }
        public double Miles { get; set; }
        public string Location { get; set; }
        public int Difficulty { get; set; }
        public int Elevation { get; set; }
        public int SpotsAvailable { get; set; }
        public string AverageTimeMinutes { get; set; }
    }
}
