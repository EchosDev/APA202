using _04_AccessModifiresEncupsulationNamespace.Models;

namespace _04_AccessModifiresEncupsulationNamespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car vehicle1 = new Car("Toyota", "Camry", 2020, 50, 10, 0);

            vehicle1.StartEngine();
            vehicle1.Drive(150);
            vehicle1.VehicleInfo();
            vehicle1.StopEngine();

            vehicle1.Refuel(40);
        }
    }
}
