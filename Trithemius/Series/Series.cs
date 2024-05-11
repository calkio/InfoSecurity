using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trithemius.Series
{
    internal class Series
    {
        public List<char> Alphabet = new List<char>();

        public Series()
        {
            Alphabet = GenerateAlphabet();
        }

        private List<char> GenerateAlphabet()
        {
            List<char> alphabet = new List<char>();
            for (char letter = 'а'; letter <= 'я'; letter++)
            {
                alphabet.Add(letter);
            }
            return alphabet;
        }
    }
}
