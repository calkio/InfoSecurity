using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Model.Lab2.Decoder
{
    class Decoder
    {
        public string DecoderText(string inputText)
        {
            List<char> validChars = ValidText(inputText);
            List<char> decoderChars = CoderChars(validChars);
            string decoderText = ConvertCharsToString(decoderChars);
            return decoderText;
        }

        private List<char> ValidText(string inputText)
        {
            inputText = inputText.ToLower();
            List<char> chars = inputText.ToList();
            return chars;
        }

        private List<char> CoderChars(List<char> textChar)
        {
            Trithemius.Flow.Flow flow = new Trithemius.Flow.Flow();
            List<char> chars = flow.DecoderText(textChar);
            return chars;
        }

        private string ConvertCharsToString(List<char> coderChars)
        {
            string coderText = new string(coderChars.ToArray());
            return coderText;
        }
    }
}
