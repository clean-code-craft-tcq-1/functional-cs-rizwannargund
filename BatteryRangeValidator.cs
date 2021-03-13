
namespace BatteryManagementSystem
{
    public class BatteryRangeValidator : IValidator
    {
        public float MinimumTemperature { get; set; }
        public float MaximumTemperature { get; set; }
        public float MinimumSoc { get; set; }
        public float MaximumSoc { get; set; }
        public float MaximumChargeRate { get; set; }

        public bool IsTemperatureRangeValid(float temperature)
            => !(temperature < MinimumTemperature || temperature > MaximumTemperature);
        //{
        //    if (temperature < MinimumTemperature || temperature > MaximumTemperature)
        //    {
        //        Logger.Log("Temperature is out of range!");
        //        return false;
        //    }

        //    Logger.Log("Temperature is within range.");
        //    return true;
        //}

        public bool IsSocRangeValid(float soc)
            => !(soc < MinimumSoc || soc > MaximumSoc);
        //{
        //    if (soc < MinimumSoc || soc > MaximumSoc)
        //    {
        //        Logger.Log("State of Charge is out of range!");
        //        return false;
        //    }
        //    Logger.Log("State of Charge is within range.");
        //    return true;
        //}

        public bool IsChargeRateRangeValid(float chargeRate)
            => !(chargeRate > MaximumChargeRate);
        //{
        //    if (chargeRate > MaximumChargeRate)
        //    {
        //        Logger.Log("Charge Rate is out of range!");
        //        return false;
        //    }

        //    Logger.Log("Charge Rate is within range.");
        //    return true;
        //}
    }
}
