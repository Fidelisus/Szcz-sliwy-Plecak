using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SzczesliwyPlecak.Models
{
    public class TripProduct
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
