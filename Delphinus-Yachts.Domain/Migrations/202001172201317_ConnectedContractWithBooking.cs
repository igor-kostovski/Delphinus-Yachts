namespace Delphinus_Yachts.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectedContractWithBooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "BookingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contracts", "BookingId");
            AddForeignKey("dbo.Contracts", "BookingId", "dbo.Bookings", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "BookingId", "dbo.Bookings");
            DropIndex("dbo.Contracts", new[] { "BookingId" });
            DropColumn("dbo.Contracts", "BookingId");
        }
    }
}
