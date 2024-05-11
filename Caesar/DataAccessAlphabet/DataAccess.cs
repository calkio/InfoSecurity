using Caesar.DataAccessAlphabet.DataAccessAlphabet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar.DataAccessAlphabet
{
    internal class DataAccess
    {
        public List<AlphabetColumn> GenerateAlphabetColumn()
        {
            string pathFile = @"D:\Dev\InformationSecuriti\Lab\Caesar\DataAccessAlphabet\Data\Alphabet.txt";

            // Чтение содержимого файла
            string fileContent = File.ReadAllText(pathFile);

            // Разбиение содержимого на три строки
            string[] lines = fileContent.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            // Создание трех списков
            List<int> numbers = lines[0].Split(' ').Select(int.Parse).ToList();
            List<char> letters = lines[1].Split(' ').Where(s => !string.IsNullOrEmpty(s) && s.Length == 1)
                                                         .Select(char.Parse)
                                                         .ToList();

            List<AlphabetColumn> alphabetColumns = new List<AlphabetColumn>();
            for (int i = 0; i < numbers.Count; i++)
            {
                AlphabetColumn alphabetColumn = new AlphabetColumn(numbers[i], letters[i]);
                alphabetColumns.Add(alphabetColumn);
            }

            return alphabetColumns;
        }
    }
}
