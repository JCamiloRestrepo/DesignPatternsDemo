using DesignPatternsApp.CreationalPatterns.Factory.Factories;
using DesignPatternsApp.CreationalPatterns.Factory.Interfaces;
using DesignPatternsApp.CreationalPatterns.Factory.Models;
using Xunit;

namespace DesignPatternsTests.Tests
{
    public class VehicleFactoryTests
    {
        [Fact]
        public void CreateVehicle_ShouldReturnCar_WhenTypeIsCar()
        {
            IVehicle vehicle = VehicleFactory.CreateVehicle("car");
            Assert.IsType<Car>(vehicle);
        }

        [Fact]
        public void CreateVehicle_ShouldReturnMotorcycle_WhenTypeIsMotorcycle()
        {
            IVehicle vehicle = VehicleFactory.CreateVehicle("motorcycle");
            Assert.IsType<Motorcycle>(vehicle);
        }

        [Fact]
        public void CreateVehicle_ShouldThrowException_WhenTypeIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => VehicleFactory.CreateVehicle("bicycle"));
        }
    }
}