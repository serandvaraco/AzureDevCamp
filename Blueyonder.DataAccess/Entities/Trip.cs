using Blueyonder.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blueyonder.Entities
{
    public class Trip
    {
        public int TripId { get; set; }

        public int FlightScheduleID { get; set; }

        
        [ForeignKey("FlightScheduleID")]
        public virtual FlightSchedule FlightInfo { get; set; }

        public FlightStatus Status { get; set; }

        public SeatClass Class { get; set; }
    }
}
