using System;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace WheelOfFortuneClient
{
    public partial class MainWindow : Window
    {
        private TcpClient client;
        private NetworkStream stream;

        public MainWindow()
        {
            InitializeComponent();
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            client = new TcpClient("192.168.113.244",13000);
            stream = client.GetStream();
            UpdateWordTemplate();
        }

        private void UpdateWordTemplate()
        {
            byte[] data = new byte[256];
            int bytes = stream.Read(data, 0, data.Length);
            string wordTemplate = Encoding.UTF8.GetString(data, 0, bytes);
            SecretWordTextBlock.Text = wordTemplate;
        }

        private void GuessButton_Click(object sender, RoutedEventArgs e)
        {
            string guess = GuessTextBox.Text;
            byte[] data = Encoding.UTF8.GetBytes(guess);
            stream.Write(data, 0, data.Length);
            UpdateWordTemplate();
            GuessTextBox.Clear();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            stream.Close();
            client.Close();
        }
    }
}
    