namespace Delphinus_Yachts.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectedBookingWithContract : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "ContractId", c => c.Int());
            CreateIndex("dbo.Bookings", "ContractId");
            AddForeignKey("dbo.Bookings", "ContractId", "dbo.Contracts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "ContractId", "dbo.Contracts");
            DropIndex("dbo.Bookings", new[] { "ContractId" });
            DropColumn("dbo.Bookings", "ContractId");
        }
    }
}
