using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatteryManagementSystem
{
    interface IValidator
    {
        bool IsTemperatureRangeValid(float temperature);
        bool IsSocRangeValid(float soc);
        bool IsChargeRateRangeValid(float chargeRate);
    }
}
