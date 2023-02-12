using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal class Cat : Animal
    {
        public string Colour { get; set; }

        public Cat() { }

        public Cat(string name, string colour) : base(name) {
            Colour = colour;
        }

        public override void makeSounds() {
            Console.WriteLine("I'm a cat. Purr purr purr");
            Console.WriteLine();
        }
    }
}
