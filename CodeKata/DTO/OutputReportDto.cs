using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeKata.DTO
{
    public class OutputReportDto
    {  
        public decimal Speeds { get; set; }
        
        public int NumberOfTrips { get; set; }
        
        public decimal MilesDriven { get; set; }
       
        public decimal AverageSpeed { get; set; }
        public decimal MilesDrivenTotal { get; set; }    
        public decimal AvgSpeed { get; set; }
    }
}
