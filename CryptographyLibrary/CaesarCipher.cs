using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyLibrary
{
    public class CaesarCipher
    {
        public string EncryptedText { get; set; }
        public int key { get; set; }
        public string expandedText { get; set; }  
        public string decryptedText { get; set; }

        // тут что-то должно быть еще 

        public string Encrypt(string input, int shift)
        {
            EncryptedText = input;
            key = shift;                     
            return expandedText = caesarEncryptionAlgorithm(EncryptedText, key);

        }      

        public string Decipher()
            => decryptedText = caesarEncryptionAlgorithm(expandedText, -key);     

        public void Decryption()// переписать нормально, должен что-то возвращять
        {
            for (int i = 1; i < 33; i++)
            {
                Console.WriteLine($"key = {i} : {caesarEncryptionAlgorithm(expandedText, -i)}");
            }

        }

        private string caesarEncryptionAlgorithm(string input, int shift)
        {
            StringBuilder encryptedText = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    //Unicode, диапазон от 1072 до 1103 символы русского алфавита в нижнем регистре,
                    //а диапазон от 1040 до 1071 символы русского алфавита в верхнем регистре.
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
