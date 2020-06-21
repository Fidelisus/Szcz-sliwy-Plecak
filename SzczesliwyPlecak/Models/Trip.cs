using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SzczesliwyPlecak.Models
{
    public class Trip
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Podaj nazwę")]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Podaj wartość większą od 0")]
        public int DurationInDays { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Podaj wartość większą lub równą 0")]
        public int FemaleParticipants { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Podaj wartość większą lub równą 0")]
        public int MaleParticipants { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Podaj wartość większą od 0")]
        public int TotalTimeHiking { get; set; }
        public float CaloriesNeeded { get; set; }
        public float FatNeeded { get; set; }
        public float CarbohydratesNeeded { get; set; }
        public float ProteinsNeeded { get; set; }
        public ICollection<TripProduct> TripProducts { get; set; }
    }
}
