using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Maintenance
{
    public class Maintenance:EntityBase
    {

        public decimal PreviousKilometer { get; set; }
        public decimal CurrentKilometer { get; set; }
        public decimal Difference { get; set; }
        public decimal OilKilo { get; set; }
        public decimal OilMoney { get; set; }
        public decimal Repair { get; set; }
        public decimal Purchases { get; set; }
        public decimal License { get; set; }
        public decimal Contravention { get; set; }
        public decimal Total { get; set; }
    }
}
