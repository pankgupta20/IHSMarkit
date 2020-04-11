using System;
using System.Collections.Generic;

namespace TestProject.UITest.Models
{
    [Serializable()]
    public class FlightDetails
    {
        public List<City> Cities { get; set; }

        public List<DepartureDate> DepartureDates { get; set; }

        public string Travelers { get; set; }
    };

   public class City
    {
        public string CityFrom { get; set; }

        public string CityTo { get; set; }
    }

   public class DepartureDate
    {
        public string DepartDate { get; set; }
    }
}
