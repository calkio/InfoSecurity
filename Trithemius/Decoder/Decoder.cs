using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trithemius.Decoder
{
    internal class Decoder
    {
        public List<char> DecoderText(List<char> textChar)
        {
            List<char> coderText = new List<char>()
            {
                textChar[0]
            };

            Series.Series series = new Series.Series();
            for (int i = 1; i < textChar.Count; i++)
            {
                int indexChar = FindIndexToChar(series.Alphabet, textChar[i]);
                int indexCoderChar = (Math.Abs(indexChar - i)) % 32;
                char coderChar = series.Alphabet[indexCoderChar];
                coderText.Add(coderChar);
            }
            return coderText;
        }

        private int FindIndexToChar(List<char> textChar, char c)
        {
            int index = textChar.IndexOf(c);
            return index;
        }
    }
}
