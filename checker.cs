using System;
using System.Diagnostics;

namespace BatteryManagementSystem
{
    public class BatteryStateChecker
    {
        public static bool IsTemperatureValid(BatteryMonitor batteryMonitor)
        {
            return new TemperatureValidator().IsValid(batteryMonitor);
        }
        public static bool IsStateOfChargeValid(BatteryMonitor batteryMonitor)
        {
            return new StateOfChargeValidator().IsValid(batteryMonitor);
        }
        public static bool IsChargeRateValid(BatteryMonitor batteryMonitor)
        {
            return new ChargeRateValidator().IsValid(batteryMonitor);
        }
        public static BreachLevel GetTemperatureBreachLevel(BatteryMonitor batteryMonitor)
        {
            return new TemperatureValidator().GetBreachLevel(batteryMonitor);
        }
        public static BreachLevel GetChargeRateBreachLevel(BatteryMonitor batteryMonitor)
        {
            return new ChargeRateValidator().GetBreachLevel(batteryMonitor);
        }
        public static BreachLevel GetStateOfChargeBreachLevel(BatteryMonitor batteryMonitor)
        {
            return new StateOfChargeValidator().GetBreachLevel(batteryMonitor);
        }

        static int Main()
        {
            Debug.Assert(IsTemperatureValid(new BatteryMonitor(25, 65, 0.7f)));
            Debug.Assert(!IsTemperatureValid(new BatteryMonitor(50, 65, 0.7f)));

            Debug.Assert(IsStateOfChargeValid(new BatteryMonitor(25, 65, 0.7f)));
            Debug.Assert(!IsStateOfChargeValid(new BatteryMonitor(25, 105, 0.7f)));

            Debug.Assert(IsChargeRateValid(new BatteryMonitor(25, 65, 0.7f)));
            Debug.Assert(!IsChargeRateValid(new BatteryMonitor(25, 65, 0.9f)));

            Debug.Assert(GetTemperatureBreachLevel(new BatteryMonitor(-5, 65, 0.7f)) == BreachLevel.Low);
            Debug.Assert(GetTemperatureBreachLevel(new BatteryMonitor(15, 65, 0.7f)) == BreachLevel.Normal);
            Debug.Assert(GetTemperatureBreachLevel(new BatteryMonitor(80, 65, 0.7f)) == BreachLevel.High);

            Debug.Assert(GetStateOfChargeBreachLevel(new BatteryMonitor(15, 10, 0.7f)) == BreachLevel.Low);
            Debug.Assert(GetStateOfChargeBreachLevel(new BatteryMonitor(15, 50, 0.7f)) == BreachLevel.Normal);
            Debug.Assert(GetStateOfChargeBreachLevel(new BatteryMonitor(15, 100, 0.7f)) == BreachLevel.High);

            Debug.Assert(GetChargeRateBreachLevel(new BatteryMonitor(15, 65, 0.2f)) == BreachLevel.Low);
            Debug.Assert(GetChargeRateBreachLevel(new BatteryMonitor(15, 65, 0.7f)) == BreachLevel.Normal);

            Debug.Assert(GetChargeRateBreachLevel(new BatteryMonitor(15, 65, 0.9f)) == BreachLevel.High);
            Console.WriteLine("All ok");
            return 0;
        }
    }
}