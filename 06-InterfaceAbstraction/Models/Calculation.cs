using _06_InterfaceAbstraction.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_InterfaceAbstraction.Models
{
    class Calculation : ICalculation
    {
        public double Calculate(double a, double b, char symbol)
        {
            switch (symbol)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        Console.WriteLine("0-a bolmek olmaz!");
                        return 0;
                    }

                    return a / b;

                default:
                    Console.WriteLine("Yansil emeliyat daxil etmisiniz");
                    return 0;
            }
        }
    }
}
