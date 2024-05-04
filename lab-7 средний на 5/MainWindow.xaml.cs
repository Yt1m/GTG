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
using System.Collections.Generic;

namespace QueueImplementation
{
    public partial class MainWindow : Window
    {
        private Queue<(string phone, decimal price)> queue;

        public MainWindow()
        {
            InitializeComponent();
            queue = new Queue<(string, decimal)>();
        }

        private void EnqueueButton_Click(object sender, RoutedEventArgs e)
        {
            string phone = PhoneTextBox.Text;
            decimal price = decimal.Parse(PriceTextBox.Text);
            queue.Enqueue((phone, price));
            UpdateQueueDisplay();
        }

        private void DequeueButton_Click(object sender, RoutedEventArgs e)
        {
            if (queue.Count > 0)
            {
                queue.Dequeue();
                UpdateQueueDisplay();
            }
            else
            {
                MessageBox.Show("Очередь пуста.");
            }
        }

        private void UpdateQueueDisplay()
        {
            QueueDisplayTextBox.Text = "";
            foreach (var item in queue)
            {
                QueueDisplayTextBox.Text += $"Телефон: {item.phone}, Цена: {item.price}" + Environment.NewLine;
            }
        }
    }
}
