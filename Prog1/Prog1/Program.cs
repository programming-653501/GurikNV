using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        double da;
        WriteLine("Введите число:");
        while (!double.TryParse(ReadLine(), out da))
        {
            WriteLine("Некорректный ввод!");
        }
        var ia = (int) Math.Truncate((da - Math.Truncate(da)) * 1000);
        WriteLine("{0}", (ia % 10) + ((ia / 10) % 10) + (ia / 100));
        ReadKey();
    }
}
