namespace _02_HeapStackRefOutArrayResize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4, 5 };

            Console.Write("Daxil etmek istediyiniz Arrayin elementlerin sayini daxil edin:");
            int countArr = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[countArr];

            Console.Write("Arrayin elementlerini daxil edin:");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            CustomArrResize(ref nums,arr);

            foreach (var item in nums)
            {
                Console.Write(item + " ");
            }
        }

        public static void CustomArrResize(ref int[] nums, int[] arr)
        {
            int[] newArr = new int[nums.Length + arr.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                newArr[i] = nums[i];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                newArr[nums.Length + i] = arr[i];
            }

            nums = newArr;
        }
    }
}
