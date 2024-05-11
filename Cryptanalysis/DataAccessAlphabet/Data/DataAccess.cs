using Caesar.DataAccessAlphabet.DataAccessAlphabet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptanalysis.DataAccessAlphabet.Data
{
    internal class DataAccess
    {
        private Dictionary<char, double> _probability = new Dictionary<char, double>
        {
            {'а', 8.04},
            {'б', 1.59},
            {'в', 4.54},
            {'г', 1.70},
            {'д', 2.98},
            {'е', 8.45},
            {'ё', 0.03},
            {'ж', 1.01},
            {'з', 1.63},
            {'и', 7.33},
            {'й', 1.74},
            {'к', 3.48},
            {'л', 4.32},
            {'м', 3.20},
            {'н', 6.70},
            {'о', 10.97},
            {'п', 2.81},
            {'р', 5.53},
            {'с', 5.45},
            {'т', 6.26},
            {'у', 2.72},
            {'ф', 0.26},
            {'х', 1.01},
            {'ц', 0.48},
            {'ч', 1.44},
            {'ш', 0.72},
            {'щ', 0.36},
            {'ъ', 0.04},
            {'ы', 1.90},
            {'ь', 1.74},
            {'э', 0.42},
            {'ю', 0.64},
            {'я', 2.01}
        };

        public List<AlphabetColumn> GenerateProbability()
        {
            List<AlphabetColumn> alphabetProbability = _probability.Select(kv => new AlphabetColumn(kv.Value/100, kv.Key))
                                                                   .ToList();
            return alphabetProbability;
        }
    }
}
