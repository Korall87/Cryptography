using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyLibrary.CaesarCipher
{
    public class CaesarCipher
    {
        public string encryptedText { get ; private set; }
        public int key { get; private set; }
        public string expandedText { get; private set; }
        public string decryptedText { get; private set; }

        public DecryptionResult decryptionResult;

        /// <summary>
        /// Для шифрования и расшифрования
        /// </summary>
        /// <param name="EncryptedText"></param>
        /// <param name="key"></param>
        public CaesarCipher(string encryptedText, int key )
        {
            this.encryptedText = encryptedText;
            this.key = key;
        }

        /// <summary>
        /// Для дешифрования
        /// </summary>
        /// <param name="expandedText"></param>
        public CaesarCipher(string expandedText)
        {
            this.expandedText = expandedText;
        }


        public string Encrypt()
            => expandedText = caesarEncryptionAlgorithm(encryptedText, key);


        public string Decipher()
        {
            if (expandedText == null)
            {
                this.expandedText = encryptedText;
            }
            return decryptedText = caesarEncryptionAlgorithm(expandedText, -key);   
            
        }
                      

        public DecryptionResult Decryption()
        {            
            var resultText = new string[32];
            var resultKey = new int[32];

            for (int i = 0; i < 32; i++)
            {
                resultText[i] = $"{caesarEncryptionAlgorithm(expandedText, - (i + 1))}";
                resultKey[i] = i + 1;
            }

            return decryptionResult =  new DecryptionResult
            {
                text = resultText,
                key = resultKey
            };
            
        }

        private string caesarEncryptionAlgorithm(string input, int shift)
        {
            StringBuilder encryptedText = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    //Unicode, диапазон от 1072 до 1103 символы русского алфавита в нижнем регистре,
                    //         диапазон от 1040 до 1071 символы русского алфавита в ВЕРХНЕМ регистре.
                    // источник https://symbl.cc/ru/unicode/table/#cyrillic
                    int offset = char.IsLower(c) ? 1072 : 1040;

                    int encryptedChar = ((c + shift - offset) % 32 + 32) % 32 + offset;

                    encryptedText.Append((char)encryptedChar);
                }
                else
                {
                    encryptedText.Append(c);
                }
            }
            return encryptedText.ToString();

        }
    }
}
