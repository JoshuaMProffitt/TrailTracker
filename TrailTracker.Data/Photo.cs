using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailTracker.Data
{
    public enum FileType
    {
        Picture = 1, Photo
    }
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }
        [StringLength(255)]
        public string PhotoName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        public int TrailMeetID { get; set; }
        public virtual TrailMeet TrailMeet { get; set; }
    }
}