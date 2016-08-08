﻿using Blueyonder.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueyonder.DataAccess
{    
    public class TravelCompanionContext : DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Trip> Trips { get; set; }

        public TravelCompanionContext(string connectionName) : base(connectionName)
        {
        }

        public TravelCompanionContext() : this("TravelCompanion")
        {
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightSchedule> FlightSchedules { get; set; }
        public DbSet<Traveler> Travelers { get; set; }    

       

    }
}
