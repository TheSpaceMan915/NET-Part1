namespace Lab6
{
    class Lab6_main
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Main menu");
            Console.WriteLine("1. Copy a file to");
            Console.WriteLine("2. Move a file to");
            Console.WriteLine("3. Delete a file");
            Console.WriteLine("4. Create a directory");
            Console.WriteLine("5. View the contents of a directory");
            Console.WriteLine("6. Pick strings");
            Console.WriteLine("0. Exit");
            Console.WriteLine("");
            var command = Convert.ToInt16(Console.ReadLine());
            while (command != 0)
            {
                FileDriver.Dispatch(command);
                Console.WriteLine("What do you want to do?");
                command = Convert.ToInt16(Console.ReadLine());
            }
        }
    }
}