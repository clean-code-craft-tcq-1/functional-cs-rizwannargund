
namespace BatteryManagementSystem
{
    public class BreachChecker
    {
        public static BreachLevel GetBreachLevel(float max, float min, float value)
        {
            if (min > value)
                return BreachLevel.Low;
            else if (max < value)
                return BreachLevel.High;
            return BreachLevel.Medium;
        }
    }

    public enum BreachLevel
    {
        Low,
        Medium,
        High
    }
}
