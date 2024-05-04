using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace CharacterCounter
{
    public partial class MainWindow : Window
    {
        Dictionary<char, int> characterCount;

        public MainWindow()
        {
            InitializeComponent();
            characterCount = new Dictionary<char, int>();
        }

        private void CountCharacters_Click(object sender, RoutedEventArgs e)
        {
            string input = InputTextBox.Text;

            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c))
                {
                    if (characterCount.ContainsKey(c))
                        characterCount[c]++;
                    else
                        characterCount[c] = 1;
                }
            }

            ResultListBox.Items.Clear();
            foreach (var entry in characterCount.OrderBy(x => x.Key))
            {
                ResultListBox.Items.Add($"Символ '{entry.Key}' встречается {entry.Value} раз.");
            }
        }
    }
}
