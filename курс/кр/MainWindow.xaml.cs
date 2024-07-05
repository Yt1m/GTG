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
using System.Windows;

namespace WpfApp9
{
    public partial class MainWindow : Window
    {
        private List<Ensemble> ensembles = new List<Ensemble>();

        public MainWindow()
        {
            InitializeComponent();
            LoadEnsembles();
        }

        private void LoadEnsembles()
        {
            ensembles.Add(new Ensemble { Name = "Ансамбль 1", NumberOfWorks = 15, CompactDiscs = new List<string> { "CD 1", "CD 2", "CD 3" } });
            ensembles.Add(new Ensemble { Name = "Ансамбль 2", NumberOfWorks = 20, CompactDiscs = new List<string> { "CD 4", "CD 5", "CD 6" } });
            ensembles.Add(new Ensemble { Name = "Ансамбль 3", NumberOfWorks = 10, CompactDiscs = new List<string> { "CD 7", "CD 8", "CD 9" } });

            ensembleComboBox.ItemsSource = ensembles;
            ensembleComboBox.DisplayMemberPath = "Name";
        }

        private void EnsembleComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Ensemble selectedEnsemble = ensembleComboBox.SelectedItem as Ensemble;
            if (selectedEnsemble != null)
            {
                infoTextBlock.Text = $"Выбран ансамбль: {selectedEnsemble.Name}\n";
            }
        }

        private void ShowNumberOfWorks_Click(object sender, RoutedEventArgs e)
        {
            Ensemble selectedEnsemble = ensembleComboBox.SelectedItem as Ensemble;
            if (selectedEnsemble != null)
            {
                infoTextBlock.Text = $"Количество произведений для ансамбля '{selectedEnsemble.Name}': {selectedEnsemble.NumberOfWorks}\n";
            }
        }

        private void LoadCompactDiscs_Click(object sender, RoutedEventArgs e)
        {
            Ensemble selectedEnsemble = ensembleComboBox.SelectedItem as Ensemble;
            if (selectedEnsemble != null)
            {
                infoTextBlock.Text = $"Названия компакт-дисков для ансамбля '{selectedEnsemble.Name}':\n";
                foreach (var disc in selectedEnsemble.CompactDiscs)
                {
                    infoTextBlock.Text += disc + "\n";
                }
            }
        }

        private void ShowTopSellers_Click(object sender, RoutedEventArgs e)
        {
         
            infoTextBlock.Text = "Лидеры продаж:\nCD 1\nCD 2"; 
        }

        private void ShowMostPurchasedCDs_Click(object sender, RoutedEventArgs e)
        {
           
            infoTextBlock.Text = "Часто покупаемые диски в текущем году:\nCD 1\nCD 2";
        }

        private void ModifyCDData_Click(object sender, RoutedEventArgs e)
        {
    
            MessageBox.Show("Изменение данных о дисках"); 
        }

        private void AddOrUpdateEnsemble_Click(object sender, RoutedEventArgs e)
        {
      
            string ensembleName = ensembleNameTextBox.Text.Trim();
            int numberOfWorks;
            List<string> compactDiscs = new List<string>();

            if (!int.TryParse(numberOfWorksTextBox.Text.Trim(), out numberOfWorks))
            {
                MessageBox.Show("Введите корректное количество произведений.");
                return;
            }

            if (!string.IsNullOrEmpty(compactDiscsTextBox.Text.Trim()))
            {
                compactDiscs = new List<string>(compactDiscsTextBox.Text.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            }

            Ensemble existingEnsemble = ensembles.Find(en => en.Name == ensembleName);
            if (existingEnsemble != null)
            {
                existingEnsemble.NumberOfWorks = numberOfWorks;
                existingEnsemble.CompactDiscs = compactDiscs;
                MessageBox.Show($"Ансамбль '{ensembleName}' успешно обновлен.");
            }
            else
            {
                ensembles.Add(new Ensemble { Name = ensembleName, NumberOfWorks = numberOfWorks, CompactDiscs = compactDiscs });
                ensembleComboBox.ItemsSource = null; 
                ensembleComboBox.ItemsSource = ensembles; 
                MessageBox.Show($"Ансамбль '{ensembleName}' успешно добавлен.");
            }
        }
    }

    public class Ensemble
    {
        public string Name { get; set; }
        public int NumberOfWorks { get; set; }
        public List<string> CompactDiscs { get; set; }
    }
}
