using DesignPatternsApp.BehavioralPatterns.Strategy.Interfaces;

namespace DesignPatternsApp.BehavioralPatterns.Strategy.Implementations
{
    public class PercentageDiscount : IDiscountStrategy
    {
        private readonly decimal _percentage;

        public PercentageDiscount(decimal percentage)
        {
            _percentage = percentage;
        }

        public decimal ApplyDiscount(decimal totalPrice)
        {
            return totalPrice - (totalPrice * _percentage / 100);
        }
    }
}
