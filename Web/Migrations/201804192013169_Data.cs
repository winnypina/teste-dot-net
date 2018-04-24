namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Data : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Data", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Data");
        }
    }
}
