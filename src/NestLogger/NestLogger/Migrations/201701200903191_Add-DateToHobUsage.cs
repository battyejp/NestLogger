namespace NestLogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToHobUsage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HobUsages", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HobUsages", "Date");
        }
    }
}
