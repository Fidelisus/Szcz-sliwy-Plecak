using System.Collections.Generic;
using SzczesliwyPlecak.Models;

namespace SzczesliwyPlecak.Services
{
    public class NutritionCalculatorService : INutritionCalculatorService
    {
        private const int DayCaloriesMale = 2500;
        private const int HourCaloriesMale = 112;
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

        public NutritionDaily CalculateDailyNutritions(Trip trip)
        {
            float participants = trip.FemaleParticipants * FemaleRation + trip.MaleParticipants;

            var output = new NutritionDaily
            {
                CaloriesMale = trip.CaloriesNeeded/ participants/ trip.DurationInDays,
                CarbohydratesMale = trip.CarbohydratesNeeded / participants / trip.DurationInDays,
                ProteinsMale = trip.ProteinsNeeded / participants / trip.DurationInDays,
                FatMale = trip.FatNeeded/ participants / trip.DurationInDays,
                CaloriesFemale = trip.CaloriesNeeded / participants * FemaleRation / trip.DurationInDays,
                CarbohydratesFemale = trip.CarbohydratesNeeded / participants * FemaleRation / trip.DurationInDays,
                ProteinsFemale = trip.ProteinsNeeded / participants * FemaleRation / trip.DurationInDays,
                FatFemale = trip.FatNeeded / participants * FemaleRation / trip.DurationInDays,
            };

            return output;
        }
    }
}
