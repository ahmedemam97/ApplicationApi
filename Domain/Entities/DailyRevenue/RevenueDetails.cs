using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities.DailyRevenue
{
    public class RevenueDetails : EntityBase
    {
        public DateTime Date { get; set; }
        public int RevenueId { get; set; }
        public int CompanyId { get; set; }
        public int AppId { get; set; }
        public decimal Amount { get; set; }
        public RevenueFlag Flag { get; set; }
        [JsonIgnore]
        public DailyRevenue DailyRevenue { get; set; }
    }
    public enum RevenueFlag:int
    {
        Company=1,
        App=2,
        Travel = 3
    }
}
