using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities.DailyExpenses
{
    public class ExpensesDetails:EntityBase
    {
        public DateTime Date { get; set; }
        public int ExpensesId { get; set; }
        public int CompanyId { get; set; }
        public int AppId { get; set; }
        public int DriverId { get; set; }
        public ExpensesFlag Flag { get; set; }
        public decimal Amount { get; set; }
        [JsonIgnore]
        public DailyExpenses DailyExpenses { get; set; }
    }
    public enum ExpensesFlag : int
    {
        Day=1,
        Month=2,
        Company=3,
        App=4,
        Driver = 5,
    }
}
