namespace BatteryManagementSystem
{
    public class ChargeRateValidator: IValidator<BatteryMonitor>
    {
        static readonly float maximum = 0.8f;

        static readonly float minimum = 0.3f;

        public bool IsValid(BatteryMonitor batteryMonitor)
        {
            return !(batteryMonitor.ChargeRate > maximum);
        }

        public BreachLevel GetBreachLevel(BatteryMonitor batteryMonitor)
        {
            if (batteryMonitor.ChargeRate < minimum)
            {
                return BreachLevel.Low;
            }
            else if (batteryMonitor.ChargeRate > maximum)
            {
                return BreachLevel.High;
            }
            return BreachLevel.Normal;
        }
    }
}
