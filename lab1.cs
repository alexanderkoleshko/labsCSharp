using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "С балкона 8-го этажа здания вертикально вниз бросили тело, которое упало на землю через X с и при падении имело скорость Y м/с. Какова была начальная скорость тела?\n");
            int t;
            Console.WriteLine("Ввeдите время, через которое тело упало на землю (Х):");
            while (!int.TryParse(Console.ReadLine(), out t))
            {
                Console.WriteLine("Ошибка ввода! Введите целое число:");
            }
            int Vy;
            Console.WriteLine("Ввeдите скорость, которую тело имело при  падении на землю (Y):");
            while (!int.TryParse(Console.ReadLine(), out Vy))
            {
                Console.WriteLine("Ошибка ввода! Введите целое число:");
            }
            int G = 10;
            string a = "fgh";
            int V0y = 0;
            V0y = Vy - G * t;
            Console.WriteLine("Начальная скорость тела была: {0}", V0y);
        }
    }
}
