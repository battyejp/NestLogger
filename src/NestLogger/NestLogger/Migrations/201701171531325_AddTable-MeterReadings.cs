namespace NestLogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableMeterReadings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MeterReadings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MeterReadings");
        }
    }
}
