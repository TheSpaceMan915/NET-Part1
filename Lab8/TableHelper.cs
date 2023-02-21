using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    internal class TableHelper
    {
        public static void printTableHeader() {
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("| {0,4} | {1,7} | {2,7} | {3,25} | {4,25} |"
                , "i", "n0", "n1", "error", "res");
            Console.WriteLine("------------------------------------------------------------------------------------");
        }

        public static void printTableRow(int counter, int n0, int n1
            , double error, double res) {
            Console.WriteLine("| {0,4} | {1,7} | {2,7} | {3,25} | {4,25} |"
                , counter, n0, n1, error, res);
        }

        public static void printTableFooter() {
            Console.WriteLine("------------------------------------------------------------------------------------");
        }
    }
}
