namespace NestLogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnitsUsedToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MeterReadings", "Value", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MeterReadings", "Value", c => c.Int(nullable: false));
        }
    }
}
