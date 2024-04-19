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

namespace NormCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateComplexNorm_Click(object sender, RoutedEventArgs e)
        {
            double real = double.Parse(ComplexRealPart.Text);
            double imaginary = double.Parse(ComplexImaginaryPart.Text);
            Complex complex = new Complex(real, imaginary);
            double norm = complex.CalculateNorm();
            ComplexNormResult.Text = $"Norm: {norm}";
        }

        private void CalculateVectorNorm_Click(object sender, RoutedEventArgs e)
        {
            double x = double.Parse(VectorX.Text);
            double y = double.Parse(VectorY.Text);
            double z = double.Parse(VectorZ.Text);
            Vector3D vector = new Vector3D(x, y, z);
            double norm = vector.CalculateNorm();
            VectorNormResult.Text = $"Norm: {norm}";
        }
    }

    abstract class Norm
    {
        public abstract double CalculateNorm();
        public abstract double CalculateModulus();
    }

    class Complex : Norm
    {
        private double real;
        private double imaginary;

        public Complex(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public override double CalculateNorm()
        {
            return Math.Sqrt(real * real + imaginary * imaginary);
        }

        public override double CalculateModulus()
        {
            return Math.Pow(CalculateNorm(), 2);
        }
    }

    class Vector3D : Norm
    {
        private double x;
        private double y;
        private double z;

        public Vector3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override double CalculateNorm()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public override double CalculateModulus()
        {
            return Math.Max(Math.Max(Math.Abs(x), Math.Abs(y)), Math.Abs(z));
        }
    }
}
