﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailTracker.Data
{
    public class TrailsInfo
    {
        [Key]
        public int TrailTrackerID { get; set; }
        public int Rating { get; set; }
        public string TrailComments { get; set; }
        public string NoteableSites { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}