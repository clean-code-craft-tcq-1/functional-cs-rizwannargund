
using System;

namespace BatteryManagementSystem
{
    public class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine(message);
        }

        public static void LogBatteryState(bool isStateOk)
        {
            if (isStateOk)
            {
                Log("Battery state is normal");
                return;
            }
            Log("Battery state is critical");
        }

        public static void LogBreachLevel(BreachLevel breachLevel, string factor)
        {
            switch (breachLevel)
            {
                case BreachLevel.Low:
                    Log(string.Format("{0} is below miniumum limit!",factor));
                    break;
                case BreachLevel.High:
                    Log(string.Format("{0} is above maximum limit!", factor));
                    break;
                default:
                    Log(string.Format("{0} is normal", factor));
                    break;
            }
        }

    }
}
