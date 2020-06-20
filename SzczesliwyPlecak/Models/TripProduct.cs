﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SzczesliwyPlecak.Models
{
    public class TripProduct
    {
        public int Id { get; set; }
        public Trip Trip { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
