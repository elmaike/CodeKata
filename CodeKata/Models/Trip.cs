using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeKata.Models
{
    public class Trip
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public decimal TimeInHours
        {
            get
            {
                decimal result = 0;
                var timeInHours = (EndTime - StartTime);
                result = timeInHours.Hours;
                if(timeInHours.Minutes > 0)
                {
                    result += Math.Round((decimal)(timeInHours.Minutes / 60), 2);
                }
                return result;
            }
        }

        public decimal MilesDriven { get; set; }
    }
}
