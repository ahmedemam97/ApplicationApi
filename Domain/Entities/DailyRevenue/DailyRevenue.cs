using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DailyRevenue
{
    public class DailyRevenue : EntityBase
    {
        public DateTime  Date { get; set; }
        public decimal NetTotal { get; set; }
        public RevenueFlag Flag { get; set; }

        public List<RevenueDetails> RevenueDetails { get; set; }
    }
}
