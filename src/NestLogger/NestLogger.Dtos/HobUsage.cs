using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestLogger.Dtos
{
    public class HobUsage
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int MinutesUsed { get; set; }
    }
}
