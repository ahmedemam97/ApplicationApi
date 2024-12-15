using Domain.Entities.DailyExpenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class DailyExpensesDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal NetTotal { get; set; }
        public List<ExpensesDay> ExpensesDay { get; set; }
        public List<ExpensesMonth> ExpensesMonth { get; set; }
        public List<ExpensesCompany> ExpensesCompany { get; set; }
        public List<ExpensesApp> ExpensesApp { get; set; }

    }
}
