using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Task2
    {
        // rim rom ram rem rim rem omrom omnom rim
        private static char[] vowels = "aeiouy".ToCharArray();
        private static char[] consonants = "bsdfghjklmnpqrstvwxz".ToCharArray();


        public static void start()
        {
            Console.WriteLine("Enter an array of strings");
            var str = " ";
            Dictionary<string, int> dict = new Dictionary<string, int>();


            while (str.Length > 0)
            {
                var vowelsCount = 0;
                var consonantsCount = 0;
                str = Convert.ToString(Console.ReadLine());

                //counting the number of vowels and consonants
                foreach (var symbol in str)
                {
                    if (vowels.Contains(symbol)) vowelsCount++;
                    else if (consonants.Contains(symbol)) consonantsCount++;
                }

                Console.WriteLine("The amount of vowels: " + vowelsCount);
                Console.WriteLine("The amount of consonants: " + consonantsCount);

                
                //counting how many times a word appears in the string
                var arr = str.Split(' ');
                foreach (var num in arr)
                {
                    var value = 0;
                    if (dict.ContainsKey(num))
                    {
                        value = dict[num];
                    }
                    dict[num] = value + 1;
                }
                

            }

            //choosing the word that appears most often
            var max = 0;
            var oftenElement = "";
            foreach (var pair in dict)
            {
                if (pair.Value > max)
                {
                    oftenElement = pair.Key;
                    max = pair.Value;
                }
            }
            Console.WriteLine("The word that appears most often is ");
            Console.WriteLine(oftenElement);
        }
    }
}
