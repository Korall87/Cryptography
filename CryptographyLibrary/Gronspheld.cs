using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSecurity_lab1
{
    internal class Gronspheld
    {
        private readonly string alfabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToLower();

        private readonly Dictionary<char, double> russianAlphabetProbabilities = new Dictionary<char, double>
        {
            {'а', 0.062}, {'б', 0.014}, {'в', 0.038}, {'г', 0.013}, {'д', 0.025},
            {'е', 0.072}, {'ж', 0.007}, {'з', 0.016}, {'и', 0.062}, {'й', 0.012},
            {'к', 0.028}, {'л', 0.035}, {'м', 0.026}, {'н', 0.053}, {'о', 0.090},
            {'п', 0.023}, {'р', 0.040}, {'с', 0.045}, {'т', 0.053}, {'у', 0.021},
            {'ф', 0.002}, {'х', 0.009}, {'ц', 0.003}, {'ч', 0.013}, {'ш', 0.006},
            {'щ', 0.003}, {'ъ', 0.014}, {'ы', 0.016}, {'ь', 0.014}, {'э', 0.003},
            {'ю', 0.006}, {'я', 0.018}
        };



        private string GetCode(string key, string text, int op)
        {
            string newKey = key, result = "";

            int indexOf, offset = 0;

            while (newKey.Length < text.Length)
            {
                newKey += key;
            }
            if (newKey.Length > text.Length)
            {
                newKey = newKey.Substring(0, newKey.Length - (newKey.Length - text.Length));
            }

            int i_ = 0;
            for (int i = 0; i < text.Length; i++)
            {
                indexOf = alfabet.IndexOf(text[i]);

                if (indexOf != -1)
                {
                    offset = alfabet.IndexOf(text[i]) + (Convert.ToInt32(newKey[i_]) - 48) * op;
                    if (offset >= alfabet.Length)
                        offset = offset - alfabet.Length;
                    else if (offset < 0)
                        offset = alfabet.Length + offset;
                    result += alfabet[offset];
                    i_++;
                }
                else
                {
                    result += text[i];
                }
            }

            return result;
        }

        public string Encrypt(string key, string text)
        {
            return GetCode(key, text, 1);
        }

        public string Decrypt(string key, string text)
        {
            return GetCode(key, text, -1);
        }

        private Dictionary<char, double> GetCharProbabilities(string text)
        {
            Dictionary<char, double> charProbabilities = new Dictionary<char, double>();
            int len = text.Length;

            foreach (char i in russianAlphabetProbabilities.Keys)
            {
                if (text.Contains(i))
                {
                    charProbabilities[i] = 1.0 * text.Count(x => x == i) / len;
                }
            }
            //foreach (char i in charProbabilities.Keys)
            //{
            //    charProbabilities[i] = charProbabilities[i] / len;
            //}

            return charProbabilities;
        }

        public double GetDefaultEntropy(string text)
        {
            double entropy = 0;

            foreach (char i in text)
            {
                char key = i;
                if (russianAlphabetProbabilities.ContainsKey(key))
                {
                    entropy += russianAlphabetProbabilities[key] * Math.Log2(russianAlphabetProbabilities[key]);
                }
            }

            return Math.Round(-entropy, 3);
        }

        public double GetEncodedEntropy(string text)
        {
            Dictionary<char, double> charProbabilities = GetCharProbabilities(text);
            double entropy = 0;

            foreach (char i in charProbabilities.Keys)
            {
                entropy += charProbabilities[i] * Math.Log2(charProbabilities[i]);
            }

            return Math.Round(-entropy, 3);
        }

        
    }
}
