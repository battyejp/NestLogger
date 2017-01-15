namespace NestLogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJsonReadingColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ThermostateReadings", "JsonReading", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ThermostateReadings", "JsonReading");
        }
    }
}
