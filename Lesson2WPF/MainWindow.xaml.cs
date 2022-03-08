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
using System.Windows.Controls.Primitives;


namespace Lesson2WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private double temp, op1, op2, result;
        private string oper = null;
        private bool next;

        private void Aut()
        {
            op2 = Convert.ToDouble(Out_1.Text);
            switch (oper)
            {
                case "+":
                    result = op1 + op2;
                    break;
                case "-":
                    result = op1 - op2;
                    break;
                case "×":
                    result = op1 * op2;
                    break;
                case "÷":
                    result = op1 / op2;
                    break;
                default:
                    break;

            }
            Out_1.Text = Convert.ToString(result);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            contextMenu.PlacementTarget = btnMenu;
            contextMenu.Placement = PlacementMode.Bottom;
            contextMenu.IsOpen = true;
        }
        private void B_NUM_Click(object sender, RoutedEventArgs e)
        {
            Button numBtn = sender as Button;
            string numstr = numBtn.Content.ToString();
            if (numstr != "0")
            {
                if (Out_1.Text == "0" || next)
                {
                    Out_1.Text = numstr;
                    if (next)
                    {
                        next = false;
                    }
                }
                else
                    Out_1.Text += numstr;
            }
            else
            {
                if (Out_1.Text != "0")
                {
                    Out_1.Text += "0";
                }
                if (next)
                {
                    Out_1.Text = "0";
                    next = false;
                }
            }
        }

        private void B_C_Click(object sender, RoutedEventArgs e)
        {
            Out_1.Text = "0";
            Out_2.Text = "";
            oper = null;
        }

        private void B_CE_Click(object sender, RoutedEventArgs e)
        {
            Out_1.Text = "0";
            Out_2.Text = "";
            oper = null;
        }

        private void operater_Button_Click(object sender, RoutedEventArgs e)
        {
            Button operaterBtn = sender as Button;
            string operater = operaterBtn.Content.ToString();
            Out_2.Text += Out_1.Text + operater;
            if (oper != null)
            {
                Aut();
            }
            op1 = Convert.ToDouble(Out_1.Text);
            oper = operater;
            next = true;
        }

        private void B_delete_Click(object sender, RoutedEventArgs e)
        {
            if (!next)
            {
                if (Out_1.Text.Length == 1)
                {
                    Out_1.Text = "0";
                }
                else
                {
                    Out_1.Text = Out_1.Text.Substring(0, Out_1.Text.Length - 1);
                }
            }
        }

        private void B_reciprocal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                temp = Convert.ToDouble(Out_1.Text);
                temp = 1 / temp;
                Out_1.Text = Convert.ToString(temp);
            }
            catch (Exception ee)
            {
                Out_1.Text = "Divisor cannot be 0";
            }
        }

        private void B_sq_Click(object sender, RoutedEventArgs e)
        {
            temp = Convert.ToDouble(Out_1.Text);
            temp = Math.Pow(temp, 2);
            Out_1.Text = Convert.ToString(temp);
        }

        private void B_cu_Click(object sender, RoutedEventArgs e)
        {
            temp = Convert.ToDouble(Out_1.Text);
            temp = Math.Pow(temp, 3);
            Out_1.Text = Convert.ToString(temp);
        }

        private void B_radical_Click(object sender, RoutedEventArgs e)
        {
            temp = Convert.ToDouble(Out_1.Text);
            temp = Math.Pow(temp, 0.5);
            Out_1.Text = Convert.ToString(temp);
        }

        private void B_per_Click(object sender, RoutedEventArgs e)
        {
            temp = Convert.ToDouble(Out_1.Text);
            temp = temp / 100;
            Out_1.Text = Convert.ToString(temp);
        }

        private void B_eq_Click(object sender, RoutedEventArgs e)
        {
            op2 = Convert.ToDouble(Out_1.Text);
            switch (oper)
            {
                case "+":
                    result = op1 + op2;
                    break;
                case "-":
                    result = op1 - op2;
                    break;
                case "×":
                    result = op1 * op2;
                    break;
                case "÷":
                    result = op1 / op2;
                    break;
                default:
                    break;

            }
            oper = null;
            Out_1.Text = Convert.ToString(result);
            Out_2.Text = "";
        }

        private void B_opp_Click(object sender, RoutedEventArgs e)
        {
            temp = Convert.ToDouble(Out_1.Text);
            if (temp != 0)
            {
                temp = 0 - temp;
            }
            Out_1.Text = Convert.ToString(temp);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Out_1.Text += ".";
        }

    }
}
