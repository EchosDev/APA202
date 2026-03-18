using System;
using System.Collections.Generic;
using System.Text;

namespace _05_AbstractClassPolymorphismForEach.Models
{
    public abstract class Vehicle
    {
        private double _fuelLevel;

        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string PlateNumber { get; set; }
        public int MaxSpeed { get; set; }
        public double FuelLevel
        {
            get { return _fuelLevel; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _fuelLevel = value;
                }
                else
                {
                    Console.WriteLine("Benzin 0 ve 100 arasinda olmalidir!");
                }
            }
        }
        public Vehicle(string brand, string model, int year, string plateNumber, double fuelLevel)
        {
            Brand = brand;
            Model = model;
            Year = year;
            PlateNumber = plateNumber;
            FuelLevel = fuelLevel;
        }
        public string GetVehicleInfo()
        {
            return $"""
                Marka: {Brand}
                Model: {Model}
                Nomre nisani: {PlateNumber}
                """;
        }
        public void ShowBasicInfo()
        {
            Console.WriteLine($"""
                Marka: {Brand}
                Model: {Model}
                Il: {Year}
                Nomre nisani: {PlateNumber}
                Yanacaq seviyyasi: {FuelLevel}
                """);
        }
        public int GetVehicleMaxSpeed()
        {
            return MaxSpeed;
        }
        public abstract double CalculateFuelCost(double distance);
    }
}
