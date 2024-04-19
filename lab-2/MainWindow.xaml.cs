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



namespace YourNamespace
{
    public class Goods
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string InvoiceNumber { get; set; }

        public void ChangePrice(double newPrice)
        {
            Price = newPrice;
        }

        public void ChangeQuantity(int change)
        {
            Quantity += change;
        }

        public double CalculateTotalPrice()
        {
            return Price * Quantity;
        }

        public override string ToString()
        {
            return $"Total price: {CalculateTotalPrice()}";
        }
    }
}

namespace YourNamespace
{
    public partial class MainWindow : Window
    {
        private Goods _goods;

        public MainWindow()
        {
            InitializeComponent();
            _goods = new Goods();
        }

        private void ChangePrice_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(PriceTextBox.Text, out double newPrice))
            {
                _goods.ChangePrice(newPrice);
                ResultTextBlock.Text = $"Price changed to {newPrice}";
            }
            else
            {
                ResultTextBlock.Text = "Invalid price input";
            }
        }

        private void ChangeQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(QuantityTextBox.Text, out int change))
            {
                _goods.ChangeQuantity(change);
                ResultTextBlock.Text = $"Quantity changed by {change}";
            }
            else
            {
                ResultTextBlock.Text = "Invalid quantity input";
            }
        }

        private void CalculateTotalPrice_Click(object sender, RoutedEventArgs e)
        {
            var totalPrice = _goods.CalculateTotalPrice();
            ResultTextBlock.Text = $"Total price: {totalPrice}";
        }
    }
}
