using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace lab7
{
    class RationalNum
    {
        int  Denominator { get; set; }
        int Numerator { get; set; }
        public RationalNum(int numerator, int denominator)
        {
            if (numerator < 0 && denominator < 0)
            {
                numerator = Math.Abs(numerator);
                denominator = Math.Abs(denominator);
            }
            else if (numerator > 0 && denominator < 0)
            {
                numerator = -(numerator);
                denominator = Math.Abs(denominator);
            }

            if (denominator == 0)
            {
                Console.WriteLine("Error, division by zero");

            }

            Numerator = numerator;
            Denominator = denominator;
        }

        public RationalNum(int numerator)
        {
            Numerator = numerator;
            Denominator = 1;
        }

        public RationalNum(double number)
        {
            int drob;

            Numerator = (int)number;

            drob = (int)(number - Numerator)*100;
            Numerator *= 100;

            Denominator = drob;
        }

        public int Gcd(int a, int b)
        {
            while (b != 0)
                b = a % (a = b);
            return Math.Abs(a);
        }

        public void Simplify()
        {
            int gcd = Gcd(Numerator, Denominator);

            if (gcd == 0)
                gcd = 1;
            

            Numerator /= gcd;
            Denominator /= gcd;
        }

        static public RationalNum operator+(RationalNum first, RationalNum second)
        {
            return new RationalNum(first.Numerator * second.Denominator + second.Numerator * first.Denominator, first.Denominator * second.Denominator);
        }

        static public RationalNum operator -(RationalNum first, RationalNum second)
        {
            return new RationalNum(first.Numerator * second.Denominator - second.Numerator * first.Denominator, first.Denominator * second.Denominator);
        }

        static public RationalNum operator *(RationalNum first, RationalNum second)
        {
            return new RationalNum(first.Numerator * second.Numerator, first.Denominator * second.Denominator);
        }

        static public RationalNum operator /(RationalNum first, RationalNum second)
        {
            if (second.Denominator == 0) return new RationalNum(1);
            return new RationalNum(first.Numerator * second.Denominator, first.Denominator * second.Numerator);
        }

        static public bool operator >(RationalNum first, RationalNum second)
        {
            return first.Numerator * second.Denominator > second.Numerator * first.Denominator;
        }

        static public bool operator <(RationalNum first, RationalNum second)
        {
            return first.Numerator * second.Denominator < second.Numerator * first.Denominator;
        }

        static public bool operator <=(RationalNum first, RationalNum second)
        {
            return first.Numerator * second.Denominator <= second.Numerator * first.Denominator;
        }

        static public bool operator >=(RationalNum first, RationalNum second)
        {
            return first.Numerator * second.Denominator >= second.Numerator * first.Denominator;
        }

        static public bool operator ==(RationalNum first, RationalNum second)
        {
            return first.Numerator * second.Denominator == second.Numerator * first.Denominator;
        }

        static public bool operator !=(RationalNum first, RationalNum second)
        {
            return first.Numerator * second.Denominator != second.Numerator * first.Denominator;
        }



        static public implicit operator RationalNum(int number)
        {
            return new RationalNum(number);
        }

        static public explicit operator int(RationalNum number)
        {
            return (number.Numerator / number.Denominator);
        }

        static public explicit operator double(RationalNum number)
        {
            return (number.Numerator / number.Denominator);
        }

        static public implicit operator RationalNum(double number)
        {
            return new RationalNum((int)number * 10000 ,10000);
        }


        public string ToString(string form)
        {

            switch (form)
            {
                case "n": return string.Concat(Numerator , '/' , Denominator); 
                case "p":

                    if (Numerator <= Denominator && Numerator > 0)
                        return string.Concat(Numerator, '/', Denominator);
                    else
                        if (Numerator % Denominator == 0) return string.Concat(Numerator / Denominator);
                    else
                            return string.Concat(Numerator / Denominator,' ', Math.Abs(Numerator) % Denominator, '/',Denominator);
                    
                case "s": return string.Concat((double)Numerator / Denominator);
                default: return string.Concat(Numerator , '/' , Denominator);
            }
        }

        public override string ToString()
        {
             return string.Concat(Numerator , '/' , Denominator);
        }

       static public RationalNum ConvertToRat(string stroka, string format)
        {
            stroka.Trim();

            if (int.TryParse(stroka, out int res))
                return new RationalNum(res);
            
            string[] nums = stroka.Split('/','.',',');

            if (!int.TryParse(nums[0], out int first) || !int.TryParse(nums[1], out int second))
            {
                Console.WriteLine("Incorrect input will be 1/1, try again"); Thread.Sleep(500); return new RationalNum(1);
            }



                switch (format)
            {
                case "n": 
                    return new RationalNum(first, second);

                case "s":  return new RationalNum(first * (int)Math.Pow(10, nums[1].Length) + second, (int)Math.Pow(10,nums[1].Length));


                default: Console.WriteLine("Incorrect input will be 1/1, try again"); Thread.Sleep(100);  return new RationalNum(1);
            }

        }





    }
}
