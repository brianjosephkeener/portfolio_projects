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
    /// If non-interactive element in window is clicked on or brought to focus after start up, keypresses are not recognized. This can be reset with a button click. THANKS FOR NO HELP MICROSOFT. 
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
        }

        private double temp1, temp2, result = double.MinValue;
        private string ops;
        public string word = "";

        private void letter_reset()
        {
            letter_input.Text = "";
        }
        private void letter_test(object sender, KeyRoutedEventArgs e) // want the text to persist after finishing the word but also dont want to do it ¯\_( ͡❛ ͜ʖ͡❛ )_/¯
        {
            if (e.Key == Windows.System.VirtualKey.Z && letter_input.Text == "")
            {
                letter_input.Text += "z";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.E && letter_input.Text == "z")
            {
                letter_input.Text += "e";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.R && letter_input.Text == "ze")
            {
                letter_input.Text += "r";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.O && letter_input.Text == "zer") // zero finish
            {
                letter_input.Text += "o";
                _0_Click(sender, e);
                letter_reset();
                return;
            }
            if (e.Key == Windows.System.VirtualKey.O && letter_input.Text == "")
            {
                letter_input.Text += "o";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.N && letter_input.Text == "o")
            {
                letter_input.Text += "n";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.E && letter_input.Text == "on") // one finish
            {
                letter_input.Text += "e";
                _1_Click(sender, e);
                letter_reset();
                return;
            }
            if (e.Key == Windows.System.VirtualKey.T && letter_input.Text == "")
            {
                letter_input.Text += "t";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.W && letter_input.Text == "t")
            {
                letter_input.Text += "w";
                return;
            }
            else if (e.Key == Windows.System.VirtualKey.H && letter_input.Text == "t")
            {
                letter_input.Text += "h";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.O && letter_input.Text == "tw") // two finish
            {
                letter_input.Text += "o";
                _2_Click(sender, e);
                letter_reset();
                return;
            }
            if (e.Key == Windows.System.VirtualKey.R && letter_input.Text == "th")
            {
                letter_input.Text += "r";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.E && letter_input.Text == "thr")
            {
                letter_input.Text += "e";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.E && letter_input.Text == "thre") // three finish
            {
                letter_input.Text += "e";
                _3_Click(sender, e);
                letter_reset();
                return;
            }
            if (e.Key == Windows.System.VirtualKey.F && letter_input.Text == "")
            {
                letter_input.Text += "f";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.O && letter_input.Text == "f")
            {
                letter_input.Text += "o";
                return;
            }
            else if(e.Key == Windows.System.VirtualKey.I && letter_input.Text == "f")
            {
                letter_input.Text += "i";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.U && letter_input.Text == "fo")
            {
                letter_input.Text += "u";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.R && letter_input.Text == "fou") // four finish
            {
                letter_input.Text += "e";
                _4_Click(sender, e);
                letter_reset();
                return;
            }
            if (e.Key == Windows.System.VirtualKey.V && letter_input.Text == "fi")
            {
                letter_input.Text += "v";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.E && letter_input.Text == "fiv") // five finish
            {
                letter_input.Text += "e";
                _5_Click(sender, e);
                letter_reset();
                return;
            }
            if(e.Key == Windows.System.VirtualKey.S && letter_input.Text == "")
            {
                letter_input.Text += "s";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.I && letter_input.Text == "s")
            {
                letter_input.Text += "i";
                return;
            }
            else if (e.Key == Windows.System.VirtualKey.E && letter_input.Text == "s")
            {
                letter_input.Text += "e";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.X && letter_input.Text == "si") // six finish 
            {
                letter_input.Text += "x";
                _6_Click(sender, e);
                letter_reset();
                return;
            }
            if (e.Key == Windows.System.VirtualKey.V && letter_input.Text == "se")
            {
                letter_input.Text += "v";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.E && letter_input.Text == "sev")
            {
                letter_input.Text += "e";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.N && letter_input.Text == "seve") // seven finish
            {
                letter_input.Text += "n";
                _7_Click(sender, e);
                letter_reset();
                return;
            }
            if (e.Key == Windows.System.VirtualKey.E && letter_input.Text == "")
            {
                letter_input.Text += "e";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.I && letter_input.Text == "e")
            {
                letter_input.Text += "i";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.G && letter_input.Text == "ei")
            {
                letter_input.Text += "g";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.H && letter_input.Text == "eig")
            {
                letter_input.Text += "h";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.T && letter_input.Text == "eigh") // eight finish
            {
                letter_input.Text += "t";
                _8_Click(sender, e);
                letter_reset();
                return;
            }
            if (e.Key == Windows.System.VirtualKey.N && letter_input.Text == "")
            {
                letter_input.Text += "n";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.I && letter_input.Text == "n")
            {
                letter_input.Text += "i";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.N && letter_input.Text == "ni")
            {
                letter_input.Text += "n";
                return;
            }
            if (e.Key == Windows.System.VirtualKey.E && letter_input.Text == "nin") // nine finish
            {
                letter_input.Text += "e";
                _9_Click(sender, e);
                letter_reset();
                return;
            }
            else
            {
                letter_reset();
            }
        }

        private void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            letter_test(sender, e);
            if(e.Key == Windows.System.VirtualKey.Escape)
            {
                Application.Current.Exit();
            }
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
            if (e.Key == Windows.System.VirtualKey.End) // personal preference to use End
            {
                equal_Click(sender, e);
            }

            /*
                There is no alternative at this time to add non-numpad decimal, +, -, division or multiplication for WIN-UI/3 (UWP).
                Currently, there is a request in the microsoft github for a change to add more virtual keys. (2020)
            */

            if (e.Key == Windows.System.VirtualKey.Decimal) // numpad decimal
            {
                dot_Click(sender, e);
            }
            if (e.Key == Windows.System.VirtualKey.Add) // numpad + sign
            {
                add_Click(sender, e);
            }
            if (e.Key == Windows.System.VirtualKey.Subtract) // numpad - sign
            {
                subtract_Click(sender, e);
            }
            if (e.Key == Windows.System.VirtualKey.Divide) // numpad / sign
            {
                divide_Click(sender, e);
            }
            if (e.Key == Windows.System.VirtualKey.Add) // numpad * sign
            {
                multiply_Click(sender, e);
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
            temp1 = double.Parse(output.Text);
            output.Text = "";
            ops = "-";
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            temp1 = double.Parse(output.Text);
            output.Text = "";
            ops = "x";
        }

        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            temp1 = double.Parse(output.Text);
            output.Text = "";
            ops = "%";
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            temp1 = double.Parse(output.Text);
            output.Text = "";
            ops = "+";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            temp1 = double.MinValue;
            temp2 = double.MinValue;
            result = double.MinValue;
            output.Text = "0";
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            temp1 = double.Parse(output.Text);
            output.Text = "";
            ops = "÷";
        }

        private void equal_Click(object sender, RoutedEventArgs e)
        {
            switch (ops)
            {
                case "-":
                    temp2 = double.Parse(output.Text);
                    result = temp1 - temp2;
                    output.Text = result.ToString();
                    ops = "";
                    break;
                case "+":
                    temp2 = double.Parse(output.Text);
                    result = temp1 + temp2;
                    output.Text = result.ToString();
                    ops = "";
                    break;
                case "÷":
                    temp2 = double.Parse(output.Text);
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
                    temp2 = double.Parse(output.Text);
                    result = temp1 * temp2;
                    output.Text = result.ToString();
                    ops = "";
                    break;
                case "%":
                    temp2 = double.Parse(output.Text);
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
