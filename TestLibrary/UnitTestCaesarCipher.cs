using CryptographyLibrary.CaesarCipher;
using System;
using Xunit;

namespace TestLibrary
{
    public class UnitTestCaesarCipher
    {
        [Fact]
        public void Encrypt_InputTextAndShift_ReturnsEncryptedText()
        {
            string input = "аАоОяЯ";
            int shift = 1;

            CaesarCipher сaesarCipher = new CaesarCipher();

            var result = сaesarCipher.Encrypt(input, shift);

            Assert.NotNull(result);
            Assert.Equal("бБпПаА", result);
        }

        [Fact]
        public void Decipher_EncryptedText_ReturnsDecryptedText()
        {
            string input = "аАоОяЯ";
            int shift = 1;

            CaesarCipher сaesarCipher = new CaesarCipher();
            сaesarCipher.Encrypt(input, shift);

            var resultDecipher = сaesarCipher.Decipher();

            Assert.NotNull(resultDecipher);
            Assert.Equal("аАоОяЯ", resultDecipher);
        }

        [Fact]
        public void Decryption_EncryptedText_ReturnsMultipleDecryptedTexts()
        {
            string input = "аАоОяЯ";
            int shift = 1;

            CaesarCipher сaesarCipher = new CaesarCipher();
            сaesarCipher.Encrypt(input, shift);

            var decryptionArr = сaesarCipher.Decryption();

            Assert.NotNull(decryptionArr);
            Assert.Equal(32, decryptionArr.Length);
            Assert.Equal("key = 1 : аАоОяЯ", decryptionArr[0]);
            Assert.Equal("key = 2 : яЯнНюЮ", decryptionArr[1]);
            Assert.Equal("key = 3 : юЮмМэЭ", decryptionArr[2]);
            //доделать https://planetcalc.ru/1434/
        }
    }
}
