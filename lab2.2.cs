using System;
 
namespace lab2._5
{
    class Program
    {
        public static void CreateListNumbers(string format, int[] array)
        {
            for (int i = 0; i < format.Length; ++i)
            {
                if (format[i] > 47 && format[i] < 58)
                {
                    char ch = format[i];
 
                    ++array[ch - 48];
                }
            }
        }
        
        static void Main()
        {
            string formatOne = null;
            string formatTwo = null;
            int[] arrayOne = new int [10];
            int[] arrayTwo = new int [10];
 
            for (int i = 0; i < 10; ++i)
                arrayOne[i] = 0;
 
            for (int i = 0; i < 10; ++i)
                arrayTwo[i] = 0;
 
            DateTime dateNow = DateTime.Now;
            formatOne = dateNow.ToString();
            formatTwo = dateNow.ToString("R");

            CreateListNumbers(formatOne, arrayOne);

            CreateListNumbers(formatTwo, arrayTwo);
            
 
            Console.WriteLine("1-ый формат:  " + formatOne);
           
            for (int i = 0; i < 10; ++i)
                Console.WriteLine("\tКоличество " + i + " = " + arrayOne[i]);
 
            Console.WriteLine("\n\n2-ой формат:  " + formatTwo);
 
            for (int i = 0; i < 10; ++i)
                Console.WriteLine("\tКоличество " + i + " = " + arrayTwo[i]);
        }
    }
}