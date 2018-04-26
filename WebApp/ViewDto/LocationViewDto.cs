using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personel.ViewDto
{
    public class LocationViewDto
    {
        public int ID { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string MapLocation { get; set; }

        public int? UserId { get; set; }
    }
}
