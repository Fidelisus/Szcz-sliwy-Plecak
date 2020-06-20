using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SzczesliwyPlecak.Models
{
    public class Nutritions
    {
        public float Weight { get; set; }
        public float Calories { get; set; }
        public float Fat { get; set; }
        public float Carbohydrates { get; set; }
        public float Proteins { get; set; }
        public float CaloriesNeeded { get; set; }
        public float FatNeeded { get; set; }
        public float CarbohydratesNeeded { get; set; }
        public float ProteinsNeeded { get; set; }
    }
}
