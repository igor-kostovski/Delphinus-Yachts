namespace Delphinus_Yachts.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedManyToManyRouteToLocation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RouteLocations",
                c => new
                    {
                        Route_Id = c.Int(nullable: false),
                        Location_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Route_Id, t.Location_Id })
                .ForeignKey("dbo.Routes", t => t.Route_Id, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.Location_Id, cascadeDelete: true)
                .Index(t => t.Route_Id)
                .Index(t => t.Location_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RouteLocations", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.RouteLocations", "Route_Id", "dbo.Routes");
            DropIndex("dbo.RouteLocations", new[] { "Location_Id" });
            DropIndex("dbo.RouteLocations", new[] { "Route_Id" });
            DropTable("dbo.RouteLocations");
        }
    }
}
