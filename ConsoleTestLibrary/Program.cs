using System;
using CryptographyLibrary;

namespace ConsoleTestLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ceasarCipher = new CaesarCipher();

            int shift = 5;
            string originalText = "Привет, как дела";

            ceasarCipher.Encrypt(originalText, shift);    
            Console.WriteLine($"Текст: {ceasarCipher.EncryptedText}"); 
            
            Console.WriteLine($"Зашифрованный текст: {ceasarCipher.expandedText}");
            Console.WriteLine($"Расшифрованный текст: {ceasarCipher.Decipher()}");

            ceasarCipher.Decryption();
            foreach (var item in ceasarCipher.decryptionArr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Значение хи-квадрат {CaesarCipherAnalysis.ChiSquaredTest(ceasarCipher.EncryptedText)}");

            Console.ReadLine();
        }
    }
}
