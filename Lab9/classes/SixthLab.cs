using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Lab9.classes
{
    internal class SixthLab
    {
        internal class TableHelper
        {
            public static void printTableHeader()
            {
                FileHelper.writeToFile("------------------------------------------------------------------------------------");
                /*                Console.WriteLine("| {0,4} | {1,7} | {2,7} | {3,25} | {4,25} |"
                                    , "i", "n0", "n1", "error", "res");
                                Console.WriteLine("------------------------------------------------------------------------------------");*/
            }

            public static void printTableRow(int counter, int n0, int n1
               , double error, double res)
            {
                FileHelper.writeToFile(Convert.ToString(counter) + " " + Convert.ToString(n0) + " " + Convert.ToString(n1) + " " + Convert.ToString(error) + " " + Convert.ToString(res));
            }

            public static void printTableFooter()
            {
                FileHelper.writeToFile("------------------------------------------------------------------------------------");
            }
        }


        private double a;
        private double b;
        private double n;
        private Func<double, double> func;
        private List<double> listSums;

        public SixthLab(double a, double b, double n, Func<double, double> func) {
            this.a = a;
            this.b = b;
            this.n = n;
            this.func = func;
            listSums= new List<double>();
        }

        public List<double> getListSums() { return listSums; }

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

        public static void start()
        {
            Func<double, double> function = x => x;
            int n0 = 1, n1 = 0;
            double start = -10, end = 10, middle = (end - start) / 2;
            double eps = 0.0005, error = Double.MaxValue;
            TableHelper.printTableHeader();

            int counter = 0;
            while (eps < error & counter != 20)
            {
                // initialising n on the two intervals
                counter++;
                n0 *= 2;
                n1 = n0 * 2;

                // setting up threads
                SixthLab job1 = new SixthLab(start, middle, n0, function);
                SixthLab job2 = new SixthLab(middle, end, n1, function);
                Thread thread1 = new Thread(new ThreadStart(job1.calculateSum));
                Thread thread2 = new Thread(new ThreadStart(job2.calculateSum));
                thread1.Start();
                thread2.Start();
                thread1.Join();
                thread2.Join();

                // getting sums on the intervals from the list
                var list1 = job1.getListSums();
                var list2 = job2.getListSums();
                double sum1 = list1.Sum();
                double sum2 = list2.Sum();
                error = Math.Abs(sum2 - sum1);
                double res = Math.Abs(sum1 + sum2);
                TableHelper.printTableRow(counter, n0, n1, error, res);

                // cleaning the lists containing sums
                list1.Clear();
                list2.Clear();
            }

            TableHelper.printTableFooter();
        }
    }
}
