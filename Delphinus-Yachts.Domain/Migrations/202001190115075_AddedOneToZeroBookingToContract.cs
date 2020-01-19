namespace Delphinus_Yachts.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOneToZeroBookingToContract : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Contracts");
            AlterColumn("dbo.Contracts", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Contracts", "Id");
            CreateIndex("dbo.Contracts", "Id");
            AddForeignKey("dbo.Contracts", "Id", "dbo.Bookings", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "Id", "dbo.Bookings");
            DropIndex("dbo.Contracts", new[] { "Id" });
            DropPrimaryKey("dbo.Contracts");
            AlterColumn("dbo.Contracts", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Contracts", "Id");
        }
    }
}
