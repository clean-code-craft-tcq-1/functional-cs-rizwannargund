namespace BatteryManagementSystem
{
    public class TemperatureValidator : IValidator<BatteryMonitor>
    {
        private static readonly float minimum = 0;

        private static readonly float maximum = 45;

        public bool IsValid(BatteryMonitor batteryMonitor)
        {
            return !(batteryMonitor.Temperature < minimum || batteryMonitor.Temperature > maximum);
        }

        public BreachLevel GetBreachLevel(BatteryMonitor batteryMonitor)
        {
            if (batteryMonitor.Temperature < minimum)
            {
                return BreachLevel.Low;
            }
            else if (batteryMonitor.Temperature > maximum)
            {
                return BreachLevel.High;
            }
            return BreachLevel.Normal;
        }

    }
}
