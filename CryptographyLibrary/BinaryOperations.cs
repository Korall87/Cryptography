using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyLibrary
{
    internal class BinaryOperations
    {
        public List<User> BinaryOperationsCryptography(string str)
        {
            var lines = new List<User>();

            int key = 0xA012;

            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                int curr_key = ShiftLeft(key, i);
                lines.Add(new User
                {
                    Letter = ch,
                    LetterCode = ch,
                    BinaryCode = IntToBin(ch, 16),
                    Key = IntToBin(curr_key, 16),
                    EncryptedCode = IntToBin(curr_key ^ ch, 16),
                    EncryptedLetter = (char)(curr_key ^ ch)
                });
            }

            return lines;
        }
        private static int ShiftLeft(int n, int s)
        {
            return ((n << s) & 0xFFFF) | (n >> (16 - s));
        }

        private static string IntToBin(int value, int digits)
        {
            string result = Convert.ToString(value, 2);
            while (result.Length < digits)
            {
                result = "0" + result;
            }

            return result;
        }
    }

    internal class User
    {
        public char? Letter { get; set; }
        public int? LetterCode { get; set; }
        public string? BinaryCode { get; set; }
        public string? Key { get; set; }
        public string? EncryptedCode { get; set; }
        public char? EncryptedLetter { get; set; }
    }
}
