using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using static System.Console;
using System.Threading.Tasks;

namespace Prog2_2
{
    class Program
    {
        private static double eps;

        static long Fact(int a)
        {
            long ans = 1;
            for (int i = 1; i <= a; i++)
            {
                ans *= i;
            }
            return ans;
        }

        static double Series(double x, int iteration, double lastIteration)
        {
            double presentIteration = Math.Pow(-1, iteration - 1) * Math.Pow(x, iteration * 2 - 1) / Fact(iteration * 2 - 1);
            if (Math.Abs(presentIteration - lastIteration) < eps) return presentIteration;
            return presentIteration + Series(x, iteration + 1, presentIteration);
        }

        static void Main(string[] args)
        {
            WriteLine("Введите точность расчета:");
            while (!double.TryParse(ReadLine(), out eps) || eps < 0)
            {
                WriteLine("Некорректный ввод!");
            }
            WriteLine("Введите x");
            double x;
            while (!double.TryParse(ReadLine(), out x))
            {
                WriteLine("Некорректный ввод!");
            }
            WriteLine("Выберите способ расчёта: рекурсивный(1) линейный(2)");
            string option = ReadLine();
            switch (option)
            {
                case "1":
                {
                    WriteLine("Sin(x) = {0}\nРазложение по ряду = {1}", Math.Sin(x), Series(x, 1, 0));
                    ReadKey();
                    break;
                }
                case "2":
                {
                    double lastsum, sum = 0;
                    int i = 0;
                    do
                    {
                        i++;
                        lastsum = sum;
                        sum += Math.Pow(-1, i - 1) * Math.Pow(x, i * 2 - 1) / Fact(i * 2 - 1);
                    } while (Math.Abs(sum - lastsum) > eps);
                    WriteLine("Sin(x) = {0}\nРазложение по ряду = {1}", Math.Sin(x), sum);
                    ReadKey();
                    break;
                }
            }
        }
    }
}