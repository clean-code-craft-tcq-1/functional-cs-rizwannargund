using System;
using System.Diagnostics;

namespace BatteryManagementSystem
{
    public class BatteryStateChecker
    {
        private static BatteryRangeValidator batteryRangeValidator = new BatteryRangeValidator();

        static bool IsBatteryOk(float temperature, float soc, float chargeRate)
            =>
                (batteryRangeValidator.IsTemperatureRangeValid(temperature) &&
                 batteryRangeValidator.IsSocRangeValid(soc) &&
                 batteryRangeValidator.IsChargeRateRangeValid(chargeRate));
        
        static int Main()
        {
            batteryRangeValidator.MinimumTemperature = 0;
            batteryRangeValidator.MaximumTemperature = 45;
            batteryRangeValidator.MinimumSoc = 20;
            batteryRangeValidator.MaximumSoc = 80;
            batteryRangeValidator.MaximumChargeRate = 0.8f;

            Logger.LogBatteryState(IsBatteryOk(-1, 70, 0.7f));
            Logger.LogBatteryState(IsBatteryOk(25, 70, 0.7f));
            Logger.LogBatteryState(IsBatteryOk(46, 70, 0.7f));

            Logger.LogBatteryState(IsBatteryOk(25, 10, 0.7f));
            Logger.LogBatteryState(IsBatteryOk(25, 70, 0.7f));
            Logger.LogBatteryState(IsBatteryOk(25, 81, 0.7f));

            Logger.LogBatteryState(IsBatteryOk(25, 70, 0.7f));
            Logger.LogBatteryState(IsBatteryOk(25, 70, 0.8f));

            Logger.LogBreachLevel(BreachChecker.GetBreachLevel(batteryRangeValidator.MaximumTemperature,
                batteryRangeValidator.MinimumTemperature,
                -1),"Temperature");
            Logger.LogBreachLevel(BreachChecker.GetBreachLevel(batteryRangeValidator.MaximumTemperature,
                batteryRangeValidator.MinimumTemperature,
                25),"Temperature");
            Logger.LogBreachLevel(BreachChecker.GetBreachLevel(batteryRangeValidator.MaximumTemperature,
                batteryRangeValidator.MinimumTemperature,
                46),"Temperature");

            Logger.LogBreachLevel(BreachChecker.GetBreachLevel(batteryRangeValidator.MaximumSoc,
                batteryRangeValidator.MinimumSoc,
                10),"State of charge");
            Logger.LogBreachLevel(BreachChecker.GetBreachLevel(batteryRangeValidator.MaximumSoc,
                batteryRangeValidator.MinimumSoc,
                70),"State of charge");
            Logger.LogBreachLevel(BreachChecker.GetBreachLevel(batteryRangeValidator.MaximumSoc,
                batteryRangeValidator.MinimumSoc,
                81),"State of charge");

            Logger.LogBreachLevel(BreachChecker.GetBreachLevel(batteryRangeValidator.MaximumChargeRate,
                0,
                0.8f),"Charge rate");
            Logger.LogBreachLevel(BreachChecker.GetBreachLevel(batteryRangeValidator.MaximumChargeRate,
                0,
                0.7f),"Charge rate");
            Console.WriteLine("All ok");
            return 0;
        }
    }
}