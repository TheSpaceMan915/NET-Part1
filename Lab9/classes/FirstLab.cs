using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab9.classes
{
    internal class FirstLab
    {
        private static void PrintArray(int[] numArr)
        {
            var str = "";
            foreach (var num in numArr)
            {
                str = str + " " + Convert.ToString(num);
            }
            FileHelper.writeToFile(str);
        }

        private static int[] BubbleSort(int[] numArr)
        {
            for (var i = 0; i < numArr.Length; i++)
            {
                for (var j = i + 1; j < numArr.Length; j++)
                {
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
            //FileHelper.writeToFile("Lab1 Sorting");

            //creating an array of numbers and sorting it
            FileHelper.writeToFile("Array before sorting:");
            int[] arr = {3,2,14,2,10};
            PrintArray(arr);
            BubbleSort(arr);
            FileHelper.writeToFile("Array after sorting:");
            PrintArray(arr);
        }
    }
}
