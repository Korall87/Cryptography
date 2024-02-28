using System;
using System.Xml.Schema;
using CryptographyLibrary.CaesarCipher;

namespace ConsoleTestLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // шифрование 
            var caesarCipher = new CaesarCipher("Привет, как дела?", 5);
            Console.WriteLine(caesarCipher.Encrypt());

            // расшифрование
            var caesarCipher1 = new CaesarCipher("Фхнзкч, пеп йкре?",5);
            Console.WriteLine(caesarCipher1.Decipher());


            // дешифрование 
            var caesarCipher2 = new CaesarCipher("Фхнзкч, пеп йкре?");
            caesarCipher2.Decryption();

            var strArr =  caesarCipher2.decryptionResult.OutputData();
            foreach (var str in strArr)
            {
                Console.WriteLine(str);
            }

            // что-то там с квадратом Пирсена
            Console.WriteLine(CaesarCipherAnalysis.ChiSquaredTest(caesarCipher.encryptedText));
            Console.WriteLine(CaesarCipherAnalysis.ChiSquaredTest(caesarCipher.expandedText));

            Console.WriteLine(CaesarCipherAnalysis.ChiSquaredTest(caesarCipher1.decryptedText));

            //Дешифрование с помощью квадрата Пирсена
            Console.WriteLine(CaesarCipherAnalysis.BruteForceDecryptionPearsonSquare(caesarCipher1.Decryption()));
            Console.WriteLine(CaesarCipherAnalysis.BruteForceDecryptionPearsonSquare(caesarCipher2.Decryption()));


            Console.ReadLine();

        }
    }
}
