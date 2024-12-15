using Domain.Entities.DailyExpenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class ExpensesMonth
    {
        public DateTime Date { get; set; }
        public int ExpensesId { get; set; }
        public ExpensesFlag Flag { get; set; }
        public decimal Amount { get; set; }
    }
}
