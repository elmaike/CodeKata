using CodeKata.DTO;
using CodeKata.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CodeKata.Utilities
{
    public class HelperOutputReport
    {
        private string[] formats = { "%h", "g", "G" };
        private CultureInfo culture = new CultureInfo("es-MX");
        public Dictionary<string, OutputReportDto> GetDriversReport(string input)
        {
            Dictionary<string, OutputReportDto> output = new Dictionary<string, OutputReportDto>();

            var lines = input.Split(Environment.NewLine);
            foreach(var line in lines)
            {
                var lineItems = line.Split(" ");
                var driverName = lineItems[1];
                switch (lineItems[0])
                {
                    case "Driver":
                        output.Add(driverName, new OutputReportDto());
                        break;
                    case "Trip":
                        var milesDriven = Convert.ToDecimal(lineItems[4]);                                                                    
                        var startTime = TimeSpan.ParseExact(lineItems[2], formats, culture, TimeSpanStyles.AssumeNegative);
                        var endTime = TimeSpan.ParseExact(lineItems[3], formats, culture, TimeSpanStyles.AssumeNegative);
                        var timeInHours = (endTime - startTime);
                        decimal time = timeInHours.Hours;
                        if(timeInHours.Minutes > 0)
                        {
                            time += Math.Round((timeInHours.Minutes / (decimal)60), 2);
                        }
                        var speed = Math.Round(milesDriven / time, 2);
                        if(speed < 5 || speed > 100)
                        {
                            break;
                        }
                        output[driverName].NumberOfTrips += 1;
                        output[driverName].Speeds += speed;
                        output[driverName].AverageSpeed = Math.Round((decimal)output[driverName].Speeds / (decimal)output[driverName].NumberOfTrips, 2);
                        output[driverName].MilesDriven += milesDriven;

                        output[driverName].MilesDrivenTotal = Math.Round(output[driverName].MilesDriven);
                        output[driverName].AvgSpeed = Math.Round(output[driverName].AverageSpeed);
                        break;
                }
            }
            return output.OrderByDescending(x => x.Value.MilesDrivenTotal).ToDictionary(i=>i.Key, j=>j.Value);
        }

        private Driver SaveDriver(string[] items)
        {
            return new Driver { Name = items[1] };
        }

        private Trip SaveTrip(string[] items)
        {
            string[] formats = { "%h", "g", "G" };
            CultureInfo culture = new CultureInfo("es-MX");
            return new Trip
            {
                EndTime = TimeSpan.ParseExact(items[3], formats, culture, TimeSpanStyles.AssumeNegative),
                StartTime = TimeSpan.ParseExact(items[2], formats, culture, TimeSpanStyles.AssumeNegative),
                MilesDriven = Convert.ToDecimal(items[4])
            };
        }
    }
}
