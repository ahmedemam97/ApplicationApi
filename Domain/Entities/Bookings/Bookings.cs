using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bookings
{
    public class Bookings:EntityBase
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public DateTime Date { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public int CityFromId { get; set; }
        public string CityFromName { get; set; }
        public int CityToId { get; set; }
        public string CityToName { get; set; }
        public int TravelType { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string GoogleFrom { get; set; }
        public string GoogleTo { get; set; }
        public bool Completed { get; set; } = false;

    }
}
