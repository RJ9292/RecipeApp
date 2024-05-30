using System;
using System.Collections.Generic;

namespace RecipeApp.Class
{
    // Static class for converting measurements between different units
    public static class MeasurementConverter
    {
        // Dictionary to store unit conversions in terms of a base unit
        public static readonly Dictionary<string, double> UnitConversions = new Dictionary<string, double>
        {
            // Volume units in terms of teaspoons
            { "teaspoon", 1 }, // 1 teaspoon is the base unit for volume
            { "tablespoon", 3 }, // 1 tablespoon = 3 teaspoons
            { "cup", 48 }, // 1 cup = 48 teaspoons
            { "ml", 0.202884 }, // 1 milliliter = 0.202884 teaspoons
            { "l", 202.884 }, // 1 liter = 202.884 teaspoons

            // Weight units in terms of milligrams
            { "mg", 1 }, // 1 milligram is the base unit for weight
            { "g", 1000 }, // 1 gram = 1000 milligrams
            { "kg", 1000000 } // 1 kilogram = 1000000 milligrams
        };

        // Dictionary to store the type of units (volume or weight)
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

        // Method to convert a quantity from one unit to another
        public static string ConvertMeasurement(double quantity, string fromUnit, string toUnit)
        {
            // Check if the units are valid
            if (!UnitConversions.ContainsKey(fromUnit) || !UnitConversions.ContainsKey(toUnit))
            {
                return $"{quantity} {fromUnit}";
            }

            // Check if the units are of the same type (volume or weight)
            if (UnitTypes[fromUnit] != UnitTypes[toUnit])
            {
                return $"{quantity} {fromUnit}"; // Conversion between weight and volume is not supported
            }

            // Convert the quantity to the base unit and then to the target unit
            double baseQuantity = quantity * UnitConversions[fromUnit];
            double convertedQuantity = baseQuantity / UnitConversions[toUnit];

            return $"{convertedQuantity} {toUnit}";
        }

        // Method to scale a quantity by a multiplier and convert units if necessary
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
