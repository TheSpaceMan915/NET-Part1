
namespace Lab2 {

    class WorkingPlace
    {
        private int width;
        private int length;
        private int height;

        protected WorkingPlace(int x, int y, int z)
        {
            this.width = x;
            this.length = y;
            this.height = z;
        }
    }

    class Cabinet : WorkingPlace
    {
        private string[] inventory;

        Cabinet(string[] inventory, int x, int y, int z) : base(x, y, z)
        {
            this.inventory = inventory;
        }
    }

    public class Human
    {
        private Boolean adult;

        protected Human(Boolean adult)
        {
            this.adult = adult;
        }

        public virtual void print()
        {
            if (adult) Console.WriteLine("Adult");
            else Console.WriteLine("Child");
        }
    }

    public class Employee : Human
    {
        private int salary;
        protected Employee(int salary, Boolean adult) : base(adult)
        {
            this.salary = salary;
        }

        public override void print()
        {
            base.print();
            Console.WriteLine("Salary: " + this.salary);
        }
    }

    public class Worker : Employee
    {
        private int amount_working_hours;

        protected Worker(int working_hours, int salary,Boolean flag) : base(salary,flag)
        { amount_working_hours = working_hours;  }


        public override void print()
        {
            base.print();
            var type = "";
            switch (amount_working_hours)
            {
                case 20:; type = "Part time"; break;
                case 30:; type = "3/4"; break;
                case 40:; type = "Full time"; break;
                default:
                    ;
                    type = amount_working_hours + " hours a week"; break;
            }

            Console.WriteLine("Working hours: " + type);
        }
    }

    class Workers
    {
        private List<Worker> list = new List<Worker>();
        public void Add(Worker w)
        {
            this.list.Add(w);
        }
    }

    class Student : Human
    {
        private int course;
        public Student(int course, Boolean adult = true) : base(adult)
        {
            this.course = course;
        }
    }

    class Librarian : Worker
    {
        private Cabinet place;

        public Librarian(Cabinet place, int amountOfWorkingHours, int salary, Boolean adult = true) : base(
            amountOfWorkingHours, salary, adult)
        {
            this.place = place;
        }
    }

    class Director : Worker
    {
        private Workers subordinates;

        public Director(Workers subordinates, int amountOfWorkingHours, int salary, Boolean adult = true) : base(
            amountOfWorkingHours, salary, adult)
        {
            this.subordinates = subordinates;
        }
    }

    class Security : Worker
    {
        private int countOfVideoMonitors;


        public Security(int countOfVideoMonitors, int amountOfWorkingHours, int salary, Boolean adult = true) : base(amountOfWorkingHours, salary, adult)
        { this.countOfVideoMonitors = countOfVideoMonitors; }

        public override void print()
        {
            base.print();
            Console.WriteLine("This is a security guard");
            Console.WriteLine("");
        }
    }

    public class Сashier : Worker
    {
        private string[] workingTimetable;


        public Сashier(string[] workingTimetable, int amountOfWorkingHours, int salary, Boolean adult = true) : base(amountOfWorkingHours, salary, adult)
        { this.workingTimetable = workingTimetable; }

        public override void print()
        {
            base.print();
            Console.WriteLine("This is a cashier");
            Console.WriteLine("");
        }

    }

    class Program
    {
        public static void Main(string[] args)
        
        {
            //Console.WriteLine("Checking");

            Worker secur_obj = new Security(0, 12, 30500);
            secur_obj.print();


            string[] arr_timetable = { "6", "8", "8" };
            Worker cashier_obj = new Сashier(arr_timetable, 16, 40400);
            cashier_obj.print();
        }

    }
}

