using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab5
{
    internal class UsingMyIterator
    {
        public interface IMyEnumerator
        {
            bool MoveNext();
            object Current { get; }
        }

        public interface IMyEnumerable
        {
            IMyEnumerator GetEnumerator();
        }

        public class Range : IMyEnumerable
        {
            private readonly int y;

            public Range(int y)
            {
                this.y = y;
            }

            IMyEnumerator IMyEnumerable.GetEnumerator() => (IMyEnumerator) new Range.Enumerator(this.y);

            public struct Enumerator : IMyEnumerator
            {
                private int _index;
                private double _current;
                private int _y;

                public Enumerator(int y)
                {
                    _y = y;
                    _current = 0;
                    _index = 0;
                }

                public double Current => _current;
                object IMyEnumerator.Current => Current;

                public bool MoveNext()
                {
                    var e = 0.001;
                    _current = 1 / Math.Pow(_y, this._index);

                    if (this._current < e)
                    {
                        _index = 0;
                        return false;
                    }

                    _index++;
                    return true;
                }
            }

        }


        public static void startMyIterator()
        {
            var y = 0;
            while (y <= 1)
            {
                Console.WriteLine("Enter an integer  number > 1");
                try
                { y = Convert.ToInt16(Console.ReadLine()); }
                catch(Exception exep) 
                { Console.WriteLine("You should enter an integer > 1. Try again"); }   
            }

            IMyEnumerable range = new Range(y);

            /*
            Enumerator rangeEnumerator = new Range().Enumerator(y);

            while (rangeEnumerator.MoveNext())
            {
               double j = rangeEnumerator.Current;
               //...
               Console.WriteLine(j);
               //...
            }
            */

            // foreach (double j in range.getEnumerator())
            foreach (double j in range)
            {
                Console.WriteLine(j);
            }
        }
    }
}
