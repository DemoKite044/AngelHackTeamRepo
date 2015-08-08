using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon2015.Models
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Floor { get; set; }
        public string Building { get; set; }
        public string Street { get; set; }
        public string Barangay { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
    }
}