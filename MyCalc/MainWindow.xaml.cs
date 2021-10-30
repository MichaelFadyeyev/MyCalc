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

namespace MyCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        double input;
        List<double> numbers;
        List<string> operations;
        double first;
        bool hasFraction;
        bool isNegative;
        public MainWindow()
        {
            InitializeComponent();
            input = 0;
            inputField.Text = "0";
            queryField.Clear();
            hasFraction = false;
            isNegative = false;
            numbers = new List<double>();
            operations = new List<string>();
            first = 0;
        }

        private void AddRank(string r)
        {
            if (inputField.Text=="0" || input == 0)
                inputField.Text = r;
            else
                inputField.Text += r;
            input = Double.Parse(inputField.Text);
        }

        // Numbers input
        private void oneButton_Click(object sender, RoutedEventArgs e)
        {
            AddRank("1");
        }

        private void twoButton_Click(object sender, RoutedEventArgs e)
        {
            AddRank("2");
        }

        private void threeButton_Click(object sender, RoutedEventArgs e)
        {
            AddRank("3");
        }

        private void fourButton_Click(object sender, RoutedEventArgs e)
        {
            AddRank("4");
        }

        private void fiveButton_Click(object sender, RoutedEventArgs e)
        {
            AddRank("5");
        }

        private void sixButton_Click(object sender, RoutedEventArgs e)
        {
            AddRank("6");
        }

        private void sevenButton_Click(object sender, RoutedEventArgs e)
        {
            AddRank("7");
        }

        private void eightButton_Click(object sender, RoutedEventArgs e)
        {
            AddRank("8");
        }

        private void nineButton_Click(object sender, RoutedEventArgs e)
        {
            AddRank("9");
        }

        private void zeroButton_Click(object sender, RoutedEventArgs e)
        {
            if (inputField.Text != "0")
            {
                inputField.Text += "0";
            }

        }

        private void dotButton_Click(object sender, RoutedEventArgs e)
        {
            if (!inputField.Text.Contains(","))
            {
                inputField.Text +=",";
                hasFraction = true;
            }
        }

        // Operations input
        private void plusButton_Click(object sender, RoutedEventArgs e)
        {
            if (queryField.Text.Length == 0)
            {
                first = Double.Parse(inputField.Text);
            }
            else if (inputField.Text.Length != 0)
            {
                first += Double.Parse(inputField.Text);
                queryField.Text += first.ToString() + "+";
                inputField.Text = first.ToString();
            }
            input = 0;
        }
        private void minusButton_Click(object sender, RoutedEventArgs e)
        {
            if (queryField.Text.Length == 0)
            {
                queryField.Text = "-";
                first = Double.Parse(inputField.Text);
            }
            else if (inputField.Text.Length!=0)
            {
                first -= Double.Parse(inputField.Text);                
                queryField.Text += first.ToString() + "-";
                inputField.Text = first.ToString();
            }
            input = 0;
        }
        private void multiplyButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void divButton_Click(object sender, RoutedEventArgs e)
        {

        }


        // Commands input
        private void equalButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ceButton_Click(object sender, RoutedEventArgs e)
        {
            inputField.Text = "0";
        }

        private void cButton_Click(object sender, RoutedEventArgs e)
        {
            inputField.Text="0";
            queryField.Clear();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
