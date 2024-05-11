using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Entity
{
    public class EuclidEntity
    {
        public int A { get; set; }
        public int B { get; set; }
        public int Nod { get; set; }

        private Stopwatch _time;
        public TimeSpan Time { get => _time.Elapsed; }
        public int Number { get; set; }

        public EuclidEntity(int a, int b, int nod, Stopwatch time, int number)
        {
            A = a;
            B = b;
            Nod = nod;
            _time = time;
            Number = number;
        }
    }
}
