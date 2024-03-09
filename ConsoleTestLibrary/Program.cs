using System;
using System.Xml.Schema;
using CryptographyLibrary;
using CryptographyLibrary.CaesarCipher;

namespace ConsoleTestLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var portCipher = new PortCipher();

            Console.WriteLine(portCipher.EncryptionDecryption("НЕТ", "КЛЮЧ"));
            Console.WriteLine(portCipher.EncryptionDecryption("нет", "ключ"));

            Console.ReadLine();
        }
    }
}
