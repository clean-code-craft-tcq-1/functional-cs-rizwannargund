namespace BatteryManagementSystem
{
    public class ChargeRateValidator: IValidator<BatteryStateControl>
    {
        static readonly float maximum = 0.8f;

        static readonly float minimum = 0.3f;

        public bool IsValid(BatteryStateControl batteryStateControl)
        {
            return !(batteryStateControl.ChargeRate > maximum);
        }

        public BreachLevel GetBreachLevel(BatteryStateControl batteryStateControl)
        {
            if (batteryStateControl.ChargeRate < minimum)
            {
                return BreachLevel.Low;
            }
            else if (batteryStateControl.ChargeRate > maximum)
            {
                return BreachLevel.High;
            }
            return BreachLevel.Normal;
        }
    }
}
