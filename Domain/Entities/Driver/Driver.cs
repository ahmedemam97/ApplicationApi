using Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Driver
{
    public class Driver:EntityBase
    {
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string CardNumber { get; set; }
    }
}
