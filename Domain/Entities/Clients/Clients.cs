﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Clients
{
    public class Clients:EntityBase
    {
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
