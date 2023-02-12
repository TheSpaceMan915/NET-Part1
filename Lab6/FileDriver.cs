using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class FileDriver
    {

        public static void Dispatch(int command)
        {
            switch (@command)
            {
                case 1:
                    {
                        Copy();
                        break;
                    }
                case 2:
                    {
                        Move();
                        break;
                    }
                case 3:
                    {
                        Delete();
                        break;
                    }
                case 4:
                    {
                        CreateDir();
                        break;
                    }
                case 5:
                    {
                        ListDir();
                        break;
                    }
                case 6:
                    {
                        pickStrings();
                        break;
                    }
            }
        }


        public static void Copy()
        {
            var from = "";
            var to = "";
            try
            {
                Console.Write("Input file: ");
                from = Convert.ToString(Console.ReadLine());
                Console.Write("Output file: ");
                to = Convert.ToString(Console.ReadLine());
                File.Copy(from, to);
            }
            catch (Exception ex)
            { Console.WriteLine("Try again"); }
        }


        public static void Move()
        {
            try
            {
                Console.Write("Move from directory: ");
                var from = Convert.ToString(Console.ReadLine());
                Console.Write("Move to directory: ");
                var to = Convert.ToString(Console.ReadLine());

                File.Copy(from, to);
                File.Delete(from);
            }
            catch (Exception ex)
            { Console.WriteLine("Try again"); }

        }


        public static void Delete()
        {
            try
            {
                Console.Write("Delete the file: ");
                var from = Convert.ToString(Console.ReadLine());
                File.Delete(from);
            }
            catch (Exception ex)
            {  Console.WriteLine("Try again"); }
        }


        public static void CreateDir()
        {
            try
            {
                Console.Write("Where to create a directory: ");
                var where = Convert.ToString(Console.ReadLine());
                Directory.CreateDirectory(where);
            }
            catch (Exception ex) 
            { Console.WriteLine("Try again");  }
        }


        public static void ListDir()
        {
            try
            {
                Console.Write("What directory to list: ");
                var where = Convert.ToString(Console.ReadLine());

                var files = Directory.GetFiles(where);
                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }
            }
            catch (Exception ex)
            { Console.WriteLine("Try again"); }
        }


        public static void pickStrings()
        {
            List<String> list_strings = new List<string>();

            foreach (string line in System.IO.File.ReadLines("C:\\Users\\nikit\\source\\repos\\NET Part1\\Lab6\\files\\simple_file.txt"))
            {
                if (line.Length < 10)
                { list_strings.Add(line); }
            }

            using (StreamWriter writer = new StreamWriter("C:\\Users\\nikit\\source\\repos\\NET Part1\\Lab6\\files\\short_lines.txt"))
            {
                foreach (string line in list_strings) 
                { writer.WriteLine(line); }
            }
        }
    }
}
