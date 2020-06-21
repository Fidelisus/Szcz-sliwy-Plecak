using SzczesliwyPlecak.Models;

namespace SzczesliwyPlecak.Services
{
    public interface INutritionCalculatorService
    {
        public Trip CalculateNutrition(Trip trip);
    }
}
