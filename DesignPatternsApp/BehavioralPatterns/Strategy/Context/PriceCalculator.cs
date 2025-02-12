using DesignPatternsApp.BehavioralPatterns.Strategy.Interfaces;

namespace DesignPatternsApp.BehavioralPatterns.Strategy.Context
{
    public class PriceCalculator
    {
        private IDiscountStrategy _discountStrategy;

        public PriceCalculator(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }

        public void SetDiscountStrategy(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }

        public decimal CalculateFinalPrice(decimal totalPrice)
        {
            return _discountStrategy.ApplyDiscount(totalPrice);
        }
    }

}
