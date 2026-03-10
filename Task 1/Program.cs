////1
//int[] ededler = { 11, 22, 44, 2, 4, 5, 6, 7 };
//int sum = 0;
//for (int i = 0; i < ededler.Length; i++)
//{

//    if (ededler[i] >=10 && ededler[i]<100)
//    {
//        sum += ededler[i];
//    }

//}

//Console.WriteLine(sum);

////2
//int[] tamEdedler = { 1, 2, 3, 4, 5, 6, 7 };

//int cutSay = 0;
//int tekSay = 0;

//for (int i = 0; i < tamEdedler.Length; i++)
//{
//    if (tamEdedler[i] % 2 == 0)
//    {
//        Console.Write(tamEdedler[i]);
//        Console.Write(" ");
//    }

//}

//for (int j = 0; j < tamEdedler.Length; j++)
//{
//    if (tamEdedler[j] % 2 != 0)
//    {
//        Console.Write(tamEdedler[j]);
//        Console.Write(" ");
//    }
//}

//3
//int[] ededler = { 1, 2, 3, 4, 5, 6, 7, 8 };

//Console.WriteLine("Tapilmali ededi daxil edin");
//int n = Convert.ToInt32(Console.ReadLine());
//int count = 0;

//for (int i = 0; i < ededler.Length; i++)
//{
//	if (n == ededler[i])
//	{
//        Console.Write("Ededin Indexi:");
//        Console.Write(i);
//		count++;
//	}
//}

//if (count==0)
//{
//    Console.WriteLine(-1);
//}

////4
//string word = Console.ReadLine();
//int count = word.Length;

//if (count % 2 != 0)
//{
//    Console.WriteLine(word[count / 2]);
//}
//else
//{
//    Console.Write(word[(count / 2) - 1]);
//    Console.Write(word[count / 2]);
//}

////5
//int[] ededler = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
//int tekSum = 0;
//int cutSum = 0;

//for (int i = 0; i < ededler.Length; i++)
//{
//	if (i % 2 == 0)
//	{
//		cutSum += ededler[i];
//	}
//	else
//	{
//		tekSum += ededler[i];
//	}
//}
//Console.WriteLine(tekSum - cutSum);

//6
//string cumle = "Salam necesiz dostlar";


//for (int i = 0; i < cumle.Length; i++)
//{
//    if (cumle[i] == ' ')
//    {
//        Console.WriteLine();
//    }
//    else
//    {
//        Console.Write(cumle[i]);
//    }
//}

//Exclusive Task

//string text = Console.ReadLine();
//string[] words = text.Split(' ');

//int result = 0;
//int current = 0;

//foreach (string word in words)
//{
//    switch (word)
//    {
//        case "bir": current += 1; break;
//        case "iki": current += 2; break;
//        case "uç": current += 3; break;
//        case "dörd": current += 4; break;
//        case "bes": current += 5; break;
//        case "altı": current += 6; break;
//        case "yeddi": current += 7; break;
//        case "səkkiz": current += 8; break;
//        case "doqquz": current += 9; break;

//        case "on": current += 10; break;
//        case "iyirmi": current += 20; break;
//        case "otuz": current += 30; break;
//        case "qırx": current += 40; break;
//        case "əlli": current += 50; break;
//        case "altmıs": current += 60; break;
//        case "yetmis": current += 70; break;
//        case "səksən": current += 80; break;
//        case "doxsan": current += 90; break;

//        case "yüz":
//            if (current == 0) current = 1;
//            current *= 100;
//            break;

//        case "min":
//            if (current == 0) current = 1;
//            result += current * 1000;
//            current = 0;
//            break;

//        case "milyon":
//            if (current == 0) current = 1;
//            result += current * 1000000;
//            current = 0;
//            break;
//    }
//}

//result += current;
//Console.WriteLine(result);

//Elave Task 1 istifadeci  153 - 531

//string eded = Console.ReadLine();
//int[] arr = new int[eded.Length];

//for (int i = 0; i < eded.Length; i++)
//{
//    arr[i] = eded[i] - '0';
//}

//for (int i = 0; i < arr.Length; i++)
//{
//    for (int j = 0; j < arr.Length -1; j++)
//    {
//        if (arr[j] < arr[j + 1])
//        {
//            int temp = arr[j];
//            arr[j] = arr[j + 1];
//            arr[j + 1] = temp;
//        }
//    }
//}

//string yeniEded = "";

//foreach (var item in arr)
//{
//    yeniEded += item.ToString();
//}



//Console.WriteLine("Sıralanmis eded: " + yeniEded);
