using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_UpcastingDowncastingExplicitImplicit.Models
{
    public class Eagle : Animal
    {
        public int FlySpeed { get; set; }

        public void Fly()
        {
            Console.WriteLine("Eagle flied away");
        }
    }
}
