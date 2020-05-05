using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            RationalNumber number1 = new RationalNumber(3, 5); // example for constructor                                                            
            RationalNumber numbGetByMethod1 = RationalNumber.Parse("2/5"); // examples for method that takes string and returns          
            RationalNumber numbGetByMethod2 = RationalNumber.Parse("2.5"); // object (uses regular expressions)
            RationalNumber numbGetByMethod3 = RationalNumber.Parse("4/10");


            Console.WriteLine(numbGetByMethod1 > numbGetByMethod2); // examples for overloading operators
            Console.WriteLine(numbGetByMethod1 < numbGetByMethod2);
            Console.WriteLine(numbGetByMethod1 + numbGetByMethod2);


            Console.WriteLine(numbGetByMethod1.ToString("A")); // example for overloading ToString method.
            Console.WriteLine(numbGetByMethod2.ToString("B")); // it also takes parameter(A\B\C) to 
            Console.WriteLine(numbGetByMethod1.ToString("C")); // display string in different formats


            if(numbGetByMethod1.Equals(numbGetByMethod3))      // example for overloading the interface of comparison
               Console.WriteLine("numbers are equal");


            int x = (int)numbGetByMethod2;                     // examples for explicit\implicit casting to other types
            Console.WriteLine(x);

            double y = (double)numbGetByMethod1;
            Console.WriteLine(y);

            RationalNumber number2 = 24;
            RationalNumber number5 = 2.4;

            Console.WriteLine(number5.ToString("A"));
        }
    }
}
