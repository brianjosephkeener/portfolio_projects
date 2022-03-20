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
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Win_Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            if(Window.Current.CoreWindow.GetKeyState(Windows.System.VirtualKey.Escape) == CoreVirtualKeyStates.Down)
            {
                Application.Current.Exit();
            }
        }

        private decimal temp1, temp2, result = decimal.Zero;
        private string ops = "";

        private void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key == Windows.System.VirtualKey.Number0)
            {
                _0_Click(sender, e);
            }
            if (e.Key == Windows.System.VirtualKey.Number1)
            {
                _1_Click(sender, e);
            }
            if (e.Key == Windows.System.VirtualKey.Number2)
            {
                _2_Click(sender, e);
            }
            if (e.Key == Windows.System.VirtualKey.Number3)
            {
                _3_Click(sender, e);
            }
            if (e.Key == Windows.System.VirtualKey.Number4)
            {
                _4_Click(sender, e);
            }
            if (e.Key == Windows.System.VirtualKey.Number5)
            {
                _5_Click(sender, e);
            }
            if (e.Key == Windows.System.VirtualKey.Number6)
            {
                _6_Click(sender, e);
            }
            if (e.Key == Windows.System.VirtualKey.Number7)
            {
                _7_Click(sender, e);
            }
            if (e.Key == Windows.System.VirtualKey.Number8)
            {
                _8_Click(sender, e);
            }
            if (e.Key == Windows.System.VirtualKey.Number9)
            {
                _9_Click(sender, e);
            }
        }

        private void _0_Click(object sender, RoutedEventArgs e)
        {
            if (output.Text != "0")
            {
                output.Text += "0";
            }
        }

        private void dot_Click(object sender, RoutedEventArgs e)
        {
            if(!output.Text.Contains("."))
            {
                output.Text += ".";
            }
        }

        private void _1_Click(object sender, RoutedEventArgs e)
        {

            string result = output.Text == "0" ? output.Text = "1" : output.Text += "1";
        }

        private void _2_Click(object sender, RoutedEventArgs e)
        {
            string result = output.Text == "0" ? output.Text = "2" : output.Text += "2";
        }

        private void _3_Click(object sender, RoutedEventArgs e)
        {
            string result = output.Text == "0" ? output.Text = "3" : output.Text += "3";
        }

        private void _4_Click(object sender, RoutedEventArgs e)
        {
            string result = output.Text == "0" ? output.Text = "4" : output.Text += "4";
        }

        private void _5_Click(object sender, RoutedEventArgs e)
        {
            string result = output.Text == "0" ? output.Text = "5" : output.Text += "5";
        }

        private void _6_Click(object sender, RoutedEventArgs e)
        {
            string result = output.Text == "0" ? output.Text = "6" : output.Text += "6";
        }

        private void _7_Click(object sender, RoutedEventArgs e)
        {
            string result = output.Text == "0" ? output.Text = "7" : output.Text += "7";
        }

        private void _8_Click(object sender, RoutedEventArgs e)
        {
            string result = output.Text == "0" ? output.Text = "8" : output.Text += "8";
        }

        private void _9_Click(object sender, RoutedEventArgs e)
        {
            string result = output.Text == "0" ? output.Text = "9" : output.Text += "9";
        }

        private void plus_minus_Click(object sender, RoutedEventArgs e)
        {
            string result = output.Text == "0" ? "nothing!" : output.Text.Contains("-") ? output.Text = output.Text.Trim('-') : output.Text = "-" + output.Text;
        }

        private void subtract_Click(object sender, RoutedEventArgs e)
        {
            temp1 = decimal.Parse(output.Text);
            output.Text = "";
            ops = "-";
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            temp1 = decimal.Parse(output.Text);
            output.Text = "";
            ops = "x";
        }

        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            temp1 = decimal.Parse(output.Text);
            output.Text = "";
            ops = "%";
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            temp1 = decimal.Parse(output.Text);
            output.Text = "";
            ops = "+";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            temp1 = decimal.Zero;
            temp2 = decimal.Zero;
            result = decimal.Zero;
            output.Text = "0";
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            temp1 = decimal.Parse(output.Text);
            output.Text = "";
            ops = "÷";
        }

        private void equal_Click(object sender, RoutedEventArgs e)
        {
            switch (ops)
            {
                case "-":
                    temp2 = decimal.Parse(output.Text);
                    result = temp1 - temp2;
                    output.Text = result.ToString();
                    ops = "";
                    break;
                case "+":
                    temp2 = decimal.Parse(output.Text);
                    result = temp1 + temp2;
                    output.Text = result.ToString();
                    ops = "";
                    break;
                case "÷":
                    temp2 = decimal.Parse(output.Text);
                    if(temp2 != 0)
                    {
                        result = temp1 / temp2;
                        output.Text = result.ToString();
                        ops = "";
                        break;
                    }
                    output.Text = "∞";
                    break;
                case "x":
                    temp2 = decimal.Parse(output.Text);
                    result = temp1 * temp2;
                    output.Text = result.ToString();
                    ops = "";
                    break;
                case "%":
                    temp2 = decimal.Parse(output.Text);
                    if (temp1 != 0)
                    {
                        result = (temp2 / temp1) * 100;
                        output.Text = result.ToString() + " Percent";
                        ops = "";
                        break;
                    }
                    output.Text = "∞";
                    break;
            }
        }
    }
}
