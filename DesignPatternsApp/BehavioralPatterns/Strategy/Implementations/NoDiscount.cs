using DesignPatternsApp.BehavioralPatterns.Strategy.Interfaces;

namespace DesignPatternsApp.BehavioralPatterns.Strategy.Implementations
{
    public class NoDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal totalPrice)
        {
            return totalPrice; // No changes
        }
    }
}
