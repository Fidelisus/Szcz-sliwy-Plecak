using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SzczesliwyPlecak.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }
        public float Calories { get; set; }
        public float Fat { get; set; }
        public float Carbohydrates { get; set; }
        public float Proteins { get; set; }
        public ICollection<TripProduct> TripProducts { get; set; }
    }
}
