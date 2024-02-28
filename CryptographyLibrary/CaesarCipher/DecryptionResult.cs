using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyLibrary.CaesarCipher
{
    public class DecryptionResult
    {
        internal string[] text { get; set; }
        internal int[] key { get; set; }

        public string[] OutputData()
        {
            List<string> result = new List<string>();

            for (int i = 0; i < text.Length; i++)
            {
                result.Add($"key = {key[i]} : {text[i]}");
            }
            return result.ToArray();
        }

    }
}
