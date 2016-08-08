using Blueyonder.Companion.Entities;
using System.Collections.Generic;

namespace Blueyonder.Companion.Controllers.DataTransferObjects
{
    public class FlightWithSchedulesDto : FlightDTO
    {
        public string FlightNumber { get; set; }
        
        public int FlightId { get; set; }
        
        public LocationDTO From { get; set; }

        public LocationDTO To { get; set; }

        public IEnumerable<ScheduleDto> Schedules { get; set; }
    }
}
