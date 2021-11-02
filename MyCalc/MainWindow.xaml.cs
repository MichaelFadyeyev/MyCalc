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
using System.Globalization;

namespace MyCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {

        private double firstOperator;
        private double secondOperator;
        private double storedResult;

        private bool inputFinished;
        private bool operationSet;
        private bool operationFinished;
        private bool errorFlag;

        private string currentOperation;
        private string storedOperation;
        private string defferedOperation;

        private string nds;

        public MainWindow()


        {
            InitializeComponent();
            inputField.Text = "0";
            queryField.Clear();
            operationFinished = true;
            storedOperation = "";
            defferedOperation = "";
            nds = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            dotButton.Content = nds;
        }

        private void AddRank(string r)
        {
            if (inputField.Text == "0" || inputFinished)
            {
                inputField.Text = r;
                if (errorFlag)
                {
                    errorFlag = false;
                    storedResult = 0;
                    ClearAll();
                }
                operationSet = false;
                inputFinished = false;
            }
            else
                inputField.Text += r;
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

            if (inputField.Text != "0" && operationSet == false)
                inputField.Text += "0";
            else
            {
                inputField.Text = "0";
                operationSet = false;
                inputFinished = false;
            }
        }

        private void dotButton_Click(object sender, RoutedEventArgs e)
        {           
            if (operationSet)
            {
                inputField.Text = "0" + nds;
                inputFinished = false;
                operationSet = false;
            }
            else
            {
                if (!inputField.Text.Contains(nds))
                {
                    inputField.Text += nds;
                    inputFinished = false;
                }
            }
        }

        // Operations input
        private void plusButton_Click(object sender, RoutedEventArgs e)
        {
            currentOperation = "+";
            SetOperands();
        }
        private void minusButton_Click(object sender, RoutedEventArgs e)
        {
            currentOperation = "-";
            SetOperands();
        }
        private void multiplyButton_Click(object sender, RoutedEventArgs e)
        {
            currentOperation = "*";
            SetOperands();
        }
        private void divButton_Click(object sender, RoutedEventArgs e)
        {
            currentOperation = "/";
            SetOperands();
        }


        // Commands input
        private void equalButton_Click(object sender, RoutedEventArgs e)
        {            
            if (!operationFinished)
            {
                queryField.Text += inputField.Text + "=";
                secondOperator = Double.Parse(inputField.Text);
                if (currentOperation == "*" || currentOperation == "/")
                {
                    if (Calculate(currentOperation))
                    {
                        if (defferedOperation != "")
                        {
                            secondOperator = firstOperator;
                            firstOperator = storedResult;
                            storedOperation = defferedOperation;
                            Calculate(storedOperation);
                        }
                        inputField.Text = firstOperator.ToString();
                    }
                    else
                        ErrorCase();
                }
                else
                {
                    Calculate(currentOperation);
                    inputField.Text = firstOperator.ToString();
                }
            }
            else
            {
                queryField.Text = inputField.Text + currentOperation + secondOperator.ToString() + "=";
                if (Calculate(currentOperation))
                    inputField.Text = firstOperator.ToString();
                else
                    ErrorCase();
            }
            defferedOperation = "";
            storedOperation = currentOperation;
            inputFinished = true;
            operationFinished = true;
            operationSet = false;
        }

        private void ceButton_Click(object sender, RoutedEventArgs e)
        {
            inputField.Text = "0";
            secondOperator = Double.Parse(inputField.Text);
        }

        private void cButton_Click(object sender, RoutedEventArgs e)
        {
            inputField.Text="0";
            firstOperator = 0;
            ClearAll();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            if (!inputFinished && !operationSet)
            {
                inputField.Text = inputField.Text.Remove(inputField.Text.Length - 1);
                if (inputField.Text.Length == 0)
                    inputField.Text = "0";               
            }
            else if (operationFinished)
            {
                queryField.Clear();
                storedOperation = "";
                currentOperation = "";
                inputFinished = true;
            }
        }

        // Calculations

        private void ClearAll()
        {
            queryField.Clear();
            storedOperation = "";
            currentOperation = "";
            inputFinished = true;
            operationFinished = true;
            operationSet = false;
        }

        private void SetOperands()
        {
            if (operationFinished)
            {
                queryField.Clear();
                firstOperator = Double.Parse(inputField.Text);
                queryField.Text += inputField.Text + currentOperation;
            }
            else
            {
                queryField.Text += inputField.Text + currentOperation;
                //=======================================================
                if (currentOperation == "*" || currentOperation == "/")
                {

                    if (storedOperation == "*" || storedOperation == "/")
                    {
                        secondOperator = Double.Parse(inputField.Text);

                        if (Calculate(storedOperation))
                            inputField.Text = firstOperator.ToString();
                        else
                            ErrorCase();
                    }
                    else
                    {
                        storedResult = firstOperator;
                        defferedOperation = storedOperation;
                        firstOperator = Double.Parse(inputField.Text);
                    }
                }
                else
                {
                    //========================================================
                    if ((storedOperation == "*" || storedOperation == "/") && defferedOperation != "")
                    {
                        secondOperator = Double.Parse(inputField.Text);
                        if (Calculate(storedOperation))
                        {
                            secondOperator = firstOperator;
                            firstOperator = storedResult;
                            storedOperation = defferedOperation;
                        }
                        else
                            ErrorCase();
                    }
                    else
                    {
                        defferedOperation = "";
                        secondOperator = Double.Parse(inputField.Text);
                    }
                    Calculate(storedOperation);
                    inputField.Text = firstOperator.ToString();
                }
            }

            storedOperation = currentOperation;
            inputFinished = true;
            operationFinished = false;
            operationSet = true;
        }

        private bool Calculate(string o)
        {
            switch (o)
            {
                case "+":
                    firstOperator += secondOperator;
                    return true;
                case "-":
                    firstOperator -= secondOperator;
                    return true;
                case "*":
                    firstOperator *= secondOperator;
                    return true;
                case "/":
                    if (secondOperator != 0)
                    {
                        firstOperator /= secondOperator;
                        return true;
                    }
                    else
                        return false;
                default:
                    return false;
            }
        }

        private void ErrorCase()
        {
            errorFlag = true;
            inputField.Text = "Ділити на нуль не можна";
        }
    }
}
