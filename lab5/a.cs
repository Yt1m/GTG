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

namespace PhoneCallDurationCalculatorWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int startHour = int.Parse(startHourTextBox.Text);
                int startMinute = int.Parse(startMinuteTextBox.Text);
                int startSecond = int.Parse(startSecondTextBox.Text);

                int endHour = int.Parse(endHourTextBox.Text);
                int endMinute = int.Parse(endMinuteTextBox.Text);
                int endSecond = int.Parse(endSecondTextBox.Text);

                TimeSpan startTime = new TimeSpan(startHour, startMinute, startSecond);
                TimeSpan endTime = new TimeSpan(endHour, endMinute, endSecond);

                TimeSpan duration = endTime - startTime;


                int totalMinutes = (int)Math.Ceiling(duration.TotalMinutes);

                durationLabel.Content = $"Продолжительность разговора: {totalMinutes} минут";
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректное время в формате чисел.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
