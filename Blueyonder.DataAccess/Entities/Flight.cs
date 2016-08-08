using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blueyonder.Entities
{
    public class Flight
    {
        public Flight()
        {
            Schedules = new List<FlightSchedule>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightId { get; set; }

        public string FlightNumber { get; set; }

        public int FrequentFlyerMiles { get; set; }

        public virtual Location Source { get; set; }

        public virtual Location Destination { get; set; }

        public virtual ICollection<FlightSchedule> Schedules { get; set; }
    }
}