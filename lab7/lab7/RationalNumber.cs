using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace lab7
{
    class RationalNumber : IEquatable<RationalNumber>
    {
        private int denominator;


        public RationalNumber(int numerator, int denomintaor)
        {
            Numerator = numerator;
            Denominator = denomintaor;

            Value = (double)Numerator / (double)Denominator;
        }

        public RationalNumber(double value)
        {
            Value = value;
        }

        public RationalNumber() { }


        public int Numerator { get; set; }

        public int Denominator
        {
            set
            {
                if (value < 0)
                {
                    throw new Exception("denominator must be positive");
                }
                else
                {
                    denominator = value;
                }
            }
            get { return denominator; }
        }

        public double Value { get; set; } // the exact number (numerator / denominator

        //method of IEquatable interface to comparise objects
        public bool Equals(RationalNumber other)
        {
            if (this.Value == other.Value)
                return true;
            else
                return false;
        }



        // method for getting object by string input in different formats
        public static RationalNumber Parse(string inputString)
        {
            string pattern1 = @"\d*\.\d*"; // 0.4
            string pattern2 = @"\d*,\d*";  // 0,4
            string pattern3 = @"\d*/\d*";  // 2/5

            if (Regex.IsMatch(inputString, pattern1) || Regex.IsMatch(inputString, pattern2)) // this is for pattern1 and pattern2 - 0.4 || 0,4
            {
                double value = Double.Parse(inputString.Replace(',', '.'), CultureInfo.InvariantCulture);

                return new RationalNumber(value);
            }

            else if (Regex.IsMatch(inputString, pattern3)) // this is for pattern3 - 2/5
            {
                int numerator = 0;
                int denominator = 0;

                StringBuilder numeratorString = new StringBuilder();
                StringBuilder denominatorString = new StringBuilder();

                bool beforeDot = true;


                for (int i = 0; i < inputString.Length; ++i)
                {
                    if (inputString[i] == '/')
                    {
                        beforeDot = false;
                        continue;
                    }

                    if (beforeDot == false)
                    {
                        denominatorString.Append(inputString[i]);
                    }

                    else
                    {
                        numeratorString.Append(inputString[i]);
                    }
                }


                numerator = Convert.ToInt32(numeratorString.ToString());
                denominator = Convert.ToInt32(denominatorString.ToString());

                return new RationalNumber(numerator, denominator);
            }

            else
            {
                throw new Exception("wrong input");
            }
        }



        //overload for object method "ToString" that takes argument (A\B\C) to display string in different formats
        public override string ToString()
        {
            return ToString("A");
        }

        public string ToString(string par)
        {
            if (string.IsNullOrEmpty(par))
                par = "A";

            switch (par)
            {
                case "A":
                    return string.Format(Value.ToString());
                case "B":
                    return string.Format("{0:0.000}", Value);
                case "C":
                    return string.Format("{0:#.0}", Value);
                default:
                    string msg = string.Format("'{0}' is an invalid format string", par);
                    throw new ArgumentException(msg);
            }
        }



        // overload of operators
        public static RationalNumber operator +(RationalNumber n1, RationalNumber n2)
        {
            return new RationalNumber { Value = n1.Value + n2.Value };
        }

        public static RationalNumber operator -(RationalNumber n1, RationalNumber n2)
        {
            return new RationalNumber { Value = n1.Value - n2.Value };
        }

        public static RationalNumber operator *(RationalNumber n1, RationalNumber n2)
        {
            return new RationalNumber { Value = n1.Value * n2.Value };
        }

        public static RationalNumber operator /(RationalNumber n1, RationalNumber n2)
        {
            return new RationalNumber { Value = n1.Value / n2.Value };
        }

        public static bool operator <(RationalNumber n1, RationalNumber n2)
        {
            return n1.Value < n2.Value;
        }

        public static bool operator >(RationalNumber n1, RationalNumber n2)
        {
            return n1.Value > n2.Value;
        }

        public static bool operator ==(RationalNumber n1, RationalNumber n2)
        {
            return n1.Value == n2.Value;
        }

        public static bool operator !=(RationalNumber n1, RationalNumber n2)
        {
            return n1.Value != n2.Value;
        }



        // overload explicit\implicit castings to other types
        public static implicit operator RationalNumber(double value)
        {
            return new RationalNumber { Value = value };
        }

        public static implicit operator RationalNumber(int value)
        {
            return new RationalNumber { Value = value };
        }

        public static explicit operator double(RationalNumber numb)
        {
            return numb.Value;
        }

        public static explicit operator int(RationalNumber numb)
        {
            return (int)numb.Value;
        }
    }
}
