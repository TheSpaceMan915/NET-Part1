using Lab9.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab9 {
    internal class SecondLab
    {
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

            protected Worker(int working_hours, int salary, Boolean flag) : base(salary, flag)
            { amount_working_hours = working_hours; }


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

                FileHelper.writeToFile("Working hours: " + type);
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

        class Security : Worker
        {
            private int countOfVideoMonitors;


            public Security(int countOfVideoMonitors, int amountOfWorkingHours, int salary, Boolean adult = true) : base(amountOfWorkingHours, salary, adult)
            { this.countOfVideoMonitors = countOfVideoMonitors; }

            public override void print()
            {
                FileHelper.writeToFile("This is a security guard");
                base.print();
                FileHelper.writeToFile("");

            }
        }

        public class Сashier : Worker
        {
            private String[] workingTimetable;


            public Сashier(String[] workingTimetable, int amountOfWorkingHours, int salary, Boolean adult = true) : base(amountOfWorkingHours, salary, adult)
            { this.workingTimetable = workingTimetable; }

            public override void print()
            {
                FileHelper.writeToFile("This is a cashier");
                FileHelper.writeToFile("Working table:");
                var temp = "";
                foreach (String str in workingTimetable)
                {
                    temp += str + " ";
                }
                FileHelper.writeToFile(temp);
                base.print();
                FileHelper.writeToFile("");
            }

        }


        public static void start()
        {
            //FileHelper.writeToFile("Lab2 Classes");
            Worker secur_obj = new Security(0, 12, 30500);
            secur_obj.print();

            string[] arr_timetable = { "6", "8", "8" };
            Worker cashier_obj = new Сashier(arr_timetable, 16, 40400);
            cashier_obj.print();
        }

    }
}

