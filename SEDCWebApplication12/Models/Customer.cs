﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication12.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ContactId { get; set; }

        public string Email { get; set; }
        public string Picture { get; set; }

    }
}
