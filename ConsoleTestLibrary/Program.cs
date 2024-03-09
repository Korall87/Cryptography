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

            portCipher.method("НЕТ", "КЛЮЧ");
            portCipher.method("нет", "ключ");


            Console.ReadLine();
        }
    }
}
