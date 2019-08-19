namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reqCake : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cakes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Cakes", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cakes", "Description", c => c.String());
            AlterColumn("dbo.Cakes", "Name", c => c.String());
        }
    }
}
