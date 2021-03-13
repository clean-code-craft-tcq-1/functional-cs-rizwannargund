using System;
using System.Diagnostics;

namespace BatteryManagementSystem
{
    public class Checker
    {
        private static BatteryRangeValidator batteryRangeValidator = new BatteryRangeValidator();
        static bool IsBatteryOk(float temperature, float soc, float chargeRate)
        {
            if (batteryRangeValidator.IsTemperatureRangeValid(temperature) &&
                batteryRangeValidator.IsSocRangeValid(soc) && 
                batteryRangeValidator.IsChargeRateRangeValid(chargeRate))
            {
                Logger.PrintMessage("Battery state is good.");
                return true;
            }
            else
            {
                Logger.PrintMessage("Battery state is critical!");
                return false;
            }
        }

        static int Main()
        {
            batteryRangeValidator.MinimumTemperature = 0;
            batteryRangeValidator.MaximumTemperature = 45;
            batteryRangeValidator.MinimumSoc = 20;
            batteryRangeValidator.MaximumSoc = 80;
            batteryRangeValidator.MaximumChargeRate = 0.8f;

            IsBatteryOk(-1, 70, 0.7f);
            IsBatteryOk(25, 70, 0.7f);
            IsBatteryOk(46, 70, 0.7f);

            IsBatteryOk(25, 10, 0.7f);
            IsBatteryOk(25, 70, 0.7f);
            IsBatteryOk(25, 81, 0.7f);

            IsBatteryOk(25, 70, 0.7f);
            IsBatteryOk(25, 70, 0.8f);

            BreachChecker.GetBreachLevel(batteryRangeValidator.MaximumTemperature,
                batteryRangeValidator.MinimumTemperature,
                -1);
            BreachChecker.GetBreachLevel(batteryRangeValidator.MaximumTemperature,
                batteryRangeValidator.MinimumTemperature,
                25);
            BreachChecker.GetBreachLevel(batteryRangeValidator.MaximumTemperature,
                batteryRangeValidator.MinimumTemperature,
                46);

            BreachChecker.GetBreachLevel(batteryRangeValidator.MaximumSoc,
                batteryRangeValidator.MinimumSoc,
                10);
            BreachChecker.GetBreachLevel(batteryRangeValidator.MaximumSoc,
                batteryRangeValidator.MinimumSoc,
                70);
            BreachChecker.GetBreachLevel(batteryRangeValidator.MaximumSoc,
                batteryRangeValidator.MinimumSoc,
                81);

            BreachChecker.GetBreachLevel(batteryRangeValidator.MaximumChargeRate,
                0,
                0.8f);
            BreachChecker.GetBreachLevel(batteryRangeValidator.MaximumChargeRate,
                0,
                0.7f);
            Console.WriteLine("All ok");
            return 0;
        }
    }
}