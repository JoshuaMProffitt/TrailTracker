using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailTracker.Models
{
    public class TrailDetail
    {
        [Display(Name = "Trail Tracker ID")]
        public int TrailTrackerID { get; set; }
        [Display(Name = "Trail Name")]
        public string TrailName { get; set; }
        public string Description { get; set; }
        public double Miles { get; set; }
        public string Location { get; set; }
        public int Difficulty { get; set; }
        public int Elevation { get; set; }
        [Display(Name = "Spots Available")]
        public int SpotsAvailable { get; set; }
        [Display(Name = "Average Time")]
        public string AverageTimeMinutes { get; set; }
        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{TrailTrackerID}] {TrailName} {Description} {Miles} {Location} {Difficulty} {SpotsAvailable} {AverageTimeMinutes}";
    }
}
