using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailTracker.Data;

namespace TrailTracker.Models
{
    public class TrailsInfoCreate
    {
        [Display(Name = "Trail Info ID")]
        public int TrailInfoID { get; set; }
        public int TrailTrackerID { get; set; }
        [Display(Name = "Trail Name")]
        public string TrailName { get; set; }
        public int Rating { get; set; }
        [Display(Name = "Trail Comments")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string TrailComments { get; set; }
        [Display(Name = "Noteable Sites")]
        [MaxLength(8000)]
        public string NoteableSites { get; set; }
        public override string ToString() => TrailComments;
    }
}
