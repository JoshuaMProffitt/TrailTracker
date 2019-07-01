using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailTracker.Models
{
    public class TrailCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Trail Name")]
        public string TrailName { get; set; }
        [MaxLength(8000)]
        public string Description { get; set; }
        public double Miles { get; set; }
        public string Location { get; set; }
        [Required]
        public int Difficulty { get; set; }
        public int Elevation { get; set; }
        [Display(Name = "Spots Available")]
        public int SpotsAvailable { get; set; }
        [Display(Name = "Average Time")]
        public string AverageTimeMinutes { get; set; }
        public override string ToString() => TrailName;
    }
}
