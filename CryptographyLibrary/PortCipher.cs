using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyLibrary
{
    public class PortCipher
    {
        private int CharacterReplacement(int ch, int keyChar)
        {
            int Key = keyChar/2;

            if (ch < 16)
            {
                //из верха вних
                if (ch < 16 - Key)
                {
                    return ch + Key + 16;
                }
                else
                {
                    return ch + Key;
                }
            }
            else
            {
                //из вниза верх
                if (ch >= 16 + Key)
                {       
                    return ch - Key - 16;
                }
                else
                {
                    return ch - Key;
                }
            }

        }

        public string EncryptionDecryption(string text, string keys)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                int offset = char.IsLower(text[i]) ? 1072 : 1040;
                int ch = text[i] - offset;

                offset = char.IsLower(keys[i % keys.Length]) ? 1072 : 1040;
                int key = keys[i % keys.Length] - offset;

                stringBuilder.Append((char)(CharacterReplacement(ch, key)+offset));
            }

            return stringBuilder.ToString();
        }
    }
}
