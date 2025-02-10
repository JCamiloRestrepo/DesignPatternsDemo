using DesignPatternsApp.CreationalPatterns.Factory.Interfaces;
using DesignPatternsApp.CreationalPatterns.Factory.Models;

namespace DesignPatternsApp.CreationalPatterns.Factory.Factories
{
    public static class VehicleFactory
    {
        public static IVehicle CreateVehicle(string type)
        {
            return type.ToLower() switch
            {
                "car" => new Car(),
                "motorcycle" => new Motorcycle(),
                _ => throw new ArgumentException("Invalid vehicle type")
            };
        }
    }
}
