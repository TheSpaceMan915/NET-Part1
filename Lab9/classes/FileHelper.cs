using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Lab9.classes
{
    internal class FileHelper
    {
        public FileHelper()
        {

        }

        public static void clearFile(String path = @"..\..\files\output.txt")
        {
            File.WriteAllText(path, string.Empty);
        }

        public static void writeToFile(String line, String path = @"..\..\files\output.txt")
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(line);
            }
        }

        public static String readFromFile(String path = @"..\..\files\output.txt")
        {
            String readText = File.ReadAllText(path);
            return readText;
        }
    }
}
