﻿using System.Data.Entity;
using NestLogger.Dtos;

namespace NestLogger.Models
{
    public class NestLoggerContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public NestLoggerContext() : base("name=NestLoggerContext")
        {
        }

        public DbSet<ThermostateReading> ThermostateReadings { get; set; }

        public System.Data.Entity.DbSet<NestLogger.Dtos.MeterReading> MeterReadings { get; set; }

        public System.Data.Entity.DbSet<NestLogger.Dtos.HotWaterSchedule> HotWaterSchedules { get; set; }

        public System.Data.Entity.DbSet<NestLogger.Dtos.HobUsage> HobUsages { get; set; }
    }
}
