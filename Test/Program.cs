using System;
using CaesarCipherLibrary;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ceasarCipher = new CaesarCipher();

            int shift = 1;
            string originalText = "аАяЯ. Привет, как дела?";

            ceasarCipher.Encrypt(originalText, shift);
          
            Console.WriteLine($"Текст: {ceasarCipher.EncryptedText}");                    
            Console.WriteLine($"Зашифрованный текст: {ceasarCipher.expandedText}");
            Console.WriteLine($"Расшифрованный текст: {ceasarCipher.Decipher()}");
            ceasarCipher.Decryption();


            Console.ReadLine();
        }
    }
}
