using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyLibrary.CaesarCipher
{  
    public static class CaesarCipherAnalysis
    {
        // я хз как это работает, но вроде работает 
        public static double ChiSquaredTest(string text)
        {
            string alphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя";
            var letterFrequencies = new Dictionary<char, double>();

            foreach (char letter in alphabet)
            {
                double count = text.Count(c => char.ToLower(c) == letter);
                letterFrequencies[letter] = count / text.Length;
            }

            var expectedFrequencies = new Dictionary<char, double>
            {
                {'а', 0.0801}, {'б', 0.0159}, {'в', 0.0454}, {'г', 0.0170}, {'д', 0.0298},
                {'е', 0.0845}, {'ж', 0.0094}, {'з', 0.0165}, {'и', 0.0735}, {'й', 0.0121},
                {'к', 0.0349}, {'л', 0.0440}, {'м', 0.0321}, {'н', 0.0670}, {'о', 0.1097},
                {'п', 0.0281}, {'р', 0.0473}, {'с', 0.0547}, {'т', 0.0626}, {'у', 0.0262},
                {'ф', 0.0026}, {'х', 0.0097}, {'ц', 0.0048}, {'ч', 0.0144}, {'ш', 0.0073},
                {'щ', 0.0036}, {'ъ', 0.0004}, {'ы', 0.0190}, {'ь', 0.0174}, {'э', 0.0032},
                {'ю', 0.0064}, {'я', 0.0201}
            };

            double chiSquared = 0;

            foreach (char letter in alphabet)
            {
                double observedFrequency = letterFrequencies[letter] * text.Length;
                double expectedFrequency = expectedFrequencies[letter] * text.Length;

                chiSquared += Math.Pow(observedFrequency - expectedFrequency, 2) / expectedFrequency;
            }
            return chiSquared;

        }

        public static string BruteForceDecryptionPearsonSquare(DecryptionResult decryptionResult)
        {
            var dictionary = new Dictionary<double, string>();
            double min = int.MaxValue;
            int keyPirasanaSquare = 0;

            for (int i = 0; i < 32; i++)
            {
                var pirasanaSquare = CaesarCipherAnalysis.ChiSquaredTest(decryptionResult.text[i]);
                dictionary.Add(pirasanaSquare, decryptionResult.text[i]);

                if (pirasanaSquare < min)
                {
                    keyPirasanaSquare = decryptionResult.key[i];
                    min = pirasanaSquare;
                }
                
            }
            return $"для ключа {keyPirasanaSquare}: " + dictionary[min];

        }

        public static string СalculationDecryptionPearsonSquare(string text)
        {
            return "надо бы написать";
        }
    }
}
