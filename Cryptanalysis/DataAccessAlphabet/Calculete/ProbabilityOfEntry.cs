using Caesar.DataAccessAlphabet.DataAccessAlphabet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptanalysis.DataAccessAlphabet.Calculete
{
    internal class ProbabilityOfEntry
    {
        public List<AlphabetColumn> GetProbabilityOfEntry(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new Exception("Пустой текст (как и твоя бошка:))");
            }

            var charOccurrences = text
                .GroupBy(c => c)
                .ToDictionary(g => g.Key, g => (double)g.Count() / text.Length);

            var result = charOccurrences
                .Select(kv => new AlphabetColumn(kv.Value, kv.Key))
                .ToList();

            return result;
        }
    }
}
