﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TrailTracker.Data;
using static TrailTracker.Data.TrailMeet;

namespace TrailTracker.Models
{
    public class TrailMeetListItem
    {
        [Display(Name = "Trail Meet ID")]
        public int TrailMeetID { get; set; }
        public int TrailTrackerID { get; set; }
        [Display(Name = "Trail Name")]
        public string TrailName { get; set; }
        [Display(Name = "Trail Type")]
        public TrailType OfTrailType { get; set; }
        public string Picture { get; set; }
        [UIHint("JoinedTrail")]
        [Display(Name ="Favorite Trail")]
        public bool JoinTrail { get; set; }
        [Display(Name = "Meetup Time")]
        public DateTime MeetTime { get; set; }
        public string MeetComments { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
        public override string ToString() => Picture;
    }
}
