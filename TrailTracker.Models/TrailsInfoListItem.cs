using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailTracker.Models
{
    public class TrailsInfoListItem
    {
        public int TrailTrackerID { get; set; }
        public int Rating { get; set; }
        [Display(Name = "Trail Comments")]
        public string TrailComments { get; set; }
        [Display(Name = "Noteable Sites")]
        public string NoteableSites { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Mofified")]
        public DateTimeOffset ModifiedUtc { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
