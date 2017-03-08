using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Threading.Tasks;

namespace Prog2
{
    internal class EuroTrans
    {
        public static int Weight { get; set; }
        public static int Distance { get; set; }

        public static void Calculate()
        {
            if (Distance > 4000)
            {
                WriteLine("Максимальная дистанция перевозки - 4000 км");
                return;
            }
            if (Weight < 50)
            {
                WriteLine("Перевозка грузов весом менее 50 кг считается нецелесообразной");
                return;
            }
            if (Weight > 300)
            {
                WriteLine("Наш запас грузоподъемности составляет лишь 300 кг");
                return;
            }

            var numOfCars = (double) Weight / 20;
            if (!(numOfCars == Math.Truncate(numOfCars)))
            {
                numOfCars = Math.Truncate(numOfCars + 1);
            }

            var cost = numOfCars * 2 * Distance;
            var insurance = cost * 0.05;

            WriteLine("Количество машин - {0}\nСтоимость страховки - {1}\nСтоимость перевозки - {2}", numOfCars, insurance, cost + insurance);
        }
    }
}
