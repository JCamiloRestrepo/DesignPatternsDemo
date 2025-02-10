using Xunit;
using DesignPatternsApp.CreationalPatterns.Singleton;

namespace DesignPatternsTests.Tests
{
    public class SingletonTests
    {
        [Fact]
        public void Singleton_Should_ReturnSameInstance()
        {
            // Arrange & Act
            var instance1 = Singleton.GetInstance();
            var instance2 = Singleton.GetInstance();

            // Assert
            Assert.Same(instance1, instance2);
        }

        [Fact]
        public void Singleton_Should_HaveCorrectData()
        {
            // Arrange
            var instance = Singleton.GetInstance();

            // Assert
            Assert.Equal("Instancia única", instance.Data);
        }
    }
}
