using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace _05_AbstractClassPolymorphismForEach.Models
{
    internal class Motorcycle : Vehicle
    {
        private string _type;

        public int EngineCapacity { get; set; }
        public bool HasSidecar { get; set; }
        public string Type
        {
            get { return _type; }
            set
            {
                if (value == "Sport" || value == "Cruiser" || value == "Touring")
                {
                    _type = value;
                }
                else
                {
                    Console.WriteLine("Duzgun tip qeyd olunmayib! INFO - Movcud tipler: Sport, Cruiser, Touring");
                }
            }
        }

        public Motorcycle(string brand, string model, int year, string plateNumber, double fuelLevel, int engineCapacity, bool hasSidecar, int maxSpeed, string type): base(brand, model, year, plateNumber, fuelLevel)
        {
            EngineCapacity = engineCapacity;
            HasSidecar = hasSidecar;
            MaxSpeed = maxSpeed;
            Type = type;
        }

        public void ShowMotorcycleInfo()
        {
            Console.WriteLine($"""
                Marka: {Brand}
                Model: {Model}
                Il: {Year}
                Nomre nisani: {PlateNumber}
                Yanacaq seviyyasi: {FuelLevel}
                Muherrik hecmi (CC): {EngineCapacity}
                Yan araba var: {HasSidecar}
                Maksimum suret: {MaxSpeed}
                Tip: {Type}
                """);
        }

        public override double CalculateFuelCost(double distance)
        {
            double spendingFuel = 4.0 / 100.0;
            double spendFuelOfDist = distance * spendingFuel;
            double fuelPrice = 1.5;

            return spendFuelOfDist * fuelPrice;
        }

    }
}