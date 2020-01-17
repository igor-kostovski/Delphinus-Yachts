namespace Delphinus_Yachts.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneBookingToZeroContracts : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Contracts", name: "Id", newName: "BookingId");
            DropPrimaryKey("dbo.Contracts");
            AddColumn("dbo.Bookings", "ContractId", c => c.Int());
            AlterColumn("dbo.Contracts", "BookingId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Contracts", "BookingId");
            CreateIndex("dbo.Contracts", "BookingId");
            AddForeignKey("dbo.Contracts", "BookingId", "dbo.Bookings", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "BookingId", "dbo.Bookings");
            DropIndex("dbo.Contracts", new[] { "BookingId" });
            DropPrimaryKey("dbo.Contracts");
            AlterColumn("dbo.Contracts", "BookingId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Bookings", "ContractId");
            AddPrimaryKey("dbo.Contracts", "Id");
            RenameColumn(table: "dbo.Contracts", name: "BookingId", newName: "Id");
        }
    }
}
