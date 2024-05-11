using Caesar.DataAccessAlphabet.DataAccessAlphabet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptanalysis.DataAccessAlphabet.Calculete
{
    internal class ProbabilitySymbol
    {
        private List<AlphabetColumn> _alphabetColumns;
        private List<AlphabetColumn> _probabilytyOfEntry;

        public ProbabilitySymbol(List<AlphabetColumn> alphabetColumns, List<AlphabetColumn> probabilytyOfEntry)
        {
            _alphabetColumns = alphabetColumns;
            _probabilytyOfEntry = probabilytyOfEntry;
        }

        public double SumProbabilitySymbolInText()
        {
            List<AlphabetColumn> probabilitySymbolInText = GetProbabilitySymbolInText();
            double sum = probabilitySymbolInText.Select(probability => probability.Probability).Sum();
            return sum;
        }

        private List<AlphabetColumn> GetProbabilitySymbolInText()
        {
            List<AlphabetColumn> probabilitySymbolInText = _probabilytyOfEntry
                                                           .Select(column => CalculeteProbabilitySymbol(column.Char))
                                                           .ToList();
            return probabilitySymbolInText;
        }

        private AlphabetColumn CalculeteProbabilitySymbol(char mychar)
        {
            double probabilytyOfEntry = GetProbabilytyInChar(_probabilytyOfEntry, mychar);
            double alphabet = GetProbabilytyInChar(_alphabetColumns, mychar);
            double probabilitySymbol = Math.Pow((probabilytyOfEntry - alphabet), 2) / alphabet;
            return new AlphabetColumn(probabilitySymbol, mychar);
        }

        private double GetProbabilytyInChar(List<AlphabetColumn> alphabetColumns, char mychar)
        {
            double probability = alphabetColumns.FirstOrDefault(column => column.Char == mychar)?.Probability ?? -1;
            return probability;
        }

        private char GetCharInProbabilyty(List<AlphabetColumn> alphabetColumns, double probability)
        {
            char mychar = alphabetColumns.FirstOrDefault(column => column.Probability == probability)?.Char ?? '\0';
            return mychar;
        }
    }
}
