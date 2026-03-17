using System;
using System.Collections.Generic;
using System.Text;

namespace _04_AccessModifiresEncupsulationNamespace.Models
{
    internal class Vehicle
    {
        private string _brand;
        private int _year;
        public string Brand
        {
            get { return _brand; }
            set
            {
                if (value.Length >= 3)
                    _brand = value;
                else
                    Console.WriteLine("Brand minimum 3 simvol olmalıdır");
            }
        }
        public int Year
        {
            get { return _year; }
            set
            {
                if (value > 1900)
                    _year = value;
                else
                    Console.WriteLine("Year 1900-dən böyük olmalidır");
            }
        }
        public string Model { get; set; }
        public double MileageKm { get; set; }
        public bool IsRunning { get; set; }
        public Vehicle(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }
        public void StartEngine()
        {
            if (!IsRunning)
            {
                IsRunning = true;
                Console.WriteLine("Muherrik ise salindi");
            }
            else
            {
                Console.WriteLine("Muherrik zaten isleyir");
            }
        }
        public void StopEngine()
        {
            if (IsRunning)
            {
                IsRunning = false;
                Console.WriteLine("Muherrik sonduruldu");
            }
            else
            {
                Console.WriteLine("Muherrik zaten sondurulmusdur");
            }
        }
        public void Drive(int km)
        {
            if (IsRunning)
            {
                MileageKm += km;
                Console.WriteLine($"Masin {km} km yol qet etdi. Umumi yol: {MileageKm} km");
            }
            else
            {
                Console.WriteLine("Muherrik ise salinmadan surmek olmaz");
            }
        }
        public void VehicleInfo()
        {
            Console.WriteLine($"""
                Brand: {Brand}
                Model: {Model}
                Year: {Year}
                Mileage: {MileageKm} km
                Running: {IsRunning}
                """);
        }

    }
}
