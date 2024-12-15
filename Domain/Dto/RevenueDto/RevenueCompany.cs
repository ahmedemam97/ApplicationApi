using Domain.Entities.DailyRevenue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.RevenueDto
{
    public class RevenueCompany
    {
        public DateTime Date { get; set; }
        public int RevenueId { get; set; }
        public decimal Amount { get; set; }
        public RevenueFlag Flag { get; set; }

    }
}
