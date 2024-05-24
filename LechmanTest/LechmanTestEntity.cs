using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LechmanTest
{
    public class LechmanTestEntity
    {
        public int Number { get; init; }
        public BigInteger A { get; init; }
        public BigInteger R { get; init; }
        public bool IsSimple { get; init; }

        public LechmanTestEntity(int number, BigInteger a, BigInteger r, bool isSimple)
        {
            Number = number;
            A = a;
            R = r;
            IsSimple = isSimple;
        }
    }
}
