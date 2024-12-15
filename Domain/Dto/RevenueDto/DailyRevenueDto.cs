using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.RevenueDto
{
    public class DailyRevenueDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal NetTotal { get; set; }
        public List<RevenueCompany> RevenueCompany { get; set; }
        public List<RevenueApp> RevenueApp { get; set; }
    }
}
