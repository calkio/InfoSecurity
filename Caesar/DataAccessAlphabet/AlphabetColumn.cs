using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar.DataAccessAlphabet.DataAccessAlphabet
{
    internal class AlphabetColumn
    {
        public int Code { get; init; }
        public char Char { get; init; }

        public AlphabetColumn(int code, char mychar)
        {
            Code = code;
            Char = mychar;
        }
    }
}
