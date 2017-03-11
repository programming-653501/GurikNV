using System;
using System.Linq;
using System.Xml.Schema;
using static System.Console;

namespace Prog4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Введите две строки:");
            string firstString = ReadLine();
            string secondString = ReadLine();
            while (firstString.IndexOf(' ') != -1) { firstString = firstString.Remove(firstString.IndexOf(' '), 1); }
            while (firstString.IndexOf('.') != -1) { firstString = firstString.Remove(firstString.IndexOf('.'), 1); }
            while (firstString.IndexOf(',') != -1) { firstString = firstString.Remove(firstString.IndexOf(','), 1); }
            while (firstString.IndexOf('!') != -1) { firstString = firstString.Remove(firstString.IndexOf('!'), 1); }
            while (firstString.IndexOf('?') != -1) { firstString = firstString.Remove(firstString.IndexOf('?'), 1); }
            while (firstString.IndexOf(':') != -1) { firstString = firstString.Remove(firstString.IndexOf(':'), 1); }
            while (firstString.IndexOf(';') != -1) { firstString = firstString.Remove(firstString.IndexOf(';'), 1); }
            while (secondString.IndexOf(' ') != -1) { secondString = secondString.Remove(secondString.IndexOf(' '), 1); }
            while (secondString.IndexOf('.') != -1) { secondString = secondString.Remove(secondString.IndexOf('.'), 1); }
            while (secondString.IndexOf(',') != -1) { secondString = secondString.Remove(secondString.IndexOf(','), 1); }
            while (secondString.IndexOf('!') != -1) { secondString = secondString.Remove(secondString.IndexOf('!'), 1); }
            while (secondString.IndexOf('?') != -1) { secondString = secondString.Remove(secondString.IndexOf('?'), 1); }
            while (secondString.IndexOf(':') != -1) { secondString = secondString.Remove(secondString.IndexOf(':'), 1); }
            while (secondString.IndexOf(';') != -1) { secondString = secondString.Remove(secondString.IndexOf(';'), 1); }
            firstString = firstString.ToLower();
            secondString = secondString.ToLower();
            int[,] substringSearchArray = new int[100, 100];
            int maxSubstring = 0, maxI = 0;
            for (int i = 1; i <= firstString.Length; i++)
            {
                for (int j = 1; j <= secondString.Length; j++)
                {
                    if (firstString[i - 1] == secondString[j - 1])
                    {
                        substringSearchArray[i, j] = substringSearchArray[i - 1, j - 1]+ 1;
                        if (substringSearchArray[i, j] > maxSubstring)
                        {
                            maxSubstring = substringSearchArray[i, j];
                            maxI = i;
                        }
                    }
                }
            }
            WriteLine("Наибольшая общая подстрока: {0}", firstString.Substring(maxI - maxSubstring, maxSubstring));
            ReadKey();
        }
    }
}
