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
using System.Diagnostics;
namespace Laskin
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> merkit = new List<string>();


        //string num;
        double num1, num2, vastausTemp;
        bool merkkiLaitettu = true;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void setNum(string num)
        {
            if (merkkiLaitettu)
            {
                merkkiLaitettu = false;
                merkit.Add(num);
            }
            else
            {
                merkit[merkit.Count - 1] += num;
            }
            lasku.Text += num;
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            setNum("0");
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            setNum("9");
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            setNum("8");
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            setNum("7");
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            setNum("6");
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            setNum("5");
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            setNum("4");
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            setNum("3");
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            setNum("2");
        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            setNum("1");
        }

        private void is_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (merkit.IndexOf("*") != -1)
                {
                    double.TryParse(merkit[merkit.IndexOf("*") - 1], out num1);
                    double.TryParse(merkit[merkit.IndexOf("*") + 1], out num2);
                    vastausTemp = num1 * num2;
                    merkit.RemoveAt(merkit.IndexOf("*") - 1);
                    merkit.RemoveAt(merkit.IndexOf("*") + 1);
                    merkit[merkit.IndexOf("*")] = vastausTemp.ToString();
                    lasku.Text = vastausTemp.ToString();
                }
               else if (merkit.IndexOf("/") != -1)
                {
                    double.TryParse(merkit[merkit.IndexOf("/") - 1], out num1);
                    double.TryParse(merkit[merkit.IndexOf("/") + 1], out num2);
                    vastausTemp = num1 / num2;
                    merkit.RemoveAt(merkit.IndexOf("/") - 1);
                    merkit.RemoveAt(merkit.IndexOf("/") + 1);
                    merkit[merkit.IndexOf("/")] = vastausTemp.ToString();
                    lasku.Text = vastausTemp.ToString();
                }
                else if (merkit.IndexOf("+") != -1)
                {
                    double.TryParse(merkit[merkit.IndexOf("+") - 1], out num1);
                    double.TryParse(merkit[merkit.IndexOf("+") + 1], out num2);
                    vastausTemp = num1 + num2;
                    merkit.RemoveAt(merkit.IndexOf("+") - 1);
                    merkit.RemoveAt(merkit.IndexOf("+") + 1);
                    merkit[merkit.IndexOf("+")] = vastausTemp.ToString();
                    lasku.Text = vastausTemp.ToString();
                }
                else if (merkit.IndexOf("-") != -1)
                {
                    double.TryParse(merkit[merkit.IndexOf("-") - 1], out num1);
                    double.TryParse(merkit[merkit.IndexOf("-") + 1], out num2);
                    vastausTemp = num1 - num2;
                    merkit.RemoveAt(merkit.IndexOf("-") - 1);
                    merkit.RemoveAt(merkit.IndexOf("-") + 1);
                    merkit[merkit.IndexOf("-")] = vastausTemp.ToString();
                    lasku.Text = vastausTemp.ToString();
                }
                else
                {
                    break;
                }

                //idk
            }
        }
        private void setMerkki(string merkki)
        {
            if (!merkkiLaitettu)
            {
                merkkiLaitettu = true;
                merkit.Add(merkki);
                lasku.Text += merkki;
            }
        }
        private void plus_Click(object sender, RoutedEventArgs e)
        {
            setMerkki("+");
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            setMerkki("-");
        }

        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            setMerkki("*");
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D1) setNum("1");
            if (e.Key == Key.D2) setNum("2");
            if (e.Key == Key.D3) setNum("3");
            if (e.Key == Key.D4) setNum("4");
            if (e.Key == Key.D5) setNum("5");
            if (e.Key == Key.D6) setNum("6");
            if (e.Key == Key.D7) setNum("7");
            if (e.Key == Key.D8) setNum("8");
            if (e.Key == Key.D9) setNum("9");
            if (e.Key == Key.D0) setNum("0");
            if (e.Key == Key.Add) setMerkki("+");
            if (e.Key == Key.Subtract) setMerkki("-");
            if (e.Key == Key.Multiply) setMerkki("*");
            if (e.Key == Key.Divide) setMerkki("/");
            if (e.Key == Key.OemPlus) setMerkki("+");
            if (e.Key == Key.OemMinus) setMerkki("-");
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            setMerkki("/");
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            merkit.RemoveAt(merkit.Count - 1);
            lasku.Text = lasku.Text.Remove(lasku.Text.Length - 1);
            if (merkit.Count == 0) merkkiLaitettu = true;

            else
            {
                if (merkit[merkit.Count - 1] == "*" || merkit[merkit.Count - 1] == "/" || merkit[merkit.Count - 1] == "+" || merkit[merkit.Count - 1] == "-") merkkiLaitettu = true;
            }
        }
    }
}
