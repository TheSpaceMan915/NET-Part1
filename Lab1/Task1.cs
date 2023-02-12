using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Task1
    {
        private static void PrintArray(int[] numArr)
        {
            var str = "";
            foreach (var num in numArr)
            {
                str = str + " " + Convert.ToString(num);
            }
            Console.WriteLine(str);
        }

        private static int[] BubbleSort(int[] numArr)
        {
            for (var i = 0; i < numArr.Length; i++)
            {
                for (var j = i + 1; j < numArr.Length; j++)
                {
                    PrintArray(numArr);
                    if (numArr[i] > numArr[j])
                    {
                        (numArr[i], numArr[j]) = (numArr[j], numArr[i]);
                    }
                }
            }
            return numArr;
        }

        public static void start()
        {
            Console.WriteLine("BubbleSort");
            Console.WriteLine("Enter the numbers to sort:");
            var str = Convert.ToString(Console.ReadLine());


            //creating an array of numbers and sorting it
            var arr = str.Split(' ');
            var numArr = new int[arr.Length];
            for (var i = 0; i < arr.Length; i++)
            {
                numArr[i] = Convert.ToInt16(arr[i]);
            }
            BubbleSort(numArr);


            //counting how many times each number is present in the array
            Console.WriteLine("The rarest element:");
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (var num in numArr)
            {
                var value = 0;
                if (dict.ContainsKey(num))
                {
                   value = dict[num];
                }
                dict[num] = value + 1;
            }

            //choosing the lesser counter
            var min = numArr.Length;
            var rareElement = numArr[0];
            foreach (var pair in dict)
            {
                if (pair.Value < min)
                {
                    rareElement = pair.Key;
                    min = pair.Value;
                }
            }
            Console.WriteLine(rareElement);
        }
    }
}
