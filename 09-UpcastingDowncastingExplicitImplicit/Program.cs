using _09_UpcastingDowncastingExplicitImplicit.Models;

namespace _09_UpcastingDowncastingExplicitImplicit
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Upcasting Downcasting
            Dog dog = new Dog { AvgLifeTime = 23, Breed = "Haski", Gender = "Male", Name = "Hatiko" };
            Eagle eagle = new Eagle { AvgLifeTime = 50, FlySpeed = 200, Gender = "Female" };

            Animal animal1 = dog;
            Animal animal2 = eagle;

            Dog dog1 = animal1 as Dog;
            Eagle eagle1 = (Eagle)animal2;


            Animal[] animals = { dog, eagle };

            foreach (var animal in animals)
            {
                //1
                //Eagle _eagle = animal as Eagle;

                //if (_eagle != null)
                //{
                //    _eagle.Fly();
                //}

                //2
                if (animal is Eagle)
                {
                    Eagle _eagle = animal as Eagle;
                }
                else
                {
                    Dog _dog = animal as Dog;
                }
            }
            #endregion

            #region Boxing And Unboxing
            int a = 5;
            Object b = a;

            int c = (int)b;

            Test test1 = new Test();

            ITest test2 = test1;

            Test test3 = (Test)test2;

            #endregion

            Manat manat = new(170);
            Dolar dolar = new(100);

            Dolar dolar1 = manat;
            Console.WriteLine(dolar1.USD);

            Manat manat1 = dolar;
            Console.WriteLine(manat1.AZN);


        }

        public struct Test : ITest
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public interface ITest
        {
            int Y { get; set; }
        }
    }
}
