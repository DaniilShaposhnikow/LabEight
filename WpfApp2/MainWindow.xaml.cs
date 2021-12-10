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
using System.Security.Cryptography;
using System.IO;

namespace WpfApp2
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string input = textBox1.Text;
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            if (radioButton1.IsChecked == true)
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] hashedBytes = md5.ComputeHash(inputBytes);
                textBox2.Text = BitConverter.ToString(hashedBytes);
            }
            else if (radioButton2.IsChecked == true)
            {
                SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
                byte[] hashedBytes = sha.ComputeHash(inputBytes);
                textBox2.Text = BitConverter.ToString(hashedBytes);
            }
            else if (radioButton3.IsChecked == true)
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] blanks = System.Text.Encoding.UTF8.GetBytes("        "); // 8 spaces
                des.Key = blanks;
                des.IV = blanks;
                des.Padding = PaddingMode.Zeros;
                MemoryStream ms = new MemoryStream();
                CryptoStream cs =
                  new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputBytes, 0, inputBytes.Length);
                cs.Close();
                byte[] encryptedBytes = ms.ToArray();
                ms.Close();
                textBox2.Text = BitConverter.ToString(encryptedBytes);
            }
        }
        private void OnFileExit(object sender, RoutedEventArgs e)
        {

        }

    }
}
