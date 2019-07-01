using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailTracker.Models
{
    public class TrailListItem
    {
        public int TrailTrackerID { get; set; }
        public string TrailName { get; set; }
        public int Description { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedTime { get; set; }
        public override string ToString() => TrailName;
    }
}
