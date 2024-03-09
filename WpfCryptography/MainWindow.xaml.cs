using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CryptographyLibrary.CaesarCipher;

namespace WpfCryptography
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
            public MainWindow()
            {
                InitializeComponent();
            }

            private void EncryptButton_Click(object sender, RoutedEventArgs e)
            {
                string inputText = InputTextBox.Text;
                int shift = Convert.ToInt32(ShiftTextBox.Text);

            var message = File.ReadAllText(messagePath);
            var key = possible_key.Text;

            if (message.Length != 0) // есть ли текст в файле? 
            {
                if (int.TryParse(key, out int keyInt) && keyInt > 0 && keyInt <= 50) // коректный ли ключ? 
                {
                    string encodedMessage = caesarCipher.Encrypt(message, keyInt); // шифрование                                    
                    encodedText.Text = encodedMessage;

                    File.WriteAllText(encodedMesssage, string.Empty);
                    using (StreamWriter sw = File.AppendText(encodedMesssage))
                    {
                        sw.WriteLine(encodedMessage);
                    }

                }

                //дешифрование
                private void getDecode_Click(object sender, RoutedEventArgs e)
                {
                    var message = File.ReadAllText(encodedMesssage); // текст который надо дешифровать
                    decodedText.Text = " ";

                    if (message.Length != 0) // есть ли текст в файле? 
                    {
                        var result = ConversionString.OutputData(caesarCipher.Decryption(message));
                        foreach (var item in result)
                        {
                            decodedText.Text += item + "\n\n";
                        }

                        using (StreamWriter sw = File.AppendText(cryptAnalisys))
                        {
                            sw.WriteLine(decodedText.Text);
                        }


                        //дешифрование
                        private void getDecode_Click(object sender, RoutedEventArgs e)
                        {
                            var message = File.ReadAllText(encodedMesssage);
                            decodedText.Text = "";

                            var result = ConversionString.OutputData(caesarCipher.Decryption(message));
                            foreach (var item in result)
                            {
                                decodedText.Text += item + "\n\n";
                            }

                            using (StreamWriter sw = File.AppendText(cryptAnalisys))
                            {
                                sw.WriteLine(decodedText.Text);
                            }

                        }
            else
                        {
                            MessageBox.Show($"Пустой файл {encodedMesssage}, рекомендуем сначала зашифровать текст.");
                        }
                    }
                    // 
                    //криптоанализ 
                    private void Cryptanalisys_Click(object sender, RoutedEventArgs e)
                    {
                        var strArr = caesarCipher.decryptionResult; // массив текста для которого надо посчитать квадрат пирсана 
                        cryptanalisysText.Text = "";

                        if (strArr?.Length != null)
                        {
                            for (int i = 0; i < strArr.Length; i++)
                            {
                                cryptanalisysText.Text += $"key = {i + 1}: {Math.Round(CaesarCipherAnalysis.ChiSquaredTest(strArr[i]), 3)} \n\n";
                            }

                            using (StreamWriter sw = File.AppendText(cryptAnalisys))
                            {
                                sw.WriteLine(cryptanalisysText.Text);
                            }

                        }
                        else
                        {
                            MessageBox.Show($"Пустой файл {encodedMesssage}, рекомендуем сначала декодировать текст.");// зачем изменить это
                        }
                    }

                    //Вывод текста 
                    private void getDefaultMessage()
                    {
                        string message = File.ReadAllText(messagePath);
                    }
            else
                    {
                        MessageBox.Show($"Пустой файл {encodedMesssage}, рекомендуем сначала зашифровать текст.");
                    }
                }

            }


            //дешифрование
            private void getDecode_Click(object sender, RoutedEventArgs e)
            {
                var message = File.ReadAllText(encodedMesssage); // текст который надо дешифровать
                decodedText.Text = " ";

                if (message.Length != 0) // есть ли текст в файле? 
                {
                    var result = ConversionString.OutputData(caesarCipher.Decryption(message));
                    foreach (var item in result)
                    {
                        decodedText.Text += item + "\n\n";
                    }

                    using (StreamWriter sw = File.AppendText(cryptAnalisys))
                    {
                        sw.WriteLine(decodedText.Text);
                    }

                }
                else
                {
                    MessageBox.Show($"Пустой файл {encodedMesssage}, рекомендуем сначала зашифровать текст.");
                }
            }
            // 
            //криптоанализ 
            private void Cryptanalisys_Click(object sender, RoutedEventArgs e)
            {
                var strArr = caesarCipher.decryptionResult; // массив текста для которого надо посчитать квадрат пирсана 
                cryptanalisysText.Text = "";

                if (strArr?.Length != null)
                {
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        cryptanalisysText.Text += $"key = {i + 1}: {Math.Round(CaesarCipherAnalysis.ChiSquaredTest(strArr[i]), 3)} \n\n";
                    }

                    using (StreamWriter sw = File.AppendText(cryptAnalisys))
                    {
                        sw.WriteLine(cryptanalisysText.Text);
                    }

                }
                else
                {
                    MessageBox.Show($"Пустой файл {encodedMesssage}, рекомендуем сначала декодировать текст.");// зачем изменить это
                }
            }

            //Вывод текста 
            private void getDefaultMessage()
            {
                string message = File.ReadAllText(messagePath);

                if (message.Length != 0)
                {
                    DefaultMessage.Text = message;
                }
            }

        }
    }

