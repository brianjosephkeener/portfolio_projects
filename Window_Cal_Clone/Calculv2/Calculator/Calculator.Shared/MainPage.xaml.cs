using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calculator
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private decimal tempOne = 0.0m;
        private decimal tempTwo = 0.0m;
        private decimal result = 0.0m;
        private string ops = "+";

        private void Num_1(object sender, RoutedEventArgs e)
        {
            if(output.Text == "0")
            {
                output.Text = "1";
            }
            else
            {
                output.Text += "1";
            }
        }

        private void Num_2(object sender, RoutedEventArgs e)
        {
            if (output.Text == "0")
            {
                output.Text = "2";
            }
            else
            {
                output.Text += "2";
            }
        }

        private void Num_3(object sender, RoutedEventArgs e)
        {
            if (output.Text == "0")
            {
                output.Text = "3";
            }
            else
            {
                output.Text += "3";
            }
        }

        private void Num_4(object sender, RoutedEventArgs e)
        {
            if (output.Text == "0")
            {
                output.Text = "4";
            }
            else
            {
                output.Text += "4";
            }
        }

        private void Num_5(object sender, RoutedEventArgs e)
        {
            if (output.Text == "0")
            {
                output.Text = "5";
            }
            else
            {
                output.Text += "5";
            }
        }

        private void Num_6(object sender, RoutedEventArgs e)
        {
            if (output.Text == "0")
            {
                output.Text = "6";
            }
            else
            {
                output.Text += "6";
            }
        }

        private void Num_7(object sender, RoutedEventArgs e)
        {
            if (output.Text == "0")
            {
                output.Text = "7";
            }
            else
            {
                output.Text += "7";
            }
        }

        private void Num_8(object sender, RoutedEventArgs e)
        {
            if (output.Text == "0")
            {
                output.Text = "8";
            }
            else
            {
                output.Text += "8";
            }
        }

        private void Num_9(object sender, RoutedEventArgs e)
        {
            if (output.Text == "0")
            {
                output.Text = "9";
            }
            else
            {
                output.Text += "9";
            }
        }

        private void Num_0(object sender, RoutedEventArgs e)
        {
            if(output.Text == "0")
            {
                output.Text = "0";
            }
            else
            {
                output.Text += "0";
            }
        }

        private void DOT(object sender, RoutedEventArgs e)
        {
            if (!output.Text.Contains("."))
            {
                output.Text += ".";
            }
        }

        private void ADD(object sender, RoutedEventArgs e)
        {
            tempOne = decimal.Parse(output.Text);
            output.Text = "";
            ops = "+";
        }

        private void SUB(object sender, RoutedEventArgs e)
        {
            tempOne = decimal.Parse(output.Text);
            output.Text = "";
            ops = "-";
        }

        private void MUL(object sender, RoutedEventArgs e)
        {
            tempOne = decimal.Parse(output.Text);
            output.Text = "";
            ops = "*";
        }

        private void DIV(object sender, RoutedEventArgs e)
        {
            tempOne = decimal.Parse(output.Text);
            output.Text = "";
            ops = @"\";
        }

        private void EQ(object sender, RoutedEventArgs e)
        {
            switch (ops)
            {
                case "-":
                    tempTwo = decimal.Parse(output.Text);
                    result = tempOne - tempTwo;
                    output.Text = result.ToString();
                    break;
                case "+":
                    tempTwo = decimal.Parse(output.Text);
                    result = tempOne + tempTwo;
                    output.Text = result.ToString();
                    break;
                case @"\":
                    tempTwo = decimal.Parse(output.Text);
                    if(tempTwo == 0)
                    {
                        output.Text = "∞";
                        break;
                    }
                    result = tempOne / tempTwo;
                    output.Text = result.ToString();
                    break;
                case "*":
                    tempTwo = decimal.Parse(output.Text);
                    result = tempOne * tempTwo;
                    output.Text = result.ToString();
                    break;
            }

        }

        private void AllClr(object sender, RoutedEventArgs e)
        {
            tempOne = 0.0m;
            tempTwo = 0.0m;
            output.Text = "0";
        }

    }
}
