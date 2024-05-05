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
using System.IO;
using Microsoft.Win32;

namespace BinaryFileConverter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WriteToFileButton_Click(object sender, RoutedEventArgs e)
        {
            string text = InputTextBox.Text;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Binary files (*.bin)|*.bin";
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    using (BinaryWriter writer = new BinaryWriter(File.Open(saveFileDialog.FileName, FileMode.Create)))
                    {
                        writer.Write(Encoding.UTF8.GetBytes(text));
                    }

                    MessageBox.Show("Текст успешно записан в файл.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при записи в файл: " + ex.Message);
                }
            }
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Binary files (*.bin)|*.bin";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    byte[] bytes = File.ReadAllBytes(openFileDialog.FileName);

                    StringBuilder convertedText = new StringBuilder();
                    foreach (byte b in bytes)
                    {
                        convertedText.Append(b.ToString() + " ");
                    }
                    OutputTextBlock.Text = convertedText.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при чтении файла: " + ex.Message);
                }
            }
        }
    }
}
