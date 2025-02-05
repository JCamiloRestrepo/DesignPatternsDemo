using DesignPatternsApp.CreationalPatterns;
class Program
{
    static void Main()
    {
        var instance1 = Singleton.GetInstance();
        var instance2 = Singleton.GetInstance();

        Console.WriteLine(instance1.Data);
        Console.WriteLine(instance1 == instance2 ? "Singleton funciona: ambas instancias son iguales" : "Error: instancias diferentes");
    }
}
