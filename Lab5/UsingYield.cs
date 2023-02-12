using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class UsingYield
    {
        static IEnumerable Range(int y)
        {
            var e = 0.001;
            Console.WriteLine("The start of iteration");
            for (var i = 0; 1 / Math.Pow(y, i) > e; i++)
            {
                yield return 1 / Math.Pow(y, i);

            }
        }


        public static void startYield()
        {
            var y = 0;
            while (y <= 1)
            {
                Console.WriteLine("Enter a number > 1");
                try
                { y = Convert.ToInt16(Console.ReadLine()); }
                catch (Exception exep)
                { Console.WriteLine("You should enter an integer > 1. Try again"); }
            }


            foreach (var j in Range(y))
            {
                Console.WriteLine(j);
            }
        }
    }
}
