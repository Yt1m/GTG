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

namespace CharacterCounter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CountButton_Click(object sender, RoutedEventArgs e)
        {
            string input = InputTextBox.Text;
            Dictionary<char, int> charCount = CountCharacters(input);
            DisplayCharacterCounts(charCount);
        }

        private Dictionary<char, int> CountCharacters(string input)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            foreach (char c in input)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
                else
                    charCount[c] = 1;
            }

            return charCount;
        }

        private void DisplayCharacterCounts(Dictionary<char, int> charCount)
        {
            ResultTextBox.Clear();

            foreach (var kvp in charCount)
            {
                char character = kvp.Key;
                int count = kvp.Value;

                string displayString = $"{character}_{count} ";
                ResultTextBox.Text += displayString;
            }
        }
    }
}