namespace BatteryManagementSystem
{
    public class StateOfChargeValidator : IValidator<BatteryStateControl>
    {
        private static readonly float minimum = 20;

        private static readonly float maximum = 80;

        public bool IsValid(BatteryStateControl batteryStateControl)
        {
            return !(batteryStateControl.StateOfCharge < minimum || batteryStateControl.StateOfCharge > maximum);
        }

        public BreachLevel GetBreachLevel(BatteryStateControl batteryStateControl)
        {
            if (batteryStateControl.StateOfCharge < minimum)
            {
                return BreachLevel.Low;
            }
            else if (batteryStateControl.StateOfCharge > maximum)
            {
                return BreachLevel.High;
            }
            return BreachLevel.Normal;
        }
    }
}