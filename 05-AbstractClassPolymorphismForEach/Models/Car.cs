using System;
using System.Collections.Generic;
using System.Text;

namespace _05_AbstractClassPolymorphismForEach.Models
{
    internal class Car : Vehicle
    {
        public int DoorsCount { get; set; }
        public int TrunkCapacity { get; set; }
        public bool IsAutomatic { get; set; }
        public Car(string brand, string model, int year, string plateNumber, double fuelLevel, int doorsCount, int trunkCapacity, bool isAutomatic, int maxSpeed) : base(brand, model, year, plateNumber, fuelLevel)
        {
            DoorsCount = doorsCount;
            TrunkCapacity = trunkCapacity;
            IsAutomatic = isAutomatic;
            MaxSpeed = maxSpeed;
        }
        public void ShowCarInfo()
        {
            Console.WriteLine($"""
                Marka: {Brand}
                Model: {Model}
                Il: {Year}
                Nomre nisani: {PlateNumber}
                Yanacaq seviyyasi: {FuelLevel}
                Qapi sayi: {DoorsCount}
                Baqaj tutumu: {TrunkCapacity}
                Avtomat: {IsAutomatic}
                Maksimum suret: {MaxSpeed}
                """);
        }
        public override double CalculateFuelCost(double distance)
        {
            double spendingFuel = 8.0 / 100.0;
            double spendFuelOfDist = distance * spendingFuel;
            double fuelPrice = 1.5;

            return spendFuelOfDist* fuelPrice;
        }
    }
}