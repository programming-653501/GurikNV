using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Threading.Tasks;

namespace Prog3
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Введите размеры таблицы(в одну строку):");
            string[] NM = ReadLine().Split(' ');
            int n = int.Parse(NM[0]), m = int.Parse(NM[1]);
            string[,] customArray = new string[100, 100];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    customArray[i, j] = "*";
                }

            while (true)
            {
                WriteLine("Введите позицию числа и само число(в одну строку):");
                string[] IJA = ReadLine().Split(' ');
                int i = int.Parse(IJA[0]), j = int.Parse(IJA[1]);
                if (i == 0 && j == 0 && IJA[2] == "0") { break; }
                if (customArray[i, j] != "*")
                {
                    WriteLine("Заменить старое значение?(Y/N)");
                    if (ReadLine() == "N")
                    {
                        continue;
                    }
                }
                customArray[i, j] = IJA[2];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Write("{0}\t", customArray[i, j]);
                }
                WriteLine("\n\n");
            }
            ReadKey();
        }
    }
}
