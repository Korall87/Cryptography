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
        public string[] decryptionArr { get; set; }

        public string Encrypt(string input, int shift)
        {
            EncryptedText = input; // проверить текст в кодировке юникод, 1040 до 1103, ?еще знаки припинания пробел?
            key = shift; // проверка на int               
            return expandedText = caesarEncryptionAlgorithm(EncryptedText, key);
           
        }      

        public string Decipher()
        {
           return  decryptedText = caesarEncryptionAlgorithm(expandedText, -key);

        }  

        public string[] Decryption()// переписать нормально, должен что-то возвращять
        {
            string[] result = new string[32];

            for (int i = 0; i < 32; i++)
            {
                result[i] = $"key = {i+1} : {caesarEncryptionAlgorithm(expandedText, -(i+1))}";
            }
            return decryptionArr = result;
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
