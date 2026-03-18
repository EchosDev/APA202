using _05_AbstractClassPolymorphismForEach.Models;

namespace _05_AbstractClassPolymorphismForEach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new("Mercedes", "E200", 2023, "10-BD-242", 100, 4, 500, true, 220);
            Car car2 = new("BMW", "320I", 2022, "99-AC-185", 100, 4, 480, true, 235);
            Car car3 = new("Toyoto", "Camry", 2021, "56-OO-037", 100, 4, 524, true, 210);

            Motorcycle moto1 = new("Yamaha", "R1", 2023, "48-RT-758", 100, 998, false, 299, "Sport");
            Motorcycle moto2 = new("Harley", "Davidson", 2022, "53-FD-558", 100, 1868, true, 180, "Cruiser");

            Truck truck1 = new("MAN", "TGX", 2020, "07-OK-438", 100, 18, 3, 12, 120);
            Truck truck2 = new("Volvo", "FH16", 2021, "37-BB-342", 100, 25, 4, 18, 110);

            Vehicle[] vehicles = { car1, car2, car3, moto1, moto2, truck1, truck2 };

            Console.WriteLine("=================================================================");
            car1.ShowCarInfo();
            Console.WriteLine("-----------------------------------------------------------------");
            car2.ShowCarInfo();
            Console.WriteLine("-----------------------------------------------------------------");
            car3.ShowCarInfo();
            Console.WriteLine("=================================================================");
            Console.WriteLine($"Benzin Qiymeti: {car1.CalculateFuelCost(500)}");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"Benzin Qiymeti: {car2.CalculateFuelCost(500)}");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"Benzin Qiymeti: {car3.CalculateFuelCost(500)}");
            Console.WriteLine("=================================================================");

            moto1.ShowMotorcycleInfo();
            Console.WriteLine("-----------------------------------------------------------------");
            moto2.ShowMotorcycleInfo();
            Console.WriteLine("=================================================================");
            Console.WriteLine($"Benzin Qiymeti: {moto1.CalculateFuelCost(300)}");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"Benzin Qiymeti: {moto1.CalculateFuelCost(300)}");
            Console.WriteLine("=================================================================");


            truck1.ShowTruckInfo();
            Console.WriteLine("-----------------------------------------------------------------");
            truck2.ShowTruckInfo();
            Console.WriteLine("=================================================================");
            Console.WriteLine($"Benzin Qiymeti: {truck1.CalculateFuelCost(800)}");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"Benzin Qiymeti: {truck2.CalculateFuelCost(800)}");
            Console.WriteLine("=================================================================");

            truck1.LoadCargo(5);
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"Benzin Qiymeti: {truck1.CalculateFuelCost(800)}");
            Console.WriteLine("=================================================================");

            Console.WriteLine("--Statistika--");
            Console.WriteLine($"Umumi Neqliyat Sayi: {vehicles.Length}");

            int maxSpeeds = 0;
            double maxFuelCost = vehicles[0].CalculateFuelCost(200);
            Vehicle maxFuelCostVehicle = vehicles[0];

            foreach (var vehicle in vehicles)
            {
                maxSpeeds += vehicle.GetVehicleMaxSpeed();

                if (vehicle.CalculateFuelCost(200) > maxFuelCost)
                {
                    maxFuelCost = vehicle.CalculateFuelCost(200);
                    maxFuelCostVehicle = vehicle;
                }
            }

            Console.WriteLine($"Orta Maksimum suret: {maxSpeeds / vehicles.Length}");

            Console.WriteLine($"""

                En bahali yanacaq xerci olan neqliyat: 
                {maxFuelCostVehicle.GetVehicleInfo()}
                Yanacaq Xerci: {maxFuelCost}
                """);

            Console.WriteLine("=================================================================");
        }
    }
}
