using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayOperations
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string[] input = Memo.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<double> numbers = new List<double>();

            foreach (string item in input)
            {
                try
                {
                    double number = double.Parse(item);
                    numbers.Add(number);
                }
                catch (FormatException)
                {
                    MessageBox.Show($"Некорректный ввод: {item}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (!numbers.Any())
            {
                MessageBox.Show("Не введено ни одного числа.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double average = numbers.Average();

            MessageBox.Show($"Среднее значение чисел: {average}", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
