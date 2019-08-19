namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActionlogTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Controller = c.String(),
                        Action = c.String(),
                        RequestDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ActionLogs");
        }
    }
}
