using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyLibrary
{
    public static class ConversionString
    {
        public static string[] OutputData(string[] decryptionResult)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < decryptionResult.Length; i++)
            {
                result.Add($"key = {i + 1} : {decryptionResult[i]}");
            }
            return result.ToArray();
        }
    }
}
