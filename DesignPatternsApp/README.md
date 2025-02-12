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

# Strategy Pattern

## Description
The Strategy pattern defines a family of algorithms, encapsulates each one, and makes them interchangeable. 
This allows selecting an algorithm at runtime instead of implementing multiple conditional statements.

## Implementation
- An interface that defines a common behavior for different strategies.
- Concrete strategy classes that implement the interface.
- A context class that utilizes a strategy instance to perform operations.

## Example Code (C#)
// Strategy interface
public interface IDiscountStrategy
{
    decimal ApplyDiscount(decimal price);
}

// Concrete strategies
public class NoDiscount : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal price) => price;
}

public class PercentageDiscount : IDiscountStrategy
{
    private readonly decimal _percentage;
    public PercentageDiscount(decimal percentage) => _percentage = percentage;
    public decimal ApplyDiscount(decimal price) => price - (price * _percentage / 100);
}

public class FixedAmountDiscount : IDiscountStrategy
{
    private readonly decimal _amount;
    public FixedAmountDiscount(decimal amount) => _amount = amount;
    public decimal ApplyDiscount(decimal price) => price - _amount;
}

// Context class
public class PriceCalculator
{
    private readonly IDiscountStrategy _discountStrategy;
    public PriceCalculator(IDiscountStrategy discountStrategy) => _discountStrategy = discountStrategy;
    public decimal CalculateFinalPrice(decimal price) => _discountStrategy.ApplyDiscount(price);
}

// Usage
Console.Write("Enter total price: ");
if (decimal.TryParse(Console.ReadLine(), out decimal totalPrice))
{
    Console.Write("Select discount type (none, percentage, fixed): ");
    string? discountType = Console.ReadLine();
    IDiscountStrategy discountStrategy = discountType?.ToLower() switch
    {
        "percentage" => new PercentageDiscount(10), // 10% discount
        "fixed" => new FixedAmountDiscount(5), // Fixed $5 discount
        _ => new NoDiscount()
    };
    var calculator = new PriceCalculator(discountStrategy);
    decimal finalPrice = calculator.CalculateFinalPrice(totalPrice);
    Console.WriteLine($"💰 Final price after discount: {finalPrice:C}");
}
else
{
    Console.WriteLine("❌ Invalid input.");
}