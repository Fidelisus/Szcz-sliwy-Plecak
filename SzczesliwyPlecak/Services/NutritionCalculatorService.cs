using System.Collections.Generic;
using SzczesliwyPlecak.Models;

namespace SzczesliwyPlecak.Services
{
    public class NutritionCalculatorService : INutritionCalculatorService
    {
        private const int DayCaloriesMale = 2700;
        private const int HourCaloriesMale = 324;
        private const float FemaleRation = 0.8f;
        private const float CarbohydratesToCalories = 0.128f;
        private const float ProteinToCalories = 0.037f;
        private const float FatToCalories = 0.026f;

        public Trip CalculateNutrition(Trip trip)
        {
            float participants = trip.FemaleParticipants * FemaleRation + trip.MaleParticipants;
            trip.CaloriesNeeded = participants* DayCaloriesMale * trip.DurationInDays + participants * HourCaloriesMale*trip.TotalTimeHiking;
            trip.CarbohydratesNeeded = trip.CaloriesNeeded * CarbohydratesToCalories;
            trip.FatNeeded = trip.CaloriesNeeded * FatToCalories;
            trip.ProteinsNeeded = trip.CaloriesNeeded * ProteinToCalories;
            trip.TripProducts = new List<TripProduct>();
            return trip;
        }
    }
}
