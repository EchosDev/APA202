using System.Runtime.Serialization.Formatters;

namespace _01_C_IntroMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            //Console.WriteLine(Math('*', 3, 4));

            //2
            //Console.Write("Nece eded daxil etmek isteyirsiniz:");
            //int countNums = Convert.ToInt32(Console.ReadLine());
            //int[] nums = new int[countNums];

            //for (int i = 0; i < countNums; i++)
            //{
            //    Console.Write("Eded daxil edin: ");
            //    nums[i] = Convert.ToInt32(Console.ReadLine());
            //}

            //EvenOrOddInArray("tek", nums);

            //3
            //Console.Write("Nece eded daxil etmek isteyirsiniz:");
            //int countNums = Convert.ToInt32(Console.ReadLine());
            //int[] nums = new int[countNums];

            //for (int i = 0; i < countNums; i++)
            //{
            //    Console.Write("Eded daxil edin: ");
            //    nums[i] = Convert.ToInt32(Console.ReadLine());
            //}

            //Console.WriteLine($"Veirlmis siyahida 4-e ve 5-e bolunen ededlerin cemi: {SumDivision(nums)}");   

            //4
            //Console.Write("Cumleni daxil edin: ");
            //string sentence = Console.ReadLine();
            //Console.Write("Tapilmali simvolu daxil edin: ");
            //char symbol = Convert.ToChar(Console.ReadLine());

            //Console.WriteLine($"Verilmis cumlede {symbol}-dan {CountSymbolOnSentence(sentence,symbol)} sayda var");
        }
        //1:Hər biri 2 parametr qəbul edib və riyazi əməlləri yerinə yetiren method yazin.
        static int Math(char symbol, int firstNum, int secondNumber)
        {
            int result = -1;
            switch (symbol)
            {
                case '+':
                    result = firstNum + secondNumber;
                    break;
                case '-':
                    result = firstNum - secondNumber;
                    break;
                case '*':
                    result = firstNum * secondNumber;
                    break;
                case '/':
                    if (secondNumber != 0)
                        result = firstNum / secondNumber;
                    break;
            }
            return result;
        }
        //2:Verilen arqumentlere uygun tek ve cut edeleri tapan method yazin.(14, 20, 35, 40, 57, 60, 100)
        static void EvenOrOddInArray(string option, int[] nums)
        {
            if (option == "tek")
            {
                Console.Write("Tek Ededlerin siyahisi: ");
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 != 0)
                    {
                        Console.Write(nums[i] + " ");
                    }
                }
            }
            else if (option == "cut")
            {
                Console.Write("Cut Ededlerin siyahisi: ");
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 == 0)
                    {
                        Console.Write(nums[i] + " ");
                    }
                }
            }
        }
        //3:Verilmis arreyde elementlerin həm 4-ə, həm də 5-ə bölününen elementlerin cemini tapin.[14, 20, 35, 40, 57, 60, 100]
        static int SumDivision(int[] nums)
        {
            int result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 4 == 0 && nums[i] % 5 == 0)
                {
                    result += nums[i];
                }
            }
            return result;
        }

        //4:Daxil edilmiş cümlədə daxil edilmis simvoldan nece eded olduğunu tapan Proqramın alqoritmini yazin.(Cumle serbestdir).
        static int CountSymbolOnSentence(string sentence, char symbol)
        {
            int count = 0;
            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] == symbol)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                return -1;
            }
            else
            {
                return count;
            }
        }

    }
}
