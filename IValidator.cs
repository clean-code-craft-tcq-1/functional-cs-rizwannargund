namespace BatteryManagementSystem
{
    public interface IValidator<T>
    {
        bool IsValid(T t);

        BreachLevel GetBreachLevel(T t);
    }

    public enum BreachLevel
    {
        Low,
        Normal,
        High
    }
}
