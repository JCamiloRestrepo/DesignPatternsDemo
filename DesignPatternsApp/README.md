# Singleton Pattern

## Description
The Singleton pattern ensures that a class has only one instance and provides a global access point to it.

## Implementation
- A private static variable to hold the single instance.
- A private constructor to prevent external instantiation.
- A public static method to return the unique instance.

## Example Code (C#)
var instance1 = Singleton.GetInstance();
var instance2 = Singleton.GetInstance();
Console.WriteLine(instance1 == instance2 ? "Same instance" : "Different instances");

# Factory Pattern

## Description
The Factory Method pattern provides an interface for creating objects but allows subclasses to alter the type of objects that will be created.
It helps in decoupling the instantiation process from the client code.

## Implementation
- An interface or abstract class that defines a common behavior for the objects.
- Concrete classes that implement or extend the base interface/class.
- A Factory class that encapsulates the logic of object creation.

## Example Code (C#)
// Interface defining a common behavior
public interface IVehicle
{
    void ShowInfo();
}

// Concrete implementations
public class Car : IVehicle
{
    public void ShowInfo()
    {
        Console.WriteLine("🚗 Car created.");
    }
}

public class Motorcycle : IVehicle
{
    public void ShowInfo()
    {
        Console.WriteLine("🏍️ Motorcycle created.");
    }
}

// Factory class to create objects
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

// Usage
Console.Write("Enter vehicle type (car/motorcycle): ");
string? vehicleType = Console.ReadLine();

try
{
    IVehicle vehicle = VehicleFactory.CreateVehicle(vehicleType!);
    vehicle.ShowInfo();
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Error: {ex.Message}");
}