using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SzczesliwyPlecak.Models
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Podaj nazwę")]
        public string Name { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "Podaj wartość większą od 0")]
        public float Weight { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "Podaj wartość większą lub równą 0")]
        public float Calories { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "Podaj wartość większą lub równą 0")]
        public float Fat { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "Podaj wartość większą lub równą 0")]
        public float Carbohydrates { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "Podaj wartość większą lub równą 0")]
        public float Proteins { get; set; }
        public ICollection<TripProduct> TripProducts { get; set; }
    }
}
