namespace Blueyonder.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightId = c.Int(nullable: false, identity: true),
                        FlightNumber = c.String(),
                        FrequentFlyerMiles = c.Int(nullable: false),
                        Destination_LocationId = c.Int(),
                        Source_LocationId = c.Int(),
                    })
                .PrimaryKey(t => t.FlightId)
                .ForeignKey("dbo.Locations", t => t.Destination_LocationId)
                .ForeignKey("dbo.Locations", t => t.Source_LocationId)
                .Index(t => t.Destination_LocationId)
                .Index(t => t.Source_LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        State = c.String(),
                        City = c.String(),
                        CountryCode = c.String(),
                        ThumbnailImageFile = c.String(),
                        TimeZoneId = c.String(),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.FlightSchedules",
                c => new
                    {
                        FlightScheduleId = c.Int(nullable: false, identity: true),
                        Departure = c.DateTime(nullable: false),
                        ActualDeparture = c.DateTime(),
                        Duration = c.Time(nullable: false, precision: 7),
                        FlightId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FlightScheduleId)
                .ForeignKey("dbo.Flights", t => t.FlightId, cascadeDelete: true)
                .Index(t => t.FlightId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        TravelerId = c.Int(nullable: false),
                        ReservationDate = c.DateTime(nullable: false),
                        ConfirmationCode = c.String(),
                        DepartFlightScheduleID = c.Int(nullable: false),
                        ReturnFlightScheduleID = c.Int(),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.Trips", t => t.DepartFlightScheduleID, cascadeDelete: true)
                .ForeignKey("dbo.Trips", t => t.ReturnFlightScheduleID)
                .Index(t => t.DepartFlightScheduleID)
                .Index(t => t.ReturnFlightScheduleID);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        TripId = c.Int(nullable: false, identity: true),
                        FlightScheduleID = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Class = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TripId)
                .ForeignKey("dbo.FlightSchedules", t => t.FlightScheduleID, cascadeDelete: true)
                .Index(t => t.FlightScheduleID);
            
            CreateTable(
                "dbo.Travelers",
                c => new
                    {
                        TravelerId = c.Int(nullable: false, identity: true),
                        TravelerUserIdentity = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MobilePhone = c.String(),
                        HomeAddress = c.String(),
                        Passport = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.TravelerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "ReturnFlightScheduleID", "dbo.Trips");
            DropForeignKey("dbo.Reservations", "DepartFlightScheduleID", "dbo.Trips");
            DropForeignKey("dbo.Trips", "FlightScheduleID", "dbo.FlightSchedules");
            DropForeignKey("dbo.Flights", "Source_LocationId", "dbo.Locations");
            DropForeignKey("dbo.FlightSchedules", "FlightId", "dbo.Flights");
            DropForeignKey("dbo.Flights", "Destination_LocationId", "dbo.Locations");
            DropIndex("dbo.Trips", new[] { "FlightScheduleID" });
            DropIndex("dbo.Reservations", new[] { "ReturnFlightScheduleID" });
            DropIndex("dbo.Reservations", new[] { "DepartFlightScheduleID" });
            DropIndex("dbo.FlightSchedules", new[] { "FlightId" });
            DropIndex("dbo.Flights", new[] { "Source_LocationId" });
            DropIndex("dbo.Flights", new[] { "Destination_LocationId" });
            DropTable("dbo.Travelers");
            DropTable("dbo.Trips");
            DropTable("dbo.Reservations");
            DropTable("dbo.FlightSchedules");
            DropTable("dbo.Locations");
            DropTable("dbo.Flights");
        }
    }
}
