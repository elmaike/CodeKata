using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeKata.DTO
{
    public class OutputReportDto
    {       
        [JsonIgnore]
        public decimal Speeds { get; set; }
        [JsonIgnore]
        public int NumberOfTrips { get; set; }
        [JsonIgnore]
        public decimal MilesDriven { get; set; }
        [JsonIgnore]
        public decimal AverageSpeed { get; set; }
        public decimal MilesDrivenTotal { get; set; }    
        public decimal AvgSpeed { get; set; }
    }
}
