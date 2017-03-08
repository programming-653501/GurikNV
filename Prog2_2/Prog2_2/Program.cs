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
        static long Fact(int a)
        {
            long ans = 1;
            for (int i = 1; i <= a; i++)
            {
                ans *= i;
            }
            return ans;
        }

        static void Main(string[] args)
        {
            WriteLine("Выберите способ расчёта: рекурсивный(1) линейный(2)");
            ReadLine();
            WriteLine("Введите точность расчета (ε)");
            double eps;
            while (!double.TryParse(ReadLine(), out eps))
            {
                WriteLine("Некорректный ввод!");
            }
            WriteLine("Введите x");
            double x;
            while (!double.TryParse(ReadLine(), out x))
            {
                WriteLine("Некорректный ввод!");
            }
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
        }
    }
}
