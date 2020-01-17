namespace Delphinus_Yachts.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedContractIdColumnFromBooking : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bookings", "ContractId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "ContractId", c => c.Int());
        }
    }
}
