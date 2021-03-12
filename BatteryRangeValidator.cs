
namespace BatteryManagementSystem
{
    public class BatteryRangeValidator: IValidator
    {
        public float MinimumTemperature { get; set; }
        public float MaximumTemperature { get; set; }
        public float MinimumSoc { get; set; }
        public float MaximumSoc { get; set; }
        public float MaximumChargeRate { get; set; }

        public bool IsTemperatureRangeValid(float temperature)
        {
            if (temperature < MinimumTemperature || temperature > MaximumTemperature)
            {
                Logger.PrintMessage("Temperature is out of range!");
                return false;
            }
            else
            {
                Logger.PrintMessage("Temperature is within range.");
                return true;
            }
        }

        public bool IsSocRangeValid(float soc)
        {
            if (soc < MinimumSoc || soc > MaximumSoc)
            {
                Logger.PrintMessage("State of Charge is out of range!");
                return false;
            }
            else
            {
                Logger.PrintMessage("State of Charge is within range.");
                return true;
            }
        }

        public bool IsChargeRateRangeValid(float chargeRate)
        {
            if (chargeRate > MaximumChargeRate)
            {
                Logger.PrintMessage("Charge Rate is out of range!");
                return false;
            }
            else
            {
                Logger.PrintMessage("Charge Rate is within range.");
                return true;
            }
        }
    }
}
