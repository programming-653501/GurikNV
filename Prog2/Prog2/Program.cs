using System;
using System.Collections.Generic;
using static System.Console;
using System.Text;
using System.Threading.Tasks;

namespace Prog2
{
    class Program
    {
        static void Main(string[] args)
        {
            

            while (true)
            {
                WriteLine("Eurotrans Group by GurritoN(Gurik Nikita) v1.1");
                WriteLine("Вес груза: {0}\nРасстояние перевозки: {1}", EuroTrans.Weight, EuroTrans.Distance);
                WriteLine("Введите 1, чтобы ввести вес груза\nВведите 2, чтобы ввести расстояние перевозки\nВведите 3, чтобы рассчитать параметры заказа\nВведите 0, чтобы выйти из программы");

                int option;
                while (!int.TryParse(ReadLine(), out option))
                {
                    WriteLine("Некорректный ввод!");
                }
                switch (option)
                {
                    case 1:
                    {
                        WriteLine("Введите вес:");
                        int weight;
                        while (!int.TryParse(ReadLine(), out weight))
                        {
                            WriteLine("Некорректный ввод!");
                        }
                        EuroTrans.Weight = weight;
                        break;
                    }
                    case 2:
                    {
                        WriteLine("Введите дистанцию:");
                        int distance;
                        while (!int.TryParse(ReadLine(), out distance))
                        {
                            WriteLine("Некорректный ввод!");
                        }
                        EuroTrans.Distance = distance;
                        break;
                    }
                    case 3:
                    {
                        Clear();
                        EuroTrans.Calculate();
                        ReadKey();
                        break;
                    }
                    case 0:
                    {
                        return;
                    }
                    default:
                    {
                        WriteLine("Неизвестная команда");
                        return;
                    }
                }
                Clear();
            }
        }
    }
}
