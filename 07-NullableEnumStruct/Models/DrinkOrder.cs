using _07_NullableEnumStruct.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace _07_NullableEnumStruct.Models
{
    internal class DrinkOrder
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DrinkType Drink { get; set; }
        public DrinkSize Size { get; set; }
        public OrderStatus Status { get; set; }
        public decimal price { get; set; }

        public DrinkOrder(int orderNumber, string customerName, DrinkType drink, DrinkSize size)
        {
            OrderNumber = orderNumber;
            CustomerName = customerName;
            Drink = drink;
            Size = size;
            Status = OrderStatus.New;
            price = CalculatePrice();
        }

        public void DisplayOrder()
        {
            Console.WriteLine($"""
                Order Number:{OrderNumber}
                Customer Name:{CustomerName}
                Drink Type:{Drink}
                Drink Size:{Size}
                Status:{Status}
                Price:{price}
                """);
        }

        public decimal CalculatePrice()
        {
            switch (Drink)
            {
                case DrinkType.Coffee:
                    if (Size == DrinkSize.Small) return 3m;
                    else if (Size == DrinkSize.Medium) return 4m;
                    else if (Size == DrinkSize.Large) return 5m;
                    break;
                case DrinkType.Tea:
                    if (Size == DrinkSize.Small) return 2m;
                    else if (Size == DrinkSize.Medium) return 3m;
                    else if (Size == DrinkSize.Large) return 4m;
                    break;
                case DrinkType.Juice:
                    if (Size == DrinkSize.Small) return 4m;
                    else if (Size == DrinkSize.Medium) return 5m;
                    else if (Size == DrinkSize.Large) return 6m;
                    break;
                case DrinkType.Water:
                    if (Size == DrinkSize.Small) return 1m;
                    else if (Size == DrinkSize.Medium) return 1.5m;
                    else if (Size == DrinkSize.Large) return 2m;
                    break;
            }
            return 0m;
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"Sifariş #{OrderNumber} statusu: {newStatus}");
        }

    }
}
