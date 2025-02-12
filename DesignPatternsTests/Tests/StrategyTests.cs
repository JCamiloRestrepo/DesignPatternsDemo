using DesignPatternsApp.BehavioralPatterns.Strategy.Context;
using DesignPatternsApp.BehavioralPatterns.Strategy.Implementations;
using Xunit;

namespace DesignPatternsTests.Tests
{
    public class PriceCalculatorTests
    {
        [Theory]
        [InlineData(100, 10, 90)] // 10% de 100 = 90
        [InlineData(200, 20, 160)] // 20% de 200 = 160
        public void CalculateFinalPrice_WithPercentageDiscount_ReturnsCorrectPrice(decimal initialPrice, decimal percentage, decimal expectedPrice)
        {
            // Arrange
            var discountStrategy = new PercentageDiscount(percentage);
            var calculator = new PriceCalculator(discountStrategy);

            // Act
            var finalPrice = calculator.CalculateFinalPrice(initialPrice);

            // Assert
            Assert.Equal(expectedPrice, finalPrice);
        }

        [Theory]
        [InlineData(100, 5, 95)] // 100 - 5 = 95
        [InlineData(50, 10, 40)] // 50 - 10 = 40
        public void CalculateFinalPrice_WithFixedAmountDiscount_ReturnsCorrectPrice(decimal initialPrice, decimal discountAmount, decimal expectedPrice)
        {
            // Arrange
            var discountStrategy = new FixedAmountDiscount(discountAmount);
            var calculator = new PriceCalculator(discountStrategy);

            // Act
            var finalPrice = calculator.CalculateFinalPrice(initialPrice);

            // Assert
            Assert.Equal(expectedPrice, finalPrice);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(50)]
        public void CalculateFinalPrice_WithNoDiscount_ReturnsSamePrice(decimal initialPrice)
        {
            // Arrange
            var discountStrategy = new NoDiscount();
            var calculator = new PriceCalculator(discountStrategy);

            // Act
            var finalPrice = calculator.CalculateFinalPrice(initialPrice);

            // Assert
            Assert.Equal(initialPrice, finalPrice);
        }
    }
}
