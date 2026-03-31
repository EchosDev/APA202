using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_UpcastingDowncastingExplicitImplicit.Models
{
    public class Manat
    {
        public decimal AZN { get; set; }

        public Manat(decimal azn)
        {
            AZN = azn;
        }

        public static implicit operator Manat(Dolar usd)
        {
            return new Manat (usd.USD * 1.7m);
        }
    }
}
