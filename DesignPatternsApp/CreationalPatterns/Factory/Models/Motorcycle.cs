using DesignPatternsApp.CreationalPatterns.Factory.Interfaces;

namespace DesignPatternsApp.CreationalPatterns.Factory.Models
{
    public class Motorcycle : IVehicle
    {
        public void ShowInfo()
        {
            Console.WriteLine("🏍️ This is a Motorcycle.");
        }
    }
}
