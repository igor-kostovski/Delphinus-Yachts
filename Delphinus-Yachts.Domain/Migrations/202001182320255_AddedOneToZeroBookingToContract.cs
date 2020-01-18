namespace Delphinus_Yachts.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOneToZeroBookingToContract : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Contracts");
            AddColumn("dbo.Bookings", "ContractId", c => c.Int());
            AddColumn("dbo.Contracts", "BookingId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Contracts", new[] { "Id", "BookingId" });
            CreateIndex("dbo.Contracts", "BookingId");
            AddForeignKey("dbo.Contracts", "BookingId", "dbo.Bookings", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "BookingId", "dbo.Bookings");
            DropIndex("dbo.Contracts", new[] { "BookingId" });
            DropPrimaryKey("dbo.Contracts");
            AlterColumn("dbo.Contracts", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Contracts", "BookingId");
            DropColumn("dbo.Bookings", "ContractId");
            AddPrimaryKey("dbo.Contracts", "Id");
        }
    }
}
