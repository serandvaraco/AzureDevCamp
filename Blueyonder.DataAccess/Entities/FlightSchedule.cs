using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blueyonder.Entities
{
    public class FlightSchedule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightScheduleId { get; set; }

        public DateTime Departure { get; set; }

        public DateTime? ActualDeparture { get; set; }
        
        public TimeSpan Duration { get; set; }

        public int FlightId { get; set; }

        [ForeignKey("FlightId")]
        public virtual Flight Flight { get; set; }
    }
}