namespace BatteryManagementSystem
{
    public class StateOfChargeValidator : IValidator<BatteryMonitor>
    {
        private static readonly float minimum = 20;

        private static readonly float maximum = 80;

        public bool IsValid(BatteryMonitor batteryMonitor)
        {
            return !(batteryMonitor.StateOfCharge < minimum || batteryMonitor.StateOfCharge > maximum);
        }

        public BreachLevel GetBreachLevel(BatteryMonitor batteryMonitor)
        {
            if (batteryMonitor.StateOfCharge < minimum)
            {
                return BreachLevel.Low;
            }
            else if (batteryMonitor.StateOfCharge > maximum)
            {
                return BreachLevel.High;
            }
            return BreachLevel.Normal;
        }
    }
}