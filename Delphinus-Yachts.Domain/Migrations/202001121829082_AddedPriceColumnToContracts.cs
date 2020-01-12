namespace Delphinus_Yachts.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPriceColumnToContracts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contracts", "Price");
        }
    }
}
