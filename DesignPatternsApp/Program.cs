using DesignPatternsApp.CreationalPatterns.Singleton;
using DesignPatternsApp.CreationalPatterns.Factory.Factories;
using DesignPatternsApp.BehavioralPatterns.Strategy.Context;
using DesignPatternsApp.BehavioralPatterns.Strategy.Implementations;
using DesignPatternsApp.BehavioralPatterns.Strategy.Interfaces;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Seleccione un patrón de diseño para probar:");
            Console.WriteLine("1 - Singleton");
            Console.WriteLine("2 - Factory");
            Console.WriteLine("3 - Strategy");
            Console.WriteLine("0 - Salir");
            Console.Write("Opción: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TestSingleton();
                    break;
                case "2":
                    TestFactory();
                    break;
                case "3":
                    TestStrategy();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void TestSingleton()
    {
        Console.WriteLine("\n🔹 Probando Singleton:");
        var instance1 = Singleton.GetInstance();
        var instance2 = Singleton.GetInstance();

        Console.WriteLine(instance1.Data);
        Console.WriteLine(instance1 == instance2
            ? "✅ Singleton funciona: ambas instancias son iguales"
            : "❌ Error: instancias diferentes");
    }

    static void TestFactory()
    {
        Console.WriteLine("\n🔹 Probando Factory:");
        Console.Write("Ingrese el tipo de vehículo (car/motorcycle): ");
        string? vehicleType = Console.ReadLine();

        try
        {
            var vehicle = VehicleFactory.CreateVehicle(vehicleType!);
            vehicle.ShowInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
    }

    static void TestStrategy()
    {
        Console.WriteLine("\n🔹 Probando Strategy:");
        Console.Write("Ingrese el precio total: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal totalPrice))
        {
            Console.WriteLine("❌ Error: Entrada inválida.");
            return;
        }

        Console.Write("Seleccione el tipo de descuento (none, percentage, fixed): ");
        string? discountType = Console.ReadLine();

        IDiscountStrategy discountStrategy = discountType?.ToLower() switch
        {
            "percentage" => new PercentageDiscount(10), // 10% de descuento
            "fixed" => new FixedAmountDiscount(5), // Descuento fijo de $5
            _ => new NoDiscount()
        };

        var calculator = new PriceCalculator(discountStrategy);
        decimal finalPrice = calculator.CalculateFinalPrice(totalPrice);

        Console.WriteLine($"💰 Precio final después del descuento: {finalPrice:C}");
    }
}