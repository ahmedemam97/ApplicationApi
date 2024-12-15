using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Expened
{
    public class Expened : EntityBase
    {

        public decimal Amount { get; set; }
        public Typef Type { get; set; }
    }
    public enum Typef : int
    {
        Day = 1,
        Month = 2,
        Driver = 3
    }


}
