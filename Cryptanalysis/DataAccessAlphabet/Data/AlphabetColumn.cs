using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar.DataAccessAlphabet.DataAccessAlphabet
{
    internal class AlphabetColumn
    {
        public double Probability { get; init; }
        public char Char { get; init; }

        public AlphabetColumn(double probability, char mychar)
        {
            Probability = probability;
            Char = mychar;
        }
    }
}
