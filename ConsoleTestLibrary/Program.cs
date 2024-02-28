using System;
using CryptographyLibrary.CaesarCipher;

namespace ConsoleTestLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ceasarCipher = new CaesarCipher();

            int shift = 32;
            string originalText = "Калькулятор шифрует входной текст на русском языке всеми возможными комбинациями шифра Цезаря. Неалфавитные символы (пробелы, знаки препинания, цифры) — не преобразуются.\r\n\r\nШифр Цезаря один из наиболее древнейших известных шифров. Схема шифрования очень проста — используется сдвиг буквы алфавита на фиксированное число позиций. Используемое преобразование обычно обозначают как ROTN, где N — сдвиг, ROT — сокращение от слова ROTATE, в данном случае «циклический сдвиг».\r\n\r\nАлфавит действительно зацикливается, то есть буквы в конце алфавита преобразуются в буквы начала алфавита. Например, обозначение ROT2 обозначает сдвиг на 2 позиции, то есть, «а» превращается в «в», «б» в «г», и так далее, и в конце «ю» превращается в «а» а «я» — в «б». Число разных преобразований конечно и зависит от длины алфавита. Для русского языка возможно 32 разных преобразования (преобразования ROT0 и ROT33 сохраняют исходный текст, а дальше начинаются уже повторения). В связи с этим шифр является крайне слабым и исходный текст можно восстановить просто проверив все возможные преобразования.\r\n\r\nКалькулятор выдает таблицу всех возможных в шифре Цезаря преобразований введенного текста. Неалфавитные символы — знаки препинания, пробелы, цифры — не меняются.";

            ceasarCipher.Encrypt(originalText, shift);    
            Console.WriteLine($"Текст: {ceasarCipher.EncryptedText}"); 
            
            Console.WriteLine($"Зашифрованный текст: {ceasarCipher.expandedText}");
            Console.WriteLine($"Расшифрованный текст: {ceasarCipher.Decipher()}");

            //ceasarCipher.Decryption();
            //foreach (var item in ceasarCipher.decryptionArr)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine($"Значение хи-квадрат {CaesarCipherAnalysis.ChiSquaredTest(ceasarCipher.EncryptedText)}");
            Console.WriteLine( "======================================================================================================");
            
            Console.WriteLine($"Возможный вариант рассшифровки: {CaesarCipherAnalysis.DecryptionPirasanaSquare(ceasarCipher.Decryption())}"  );


            Console.ReadLine();
        }
    }
}
