using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Expenses
{
    public class Expenses: EntityBase
    {
        public decimal Amount { get; set; }
        public Type Type { get; set; }
    }
    public enum Type:int
    {
        Day=1,
        Month=2,
        Driver = 3
    }
}
