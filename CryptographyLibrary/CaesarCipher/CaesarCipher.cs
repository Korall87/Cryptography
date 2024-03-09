using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;


namespace CryptographyLibrary.CaesarCipher
{
    public class CaesarCipher
    {
        public string[] decryptionResult;

        public string Encrypt(string text, int k)
        {
            return caesarEncryptionAlgorithm(text, k);
        }

        public string Decipher(string text, int k)
        {
            return caesarEncryptionAlgorithm(text, -k);
        }

        public string[] Decryption(string text)
        {
            var resultText = new string[32];

            for (int i = 0; i < 32; i++)
            {
                resultText[i] = caesarEncryptionAlgorithm(text, -(i + 1));
            }

            return decryptionResult = resultText;
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
                    //int encryptedChar = (c + shift - offset) % 32 ) + offset;

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
