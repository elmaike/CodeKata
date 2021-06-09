using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeKata.Models
{
    public class Driver
    {
        public string Name { get; set; }

        public List<Trip> Trips { get; set; }
    }
}
