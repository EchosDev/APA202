using _06_InterfaceAbstraction.Models;

namespace _06_InterfaceAbstraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculation calc = new();

            Console.WriteLine("Birinci ededi daxil edin:");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ikinci ededi daxil edin:");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Emeliyati daxil edin:");
            char symbol = Convert.ToChar(Console.ReadLine());

            Console.WriteLine($"Netice: {calc.Calculate(a, b, symbol)}");
        }
    }
}
