using System;
using System.Collections.Generic;

namespace RecipeApp.Class
{
    public static class MeasurementConverter
    {
        public static readonly Dictionary<string, double> UnitConversions = new Dictionary<string, double>
        {
            // Volume units in terms of teaspoons
            { "teaspoon", 1 },
            { "tablespoon", 3 },
            { "cup", 48 },
            { "ml", 0.202884 }, // milliliters to teaspoons
            { "l", 202.884 }, // liters to teaspoons

            // Weight units in terms of milligrams
            { "mg", 1 },
            { "g", 1000 }, // grams to milligrams
            { "kg", 1000000 } // kilograms to milligrams
        };

        public static readonly Dictionary<string, string> UnitTypes = new Dictionary<string, string>
        {
            { "teaspoon", "volume" },
            { "tablespoon", "volume" },
            { "cup", "volume" },
            { "ml", "volume" },
            { "l", "volume" },
            { "mg", "weight" },
            { "g", "weight" },
            { "kg", "weight" }
        };

        public static string ConvertMeasurement(double quantity, string fromUnit, string toUnit)
        {
            if (!UnitConversions.ContainsKey(fromUnit) || !UnitConversions.ContainsKey(toUnit))
            {
                return $"{quantity} {fromUnit}";
            }

            if (UnitTypes[fromUnit] != UnitTypes[toUnit])
            {
                return $"{quantity} {fromUnit}"; // Conversion between weight and volume is not supported
            }

            double baseQuantity = quantity * UnitConversions[fromUnit];
            double convertedQuantity = baseQuantity / UnitConversions[toUnit];

            return $"{convertedQuantity} {toUnit}";
        }

        public static (double Quantity, string Unit) ScaleMeasurement(double quantity, string unit, double multiplier)
        {
            double scaledQuantity = quantity * multiplier;
            string scaledUnit = unit;

            // Perform conversion if necessary (e.g., tablespoons to cups)
            while (scaledUnit == "tablespoon" && scaledQuantity >= 16)
            {
                scaledQuantity /= 16;
                scaledUnit = "cup";
            }

            while (scaledUnit == "teaspoon" && scaledQuantity >= 3)
            {
                scaledQuantity /= 3;
                scaledUnit = "tablespoon";
            }

            while (scaledUnit == "ml" && scaledQuantity >= 1000)
            {
                scaledQuantity /= 1000;
                scaledUnit = "l";
            }

            while (scaledUnit == "mg" && scaledQuantity >= 1000)
            {
                scaledQuantity /= 1000;
                scaledUnit = "g";
            }

            while (scaledUnit == "g" && scaledQuantity >= 1000)
            {
                scaledQuantity /= 1000;
                scaledUnit = "kg";
            }

            return (scaledQuantity, scaledUnit);
        }

        // End of MeasurementConverter class
    }

    // End of RecipeApp.Class namespace
}
