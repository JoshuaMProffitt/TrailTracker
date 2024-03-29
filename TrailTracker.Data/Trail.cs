﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailTracker.Data
{
    public class Trail
    {
        [Key]
        public int TrailTrackerID { get; set; }
        public Guid OwnerID { get; set; }
        [Required]
        public string TrailName { get; set; }
        [Required]
        [Display(Name = "Your Trail")]
        public string Description { get; set; }
        public double Miles { get; set; }
        public string Location { get; set; }
        [Required]
        public int Difficulty { get; set; }
        public int Elevation { get; set; }
        public int SpotsAvailable { get; set; }
        public string AverageTimeMinutes { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
