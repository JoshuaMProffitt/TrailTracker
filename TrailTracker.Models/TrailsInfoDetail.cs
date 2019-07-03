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
        [Display(Name = "Trail Info ID")]
        public int TrailInfoID { get; set; }
        public int Rating { get; set; }
        public string TrailComments { get; set; }
        public string NoteableSites { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{TrailInfoID}] {Rating} {TrailComments} {NoteableSites}";
    }
}
