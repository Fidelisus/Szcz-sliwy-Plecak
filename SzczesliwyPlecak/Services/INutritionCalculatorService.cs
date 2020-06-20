using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SzczesliwyPlecak.Models;

namespace SzczesliwyPlecak.Services
{
    public interface INutritionCalculatorService
    {
        public Trip CalculateNutrition(Trip trip);
    }
}
