using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CompleteBookings
{
    public class CompleteBookings:EntityBase
    {
        public DateTime Date { get; set; }
        public int BookingsId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int TravelType { get; set; }
        public int DoneById { get; set; }
        public decimal Amount { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Reason { get; set; }
        public int RevenueId { get; set; }
    }
}
