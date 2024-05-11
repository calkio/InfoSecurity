using Caesar;
using Caesar.DataAccessAlphabet.DataAccessAlphabet;
using Cryptanalysis.DataAccessAlphabet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptanalysis.DataAccessAlphabet.Calculete
{
    public class StepSelection
    {
        public Dictionary<int, double> Probability { get; private set; }

        private string _text;
        private List<AlphabetColumn> _alphabetColumns;

        public StepSelection(string text)
        {
            _text = text;
            DataAccess dataAccess = new DataAccess();
            _alphabetColumns = dataAccess.GenerateProbability();
            CaluleteProbabilyty();
        }

        private void CaluleteProbabilyty()
        {
            CaesarProcces caesarProcces = new CaesarProcces(_text);
            Probability = new Dictionary<int, double>();
            for (int step = 0; step < 32; step++)
            {
                string newText = caesarProcces.GetCaesar(_text, step);
                ProbabilityOfEntry ProbabilityOfEntry = new ProbabilityOfEntry();
                List<AlphabetColumn> probabilytyOfEntry = ProbabilityOfEntry.GetProbabilityOfEntry(newText);
                
                ProbabilitySymbol probabilitySymbol = new ProbabilitySymbol(_alphabetColumns, probabilytyOfEntry);
                double probability = probabilitySymbol.SumProbabilitySymbolInText();
                Probability.Add(step, probability);
            }
        }
    }
}
