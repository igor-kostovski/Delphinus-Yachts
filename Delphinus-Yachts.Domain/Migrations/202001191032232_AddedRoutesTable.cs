namespace Delphinus_Yachts.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRoutesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Routes");
        }
    }
}
