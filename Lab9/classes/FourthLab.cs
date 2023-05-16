using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab9.classes
{
    internal class FourthLab
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


        public static void start()
        {
            //FileHelper.writeToFile("Lab4 Yield Iterators");
            var y = 2;
            foreach (var j in Range(y))
            {
                FileHelper.writeToFile(Convert.ToString(j));
            }
        }
    }
}
