namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class detailIdCOlumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActionLogs", "DetailId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ActionLogs", "DetailId");
        }
    }
}
