using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipherLibrary
{
    public class CaesarCipher
    {
        public string EncryptedText {  get; set; }
        public int key { get; set; }
        public string expandedText { get; set; }       

        public string Encrypt(string input, int shift)
        {
            EncryptedText = input;
            key = shift;

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

            expandedText = encryptedText.ToString();
            return expandedText;
        }

        public string Decipher()
        {
            return Encrypt(expandedText, -key);
        }

        
        public void Decryption()// переписать нормально, должен что-то возвращять
        {
            string Decipher(int i)
            {
                return Encrypt(expandedText, i);
            }

            for (int i = 1; i < 33; i++)
            {
                Console.WriteLine($"key = {i} : {Decipher(i)}");
            }
        }
    }
}
