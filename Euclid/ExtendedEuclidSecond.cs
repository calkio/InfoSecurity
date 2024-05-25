using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclid
{
    public class ExtendedEuclidSecond
    {
        public (int nod, Stopwatch) CalculeteExtendedEuclidFirst(int a, int b)
        {
            Stopwatch watch = new Stopwatch();
            watch.Restart();

            if (a == 0)
            {
                return (b, watch);
            }

            int maxCount = 10000;
            int currentCount = 0;

            int u1 = 0;
            int u2 = 1;
            int u3 = a;

            int v1 = 1;
            int v2 = 0;
            int v3 = b;

            int t1 = 0;
            int t2 = 0;
            int t3 = 0;

            int q = b / a;

            while (u3 != 1 && maxCount > currentCount)
            {
                if (v3 == 0)
                {
                    throw new Exception("Деление на 0 (v3)");
                }
                q = u3 / v3;

                t1 = u1 - v1 * q;
                t2 = u2 - v2 * q;
                t3 = u3 - v3 * q;

                u1 = v1;
                u2 = v2;
                u3 = v3;

                v1 = t1;
                v2 = t2;
                v3 = t3;
            }

            watch.Stop();

            int nod = (u1 + a) % a;
            return (nod, watch);
        }
    }
}
