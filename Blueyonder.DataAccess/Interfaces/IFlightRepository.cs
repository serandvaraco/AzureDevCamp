using Blueyonder.Entities;
using System;
using System.Linq;


namespace Blueyonder.DataAccess.Interfaces
{
    public interface IFlightRepository : IRepository<Flight>
    {
        Flight GetFlight(string flightNumber);
        Flight GetFlight(int flightID);
        FlightSchedule GetSchedule(int flightScheduleId);
        IQueryable<FlightSchedule> GetFlightSchedules(Location fromLocation, Location toLocation, DateTime fromDate, DateTime toDate);
        
        void AddSchedule(Flight route, FlightSchedule newSchedule);
        void UpdateSchedule(FlightSchedule flightSchedule);
        void UpdateActualDeparture(FlightSchedule flightSchedule, DateTime newDeparture);
    }
}
