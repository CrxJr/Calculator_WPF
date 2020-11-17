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

namespace WPF_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {

        double lastNumber;
        double currentNumber;
        double result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumericValue(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            if (txtDisplay.Text == "0")
                txtDisplay.Text = "";

            txtDisplay.Text += b.Content;
            
            currentNumber = Double.Parse(txtDisplay.Text);
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            lastNumber = 0;
            result = 0;
            currentNumber = 0;
            selectedOperator = SelectedOperator.none;
            txtDisplay.Text = "0";
        }


        private void percentage_Click(object sender, RoutedEventArgs e)
        {
            if(lastNumber == 0)
            {
                currentNumber /= 100;
                txtDisplay.Text = currentNumber.ToString();
            }
            else
            {
                currentNumber *= lastNumber / 100;
                txtDisplay.Text = currentNumber.ToString();
            }
        }

        private void plus_minus_Click(object sender, RoutedEventArgs e)
        {
            currentNumber *= -1;
            txtDisplay.Text = currentNumber.ToString();
        }

        private void _decimal_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            if (!txtDisplay.Text.Contains(".")){
                txtDisplay.Text += b.Content;
            }
        }

        private void Operations(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            switch (b.Content)
            {
                case "+":
                    selectedOperator = SelectedOperator.add;
                    lastNumber = currentNumber;
                    currentNumber = 0;
                    txtDisplay.Text = currentNumber.ToString();
                    break;
                case "-":
                    selectedOperator = SelectedOperator.substract;
                    lastNumber = currentNumber;
                    currentNumber = 0;
                    txtDisplay.Text = currentNumber.ToString();
                    break;
                case "*":
                    selectedOperator = SelectedOperator.multiply;
                    lastNumber = currentNumber;
                    currentNumber = 0;
                    txtDisplay.Text = currentNumber.ToString();
                    break;
                case "/":
                    selectedOperator = SelectedOperator.divide;
                    lastNumber = currentNumber;
                    currentNumber = 0;
                    txtDisplay.Text = currentNumber.ToString();
                    break;
            }
        }

        private void MathService(object sender, RoutedEventArgs e)
        {
            if (selectedOperator == SelectedOperator.add)
            {
                result = currentNumber + lastNumber;
                txtDisplay.Text = result.ToString();
                currentNumber = result;
            }
            if (selectedOperator == SelectedOperator.substract)
            {
                result = lastNumber - currentNumber;
                txtDisplay.Text = result.ToString();
                currentNumber = result;
            }
            if (selectedOperator == SelectedOperator.divide)
            {
                if (currentNumber != 0)
                {
                    result = lastNumber / currentNumber;
                    txtDisplay.Text = result.ToString();
                    currentNumber = result;
                }
                else
                {
                    MessageBox.Show("Sorry, division by 0 is impossible");
                    clear_Click(sender, e);
                }
            }
            if (selectedOperator == SelectedOperator.multiply)
            {
                result = lastNumber * currentNumber;
                txtDisplay.Text = result.ToString();
                currentNumber = result;
            }
        }
    }

    enum SelectedOperator
    {
        add, substract, divide, multiply, none
    }
}
