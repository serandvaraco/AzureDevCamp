namespace Blueyonder.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdColumnsTripReservation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trips", "ThumbnailImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trips", "ThumbnailImage");
        }
    }
}
