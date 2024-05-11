using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Model.Lab2.Coder
{
    class Coder
    {
        public string CoderText(string inputText)
        {
            List<char> validChars = ValidText(inputText);
            List<char> coderChars = CoderChars(validChars);
            string coderText = ConvertCharsToString(coderChars);
            return coderText;
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
            List<char> chars = flow.CoderText(textChar);
            return chars;
        }

        private string ConvertCharsToString(List<char> coderChars)
        {
            string coderText = new string(coderChars.ToArray());
            return coderText;
        }
    }
}
