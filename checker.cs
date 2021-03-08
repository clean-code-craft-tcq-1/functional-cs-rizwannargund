using System;
using System.Diagnostics;

namespace BatteryManagementSystem
{
    public class BatteryStateChecker
    {
        public static bool IsTemperatureValid(BatteryStateControl batteryStateControl)
        {
            return new TemperatureValidator().IsValid(batteryStateControl);
        }
        public static bool IsStateOfChargeValid(BatteryStateControl batteryStateControl)
        {
            return new StateOfChargeValidator().IsValid(batteryStateControl);
        }
        public static bool IsChargeRateValid(BatteryStateControl batteryStateControl)
        {
            return new ChargeRateValidator().IsValid(batteryStateControl);
        }
        public static BreachLevel GetTemperatureBreachLevel(BatteryStateControl batteryStateControl)
        {
            return new TemperatureValidator().GetBreachLevel(batteryStateControl);
        }
        public static BreachLevel GetChargeRateBreachLevel(BatteryStateControl batteryStateControl)
        {
            return new ChargeRateValidator().GetBreachLevel(batteryStateControl);
        }
        public static BreachLevel GetStateOfChargeBreachLevel(BatteryStateControl batteryStateControl)
        {
            return new StateOfChargeValidator().GetBreachLevel(batteryStateControl);
        }

        static int Main()
        {
            Debug.Assert(IsTemperatureValid(new BatteryStateControl(25, 65, 0.7f)));
            Debug.Assert(!IsTemperatureValid(new BatteryStateControl(50, 65, 0.7f)));

            Debug.Assert(IsStateOfChargeValid(new BatteryStateControl(25, 65, 0.7f)));
            Debug.Assert(!IsStateOfChargeValid(new BatteryStateControl(25, 105, 0.7f)));

            Debug.Assert(IsChargeRateValid(new BatteryStateControl(25, 65, 0.7f)));
            Debug.Assert(!IsChargeRateValid(new BatteryStateControl(25, 65, 0.9f)));

            Debug.Assert(GetTemperatureBreachLevel(new BatteryStateControl(-5, 65, 0.7f)) == BreachLevel.Low);
            Debug.Assert(GetTemperatureBreachLevel(new BatteryStateControl(15, 65, 0.7f)) == BreachLevel.Normal);
            Debug.Assert(GetTemperatureBreachLevel(new BatteryStateControl(80, 65, 0.7f)) == BreachLevel.High);

            Debug.Assert(GetStateOfChargeBreachLevel(new BatteryStateControl(15, 10, 0.7f)) == BreachLevel.Low);
            Debug.Assert(GetStateOfChargeBreachLevel(new BatteryStateControl(15, 50, 0.7f)) == BreachLevel.Normal);
            Debug.Assert(GetStateOfChargeBreachLevel(new BatteryStateControl(15, 100, 0.7f)) == BreachLevel.High);

            Debug.Assert(GetChargeRateBreachLevel(new BatteryStateControl(15, 65, 0.2f)) == BreachLevel.Low);
            Debug.Assert(GetChargeRateBreachLevel(new BatteryStateControl(15, 65, 0.7f)) == BreachLevel.Normal);

            Debug.Assert(GetChargeRateBreachLevel(new BatteryStateControl(15, 65, 0.9f)) == BreachLevel.High);
            Console.WriteLine("All ok");
            return 0;
        }
    }
}