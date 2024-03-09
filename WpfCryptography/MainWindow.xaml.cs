using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CryptographyLibrary;
using CryptographyLibrary.CaesarCipher;


// Надо на форме сделать возможность того, чтобы пользователь мог выбрать шифр из предложенных возможных (на одной форме это все должно располагаться).
// Файлы из которых будут считываться данные должны выбираться пользователем. Так как шрифтов будет много и можно запутаться в файлах. То есть чтобы пользователь выбирал файл, с кооторого он считывает данные.
// то есть сделать более дружественный интерфейс к пользователю
// именно в WPF должно осуществляться подключение разных страниц с разными шрифтами
// выпадающий список шрифтов(выбираем с каким шрифтом хочет работать пользователь).может кнопки?  
// чтобы не крипипастить куски кода из алгоритма Цезаря при написании следующего похожего шрифта( какие-то общие моменты выделить в уже готовом шифре при написании нового шифра похожего на шифр Цезарь)
namespace WpfCryptography
{
    public partial class MainWindow : Window
    {
        private string messagePath = "message.txt";
        private string cryptAnalisys = "cryptanalisys.txt";
        private string encodedMesssage = "encodedMesssage.txt";

        CaesarCipher caesarCipher = new CaesarCipher();

        public MainWindow()
        {
            if (File.Exists(messagePath) && File.ReadAllText(messagePath).Length != 0)
            {
                File.WriteAllText(cryptAnalisys, string.Empty);
                File.WriteAllText(encodedMesssage, string.Empty);
                InitializeComponent();
                getDefaultMessage();
            }
            else
            {
                File.WriteAllText(messagePath, string.Empty);
                MessageBox.Show($"Файл {messagePath} пустой, Запишите туда текст.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
                InitializeComponent();
                getDefaultMessage();
            }

        }

        // шифрование текста
        // берет значение из файла "message.txt" и записывает в файл "encodedMesssage.txt"
        private void getCode_Click(object sender, RoutedEventArgs e)
        {

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
                else
                {
                    MessageBox.Show($"Некорректный ключ. Ключ должен быть от 1 до 50", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show($"Пустой файл {messagePath}");
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