using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailTracker.Models
{
    public class TrailsInfoDetail
    {
        public int TrailTrackerID { get; set; }
        public int Rating { get; set; }
        public string TrailComments { get; set; }
        public string NoteableSites { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{TrailTrackerID}] {Rating} {TrailComments} {NoteableSites}";
    }
}
