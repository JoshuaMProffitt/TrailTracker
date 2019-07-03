﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailTracker.Data;

namespace TrailTracker.Models
{
    public class TrailMeetDetail
    {
        [Display(Name = "Trail Meet ID")]
        public int TrailMeetID { get; set; }
        public TrailType OfTrailType { get; set; }
        public string Picture { get; set; }
        [Display(Name = "Meetup Time")]
        public DateTime MeetTime { get; set; }
        [Display(Name = "Meet Comments")]
        public string MeetComments { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
        public override string ToString() => $"[{TrailMeetID}] {OfTrailType} {Picture} {MeetTime} {MeetComments}";
    }
}
