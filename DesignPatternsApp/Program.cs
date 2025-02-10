using DesignPatternsApp.CreationalPatterns.Singleton;
using DesignPatternsApp.CreationalPatterns.Factory.Factories;

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
}