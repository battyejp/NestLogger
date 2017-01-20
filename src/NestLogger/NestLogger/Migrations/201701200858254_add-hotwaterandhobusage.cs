namespace NestLogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addhotwaterandhobusage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HobUsages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MinutesUsed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HotWaterSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HotWaterSchedules");
            DropTable("dbo.HobUsages");
        }
    }
}
