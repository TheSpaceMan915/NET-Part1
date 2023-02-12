using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal class Animal
    {
        public string Name { get; set; }

        public Animal() { }

        public Animal(string name) { Name = name; }

        public virtual void makeSounds() {
            Console.WriteLine("Animal sounds");
        }
    }
}
