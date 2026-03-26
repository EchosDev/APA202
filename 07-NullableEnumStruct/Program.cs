using _07_NullableEnumStruct.Enums;
using _07_NullableEnumStruct.Models;

namespace _07_NullableEnumStruct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DrinkOrder order1 = new(101, "Ali", DrinkType.Coffee, DrinkSize.Medium);
            Console.WriteLine("============================================");
            order1.DisplayOrder();
            Console.WriteLine("--------------------------------------------");
            order1.UpdateStatus(OrderStatus.Preparing);
            order1.DisplayOrder();
            Console.WriteLine("--------------------------------------------");
            order1.UpdateStatus(OrderStatus.Ready);
            order1.DisplayOrder();
            Console.WriteLine("--------------------------------------------");
            order1.UpdateStatus(OrderStatus.Delivered);
            order1.DisplayOrder();
            Console.WriteLine("============================================");

            DrinkOrder order2 = new(102, "Leyla", DrinkType.Tea, DrinkSize.Large);
            order2.DisplayOrder();
            Console.WriteLine("--------------------------------------------");
            order2.UpdateStatus(OrderStatus.Ready);
            order2.DisplayOrder();
            Console.WriteLine("============================================");

            DrinkOrder order3 = new(103, "Vuqar", DrinkType.Juice, DrinkSize.Small);
            order3.DisplayOrder();
            Console.WriteLine("============================================");

            Console.WriteLine("Ickilerimiz:");
            foreach (DrinkType drink in Enum.GetValues(typeof(DrinkType)))
            {
                Console.WriteLine(drink + " ");
            }

            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Icki Olculerimiz:");
            foreach (DrinkSize size in Enum.GetValues(typeof(DrinkSize)))
            {
                Console.WriteLine(size + " ");
            }

            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Sifaris Durumlarimiz:");
            foreach (OrderStatus status in Enum.GetValues(typeof(OrderStatus)))
            {
                Console.WriteLine(status + " ");
            }

            Console.WriteLine("============================================");

            Console.WriteLine((int)DrinkType.Tea + " " + DrinkType.Tea.ToString());
            Console.WriteLine((int)DrinkSize.Large + " " + DrinkSize.Large.ToString());

            Console.WriteLine("============================================");

            DrinkOrder[] orders = { order1, order2, order3 };

            decimal totalPrice = 0;

            foreach (DrinkOrder order in orders)
            {
                totalPrice += order.price;
            }

            Console.WriteLine("Statistika");
            Console.WriteLine($"""
                Umumi Sifaris:{orders.Length}
                Birinci Sifarisin Qiymeti:{order1.price}
                Ikinci Sifarisin Qiymeti:{order2.price}
                Ucuncu Sifarisin Qiymeti:{order3.price}
                Umimu Mebleg: {totalPrice}
                """);
        }
    }
}
