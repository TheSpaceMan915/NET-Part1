using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    internal class ThreadJob
    {
        private double a;
        private double b;
        private double n;
        private Func<double, double> func;
        private List<double> listSums;

        public ThreadJob(double a, double b, double n, Func<double, double> func) {
            this.a = a;
            this.b = b;
            this.n = n;
            this.func = func;
            listSums= new List<double>();
        }

        public List<double> getListSums() { return listSums; }

/*        public static double calculateSum(double a, double b, int n)
        {
            double h = (b - a) / n;
            double sum = 0;
            a += 1 / 2 * h;

            for (int i = 0; i < n - 1; i++)
            {
                double x = a + i * h;
                sum += func(x);
            }
            return sum * h;
        }*/

        public void calculateSum()
        {
            double h = (this.b - this.a) / this.n;
            double sum = 0;
            this.a += 1/2 * h;

            // calculating a sum on the [a,b] interval
            for (int i = 0; i < this.n - 1; i++)
            {
                double x = this.a + i * h;
                sum += func(x);
            }

            // saving the result in the list
            double res = sum * h;
            listSums.Add(res);
        }
    }
}
