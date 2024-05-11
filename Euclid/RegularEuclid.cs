using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclid
{
    public class RegularEuclid
    {
        public (int nod, Stopwatch) CalculeteRegularEuclid(int a, int b)
        {
            Stopwatch watch = new Stopwatch();
            watch.Restart();

            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }

            watch.Stop();

            return (a, watch);
        }
    }
}
