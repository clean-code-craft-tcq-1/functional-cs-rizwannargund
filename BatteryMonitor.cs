namespace BatteryManagementSystem
{
    public class BatteryMonitor
    {
        public float Temperature { get; set; }
        public float StateOfCharge { get; set; }
        public float ChargeRate { get; set; }
        
        public BatteryMonitor(float temperature, float stateOfCharge, float chargeRate)
        {
            Temperature = temperature;
            StateOfCharge = stateOfCharge;
            ChargeRate = chargeRate;
        }
    }
}
