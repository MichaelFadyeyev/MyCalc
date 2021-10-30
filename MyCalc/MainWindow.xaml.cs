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
        double firstOp;
        double secondOp;
        bool hasFraction;
        bool isNegative;
        bool inputFinished;
        bool operationFinished;
        public MainWindow()
        {
            InitializeComponent();
            input = 0;
            inputField.Text = "0";
            queryField.Clear();
            hasFraction = false;
            isNegative = false;
            inputFinished = false;
            operationFinished = true;
            numbers = new List<double>();
            operations = new List<string>();
            firstOp = 0;
        }

        private void AddRank(string r)
        {
            if (inputField.Text=="0" || inputFinished)
                inputField.Text = r;
            else
                inputField.Text += r;
            inputFinished = false;
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
            if (firstOp == 0 || operationFinished)
            {
                if (operationFinished)
                {
                    queryField.Clear();
                    operationFinished = false;
                }
                queryField.Text += inputField.Text + "+";
                firstOp = Double.Parse(inputField.Text);
                inputFinished = true;
            }
            else
            {
                queryField.Text += inputField.Text + "+";
                secondOp = Double.Parse(inputField.Text);
                firstOp = firstOp + secondOp;
                inputField.Text = firstOp.ToString();
                inputFinished = true;
                operationFinished = false;
            }
        }
        private void minusButton_Click(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                if (firstOp == 0 || operationFinished)
                {
                    if (operationFinished)
                    {
                        queryField.Clear();
                        operationFinished = false;
                    }
                    queryField.Text += inputField.Text + "-";
                    firstOp = Double.Parse(inputField.Text);
                    inputFinished = true;
                }
                else
                {
                    queryField.Text += inputField.Text + "-";
                    secondOp = Double.Parse(inputField.Text);
                    firstOp = firstOp - secondOp;
                    inputField.Text = firstOp.ToString();
                    inputFinished = true;
                    operationFinished = false;
                }
            }
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
            queryField.Text += inputField.Text + "=";
            secondOp = Double.Parse(inputField.Text);
            firstOp = firstOp + secondOp;
            inputField.Text = firstOp.ToString();
            inputFinished = true;
            operationFinished = true;
        }

        private void ceButton_Click(object sender, RoutedEventArgs e)
        {
            inputField.Text = "0";
        }

        private void cButton_Click(object sender, RoutedEventArgs e)
        {
            inputField.Text="0";
            queryField.Clear();
            firstOp = 0;
            //secondOp = 0;
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
