using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Location : Base
    {
        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string MapLocation { get; set; }

        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
