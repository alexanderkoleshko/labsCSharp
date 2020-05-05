//Если след пред. буква гласная то след. заменяется на +1 по алфавиту.
using System;
using System.Text;

namespace lab23
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Input your string ");
            string stroka = Console.ReadLine();
            char[] letters = stroka.ToCharArray();
            string newletters = "";
            const string glasn = "euioay";
            newletters += letters[0];
            for (int i = 1; i < stroka.Length; i++)
            {
                foreach (char let in glasn)
                if (letters[i - 1] == let)
                {

                    if (letters[i] == 'z')

                        newletters += Convert.ToString(Convert.ToChar(Convert.ToInt32(letters[i]) - 25));

                    else

                        newletters += Convert.ToString(Convert.ToChar(Convert.ToInt32(letters[i]) + 1));
                }
        
            }
                Console.Write(newletters);

        }
    }
}
