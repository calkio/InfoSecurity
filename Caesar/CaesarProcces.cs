using Caesar.DataAccessAlphabet;
using Caesar.DataAccessAlphabet.DataAccessAlphabet;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar
{
    public class CaesarProcces
    {
        private char[] _letter;

        public CaesarProcces(string data)
        {
            _letter = data.ToCharArray();
        }

        public string GetCaesar(string text, int step)
        {
            if (step <= 0)
            {
                return text;
            }
            List<AlphabetColumn> alphabetColumns = GetCoder();
            char[] allChar = ParsingChar(text);
            List<int> combination = CalculateCombination(allChar, alphabetColumns);
            List<int> plusCombination = PlusCombination(combination, step);
            string newText = new string(CalculateNewText(plusCombination, alphabetColumns));
            return newText;
        }

        private List<AlphabetColumn> GetCoder()
        {
            DataAccess dataAccess = new DataAccess();
            List<AlphabetColumn> alphabetColumns = dataAccess.GenerateAlphabetColumn();
            return alphabetColumns;
        }

        private char[] ParsingChar(string text)
        {
            char[] charArray = text.ToCharArray();
            return charArray;
        }

        private List<int> CalculateCombination(char[] allChar, List<AlphabetColumn> alphabetColumn)
        {
            List<int> combination = new List<int>();
            for (int i = 0; i < allChar.Length; i++)
            {
                int code = alphabetColumn.FirstOrDefault(column => column.Char == allChar[i])?.Code ?? -1;
                combination.Add(code);
            }
            return combination;
        }

        private List<int> PlusCombination(List<int> combination, int step)
        {
            List<int> newCombination = combination.Select(code => (code + step) % 32).ToList();
            return newCombination;
        }

        private char[] CalculateNewText(List<int> combination, List<AlphabetColumn> alphabetColumn)
        {
            char[] newText = new char[combination.Count];
            for (int i = 0; i < combination.Count; i++)
            {
                char mychar = alphabetColumn.FirstOrDefault(column => column.Code == combination[i])?.Char ?? '\0';
                newText[i] = mychar;
            }
            return newText;
        }
    }
}
