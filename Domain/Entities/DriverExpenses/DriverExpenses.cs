using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DriverExpenses
{
    public class DriverExpenses:EntityBase
    {
        public DateTime Date { get; set; }
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public decimal Amount { get; set; }
        public int DailyExpensesId { get; set; }
    }
}
