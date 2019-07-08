using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailTracker.Data;

namespace TrailTracker.Models
{
    public class TrailsInfoListItem
    {
        [Display(Name = "Trail Info ID")]
        public int TrailInfoID { get; set; }
        [Display(Name = "Trail Tracker ID")]
        public int TrailTrackerID { get; set; }
        public virtual Trail Trail { get; set; }
        [Display(Name = "Trail Name")]
        public string TrailName { get; set; }
        public int Rating { get; set; }
        [Display(Name = "Trail Comments")]
        public string TrailComments { get; set; }
        [Display(Name = "Noteable Sites")]
        public string NoteableSites { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
