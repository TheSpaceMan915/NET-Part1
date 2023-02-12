using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Task3
    {


        public static void PrintTable(int[][] table)
        {
            foreach (var row in table)
            {
                foreach (var number in row)
                {
                    Console.Write(number + "  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }


        public static void SortRows(int[][] table)
        {
            var rowLength = table[0].Length;
            for (var i = 0; i < table.Length; i++)
            {
                for (var j = 1; j < table.Length - 1 - i; j++)
                {
                    var row = table[j - 1];

                    //Getting the sums at the end of arrays
                    var rowSum = row[rowLength - 1];
                    var rowNext = table[j];
                    var rowSumNext = rowNext[rowLength - 1];

                    if (rowSum > rowSumNext)
                    {
                        (table[j - 1], table[j]) = (table[j], table[j - 1]);
                    }
                }
            }

        }

        public static void SortCols(int[][] table)
        {
            var rowWithColumSums = table[table.Length - 1];
            for (var i = 1; i < rowWithColumSums.Length; i++)
            {
                for (var j = 1; i < rowWithColumSums.Length - j; j++)
                {
                    var colSum = rowWithColumSums[j - 1];
                    var colSumNext = rowWithColumSums[j];
                    if (colSum > colSumNext)
                    {
                        SwapCols(j - 1, j, table);
                    }

                }
            }

        }

        public static void SwapCols(int x, int y, int[][] table)
        {
            var colLength = table.Length;
            for (var i = 0; i < colLength; i++)
            {
                (table[i][x], table[i][y]) = (table[i][y], table[i][x]);
            }
        }

        // 3
        // 3
        // 1 3 5
        // 5 1 3
        // 2 1 0 

        public static void start()
        {
            Console.WriteLine("Enter the size of 2D array:");
            Console.Write("The number of rows: ");
            var x = Convert.ToInt32(Console.ReadLine());
            Console.Write("The number of columns: ");
            var y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your rows");
            

            int[][] table = new int[x + 1][];
            for (var i = 0; i < x; i++)
            {
                //checking if the string is ""
                var str = Console.ReadLine();
                
                if (str == "")
                {
                    Console.WriteLine("Empty strings not allowed. Write not empty string");
                    i--;
                    continue;
                }


                //entering a row 
                var arr = str.Split(' ');
                var sum = 0;

                //creating an array
                var row = new int[y + 1];
                for (var j = 0; j < y; j++)
                {
                    //parsing each char to number
                    var number = Convert.ToInt16(arr[j]);
                    sum += number;
                    row[j] = number;
                }

                //adding the sum and the string in 2D array
                row[y] = sum;
                table[i] = row;
            }

            //go through all colomuns expect the last one (there are columns sums)
            var rowWithColumSums = new int[y + 1];
            for (var i = 0; i < y; i++)
            {
                var sum = 0;
                //go through all rows and count row sums
                for (var j = 0; j < x; j++)
                {
                    sum += table[j][i];
                    Console.WriteLine(table[j][i]);

                }
                rowWithColumSums[i] = sum;
            }

            table[x] = rowWithColumSums;

            Console.WriteLine("Before sorting: ");
            PrintTable(table);
            SortRows(table);
            SortCols(table);
            Console.WriteLine("After sorting: ");
            PrintTable(table);
        }
    }
}
