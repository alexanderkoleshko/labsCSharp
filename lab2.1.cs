using System;

namespace lab2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string array = "qqweqwertyuipasdfghjklzxcnmnbvcxzasdfghjkqwertyuiplkjhgfdsazxcvbnmqwertyuiopkjhgfdsaxcvbnmwertyuioplkjhgfdsazxcvbnmkjhgfdsqqweqwertyuipasdfghjklzxcnmnbvcxzasdfghjkqwertyuiplkjhgfdsazxcvbnmqwertyuiopkjhgfdsaxcvbnmwertyuioplkjhgfdsazxcvbnmkjhgfdsaqaqwertyuio";
            int count = 0;
            while (count <= 30)
            {
                Random rand = new Random();
                int temp = rand.Next(257);
                Console.WriteLine(array[temp] + "\t");
                count++;
            }
        }
    }
}