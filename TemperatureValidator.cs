namespace BatteryManagementSystem
{
    public class TemperatureValidator : IValidator<BatteryStateControl>
    {
        private static readonly float minimum = 0;

        private static readonly float maximum = 45;

        public bool IsValid(BatteryStateControl batteryStateControl)
        {
            return !(batteryStateControl.Temperature < minimum || batteryStateControl.Temperature > maximum);
        }

        public BreachLevel GetBreachLevel(BatteryStateControl batteryStateControl)
        {
            if (batteryStateControl.Temperature < minimum)
            {
                return BreachLevel.Low;
            }
            else if (batteryStateControl.Temperature > maximum)
            {
                return BreachLevel.High;
            }
            return BreachLevel.Normal;
        }

    }
}
