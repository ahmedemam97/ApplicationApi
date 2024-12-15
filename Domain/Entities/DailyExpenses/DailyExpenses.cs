using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DailyExpenses
{
    public class DailyExpenses : EntityBase
    {
        public DateTime Date { get; set; }
        public decimal NetTotal { get; set; }
        public ExpensesFlag Flag { get; set; }
        public List<ExpensesDetails> ExpensesDetails { get; set; }
    }
}
