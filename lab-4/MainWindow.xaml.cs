using AeroflotApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;


namespace AeroflotApp
{
    public partial class MainWindow : Window
    {
        private List<Aeroflot> aeroflotList = new List<Aeroflot>();

        public MainWindow()
        {
            InitializeComponent();
            aeroflotList.Add(new Aeroflot("Москва", "144", "Boeing 737"));
            aeroflotList.Add(new Aeroflot("Нью-Йорк", "195", "Airbus A320"));
            aeroflotList.Add(new Aeroflot("Лондон", "210", "Boeing 747"));
            aeroflotList.Add(new Aeroflot("Париж", "413", "Airbus A380"));
            aeroflotList.Add(new Aeroflot("Берлин", "625", "Boeing 777"));
            aeroflotList.Add(new Aeroflot("Токио", "150", "Airbus A350"));
            aeroflotList.Add(new Aeroflot("Пекин", "515", "Boeing 787"));
            aeroflotList.Sort(); 
            lstFlights.ItemsSource = aeroflotList;
        }

        private void SearchFlights_Click(object sender, RoutedEventArgs e)
        {
            string airplaneType = txtAirplaneType.Text;
            List<Aeroflot> filteredFlights = new List<Aeroflot>();

            foreach (Aeroflot flight in aeroflotList)
            {
                if (flight.AirplaneType.Equals(airplaneType, StringComparison.OrdinalIgnoreCase))
                {
                    filteredFlights.Add(flight);
                }
            }

            if (filteredFlights.Count == 0)
            {
                MessageBox.Show("Рейсов для введенного типа самолета не найдено.");
            }
            else
            {
                lstFlights.ItemsSource = filteredFlights;
            }
        }
    }

    public class Aeroflot : IComparable<Aeroflot>, ICloneable
    {
        public string Destination { get; set; }
        public string FlightNumber { get; set; }
        public string AirplaneType { get; set; }

        public Aeroflot(string destination, string flightNumber, string airplaneType)
        {
            Destination = destination;
            FlightNumber = flightNumber;
            AirplaneType = airplaneType;
        }

        public int CompareTo(Aeroflot other)
        {
            return string.Compare(Destination, other.Destination, StringComparison.Ordinal);
        }

        public object Clone()
        {
            return new Aeroflot(Destination, FlightNumber, AirplaneType);
        }
    }
}
