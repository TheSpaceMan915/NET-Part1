using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal class Dog : Animal
    {
        public string Breed { get; set; }
        public int Age { get; set; }

        public Dog() { }

        public Dog(string name, string breed, int age) : base(name) {
            Breed = breed;
            Age = age;
        }

        public override void makeSounds() {
            Console.WriteLine("I'm a dog. Bark bark bark");
            Console.WriteLine();
        }
    }
}