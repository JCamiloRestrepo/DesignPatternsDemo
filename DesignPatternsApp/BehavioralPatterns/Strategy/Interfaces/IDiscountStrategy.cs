namespace DesignPatternsApp.BehavioralPatterns.Strategy.Interfaces
{
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal totalPrice);
    }
}
