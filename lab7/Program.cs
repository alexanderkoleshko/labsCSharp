using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace lab7
{
    class Program
    {
        static void Main()
        {
            RationalNum first = new RationalNum(1,6);
            RationalNum second = new RationalNum(4, 8);

            List<RationalNum> numbers = new List<RationalNum>();
            numbers.Add(first);
            numbers.Add(second);

            

            while (true)
            {
                Console.WriteLine("1 - Add new number\n2 - View number\n3 - Math operations\n4 - Compare\n5 - Simplify all numbers\n6 - Exit");

                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.D1: AddNumbers(numbers); Console.Clear(); break;
                    case ConsoleKey.D2: ViewNumbers(numbers); Console.Clear(); break;
                    case ConsoleKey.D3: Calculate(numbers); Console.Clear(); break;
                    case ConsoleKey.D4: NumComparer(numbers); Console.Clear(); break;
                    case ConsoleKey.D5: AllSimple(numbers); break;
                    case ConsoleKey.D6: return;
                }
            }

        }

        static public void AddNumbers(List<RationalNum> nums)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose the format of input number : \n1 - Numerator/Denominator\n2 - Numerator.Denominator");
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.D1: Console.Clear(); Console.WriteLine("Input\n"); nums.Add(RationalNum.ConvertToRat(Console.ReadLine(), "n")); return;
                    case ConsoleKey.D2: Console.Clear(); Console.WriteLine("Input\n"); nums.Add(RationalNum.ConvertToRat(Console.ReadLine(), "s")); return;
                    default: Console.WriteLine("Incorrect input"); break;
                }
                continue;
            }
        }

        static public void ViewNumbers(List<RationalNum> nums)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose the format of the output : \n1 - Numerator/Denominator\n2 - Numerator.Denominator\n3 - Proper view ");
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.D1: 
                                    Console.Clear(); 
                                    for (int i = 0; i < nums.Count; i++) 
                                    Console.WriteLine(nums[i].ToString("n")); Console.ReadKey();
                                    return;

                    case ConsoleKey.D2:
                                    Console.Clear();
                                    for (int i = 0; i < nums.Count; i++)
                                    Console.WriteLine(nums[i].ToString("s")); Console.ReadKey();
                                    return;
                    
                    case ConsoleKey.D3:
                                    Console.Clear();
                                    for (int i = 0; i < nums.Count; i++)
                                    Console.WriteLine(nums[i].ToString("p")); Console.ReadKey();
                                    return;

                    default: Console.WriteLine("Incorrect input"); break;
                }
                continue;
            }

        }

        static public void Calculate(List<RationalNum> nums)
        {
            RationalNum first, second, result ;
            while (true)
            {
                NumChoice(nums,out first,out second);

                Console.Clear();
                Console.WriteLine("Choose the operation : \n1 - Sum\n2 - Subtraction\n3 - Multiplication\n4 - Division\n5 - Exit");
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.D1: 
                        result = first + second; result.Simplify();
                        Console.Clear();
                        Console.WriteLine(first.ToString("n") + " + " + second.ToString("n") + " = " + result.ToString("n")); Console.ReadKey();
                        return;

                    case ConsoleKey.D2:
                        result = first - second; result.Simplify();
                        Console.Clear();
                        Console.WriteLine(first.ToString("n") + " - " + second.ToString("n") + " = " + result.ToString("n")); Console.ReadKey();
                        return;

                    case ConsoleKey.D3:
                        result = first * second; result.Simplify();
                        Console.Clear();
                        Console.WriteLine(first.ToString("n") + " * " + second.ToString("n") + " = " + result.ToString("n")); Console.ReadKey();
                        return;
                    case ConsoleKey.D4:
                        result = first / second; result.Simplify();
                        Console.Clear();
                        Console.WriteLine(first.ToString("n") + " / " + second.ToString("n") + " = " + result.ToString("n")); Console.ReadKey();
                        return;
                    case ConsoleKey.D5: return;


                    default: Console.WriteLine("Incorrect input"); break;
                }
                continue;
            }

        }

        static void NumComparer(List<RationalNum> nums)
        {
            NumChoice(nums, out RationalNum first, out RationalNum second);

            if (first > second) {
                Console.WriteLine(first.ToString("n") + " > " + second.ToString("n"));
                Console.ReadKey();
                return;
            }
            
            if (first < second)
            {
                Console.WriteLine(first.ToString("n") + " < " + second.ToString("n"));
                Console.ReadKey();
                return;
            }
            
            if (first == second)
            {
                Console.WriteLine(first.ToString("n") + " = " + second.ToString("n"));
                Console.ReadKey();
                return;
            }
        }

        static void AllSimple(List<RationalNum> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                 nums[i].Simplify();
            }

            Console.Clear();
        }

        static void NumChoice(List<RationalNum> nums, out RationalNum first, out RationalNum second)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose 2 numbers by their id");
                for (int i = 0; i < nums.Count; i++)
                {

                    Console.WriteLine(i + ") " + nums[i].ToString("n"));
                }

                Console.WriteLine("First id : ");
                if (!int.TryParse(Console.ReadLine(), out int index))
                    continue;

                    if (index >= nums.Count) continue;

                    first = nums[index];

                Console.WriteLine("Second id : ");
                if (!int.TryParse(Console.ReadLine(), out index))
                    continue;
                if (index >= nums.Count) continue;

                second = nums[index];
                return;


            }


        }




    }
}
