using System;
using System.Collections.Generic;
using System.Text;

namespace _05_AbstractClassPolymorphismForEach.Models
{
    internal class Truck : Vehicle
    {
        public double CargoCapacity { get; set; }
        public int AxleCount { get; set; }
        public double CurrentLoad { get; set; }

        public Truck(string brand, string model, int year, string plateNumber, double fuelLevel, double cargoCapacity, int axleCount, double currentLoad, int maxSpeed) : base(brand, model, year, plateNumber, fuelLevel)
        {
            CargoCapacity = cargoCapacity;
            AxleCount = axleCount;
            CurrentLoad = currentLoad;
            MaxSpeed = maxSpeed;
        }
        public void ShowTruckInfo()
        {
            Console.WriteLine($"""
                Marka: {Brand}
                Model: {Model}
                Il: {Year}
                Nomre nisani: {PlateNumber}
                Yanacaq seviyyasi: {FuelLevel}
                Yuk tutumu: {CargoCapacity} Ton
                Ox sayi: {AxleCount}
                Cari yuk: {CurrentLoad} Ton
                Maksimum suret: {MaxSpeed}
            """);
        }
        public void LoadCargo(double weight)
        {
            if (CurrentLoad + weight <= CargoCapacity)
            {
                Console.WriteLine($"""
                Yuklenen kargo: {weight} Ton
                Son yuk: {CurrentLoad += weight}
                """);
            }
            else
            {
                Console.WriteLine($"Diqqet!!! Kargo tutumu asildi! Cari yuk: {CurrentLoad}, Kargo tutumu: {CargoCapacity}");
            }
        }
        public override double CalculateFuelCost(double distance)
        {
            double spendingFuel = (25.0 + (CurrentLoad * 2)) / 100.0;
            double spendFuelOfDist = distance * spendingFuel;
            double fuelPrice = 1.5;

            return spendFuelOfDist * fuelPrice;
        }
    }
}
