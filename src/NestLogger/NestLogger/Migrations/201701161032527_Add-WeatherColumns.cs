namespace NestLogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeatherColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ThermostateReadings", "OutsideTemperature", c => c.String());
            AddColumn("dbo.ThermostateReadings", "WeatherJsonReading", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ThermostateReadings", "WeatherJsonReading");
            DropColumn("dbo.ThermostateReadings", "OutsideTemperature");
        }
    }
}
