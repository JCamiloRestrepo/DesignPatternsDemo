using DesignPatternsApp.BehavioralPatterns.Strategy.Interfaces;

namespace DesignPatternsApp.BehavioralPatterns.Strategy.Implementations
{
    public class FixedAmountDiscount : IDiscountStrategy
    {
        private readonly decimal _discountAmount;

        public FixedAmountDiscount(decimal discountAmount)
        {
            _discountAmount = discountAmount;
        }

        public decimal ApplyDiscount(decimal totalPrice)
        {
            return Math.Max(0, totalPrice - _discountAmount); // Ensure price is not negative
        }
    }
}
