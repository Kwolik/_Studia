using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Kalkulator
{
    public partial class MainWindow : Window
    {
        private decimal result = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonClick_digit(object sender, RoutedEventArgs e) // Wciskanie cyfr
        {
            Button b = (Button)sender;
            string current = label_current.Content.ToString();
            string previous = label_previous.Text.ToString();

            if (previous.Contains("=")) // Jeśli jest wynik, po wciśnieciu cyfry następuje reset
                buttonClick_Clear(sender, e);

            else
            if (previous.Length > 1)
            {
                char sign = previous.ToString().ElementAt(previous.Length - 2);
                if (current == "" && result.ToString() != "" && sign != '+' && sign != '-' && sign != '×' && sign != '÷')
                {
                    buttonClick_Clear(sender, e);
                    result = Convert.ToDecimal(b.Content);
                }
            }
            if (current != "0" && current.Length < 15)
                label_current.Content += b.Content.ToString();

            if (current == "0")
                label_current.Content = b.Content.ToString();

            if (current == "-" && b.Content.ToString() == "0")
                label_current.Content = "0";
            if (label_result.Content.ToString() == "Dzielenie przez zero!")
                label_result.Content = "";
        }

        private void buttonClick_Clear(object sender, RoutedEventArgs e) // Wciskanie Clear
        {
            label_current.Content = "";
            label_previous.Text = "";
            label_result.Content = "";
            label_operation.Content = "";
            result = 0;
        }

        private void buttonClick_Opp(object sender, RoutedEventArgs e) // Wciskanie +/-
        {
            string temp = "";
            string current = label_current.Content.ToString();

            if (current != "" && current.ToCharArray().ElementAt(0) == '-')
                label_current.Content = current.Remove(0, 1);
            
            else
            if ( current != "0")
            {
                temp = current;
                label_current.Content = "-" + temp;
            }
        }

        private void buttonClick_Comma(object sender, RoutedEventArgs e) // Wciskanie przecinka
        {
            string current = label_current.Content.ToString();
            bool isComma = current.Contains(',');
            string previous = label_previous.Text.ToString();

            if (previous.Contains("="))
            {
                buttonClick_Clear(sender, e);
                label_current.Content = "0,";
            }

            else
            if (current != "" && !isComma)
                label_current.Content += ",";
            else
                if (current == "")
                label_current.Content = "0,";
        }

        private void Operations(decimal current, char operation) // Działania
        {
                switch (operation)
                {
                    case '+':
                        result += current;
                        break;
                    case '-':
                        result -= current;
                        break;
                    case '×':
                        result *= current;
                        break;
                    case '÷':
                    if (current != 0)
                        result /= current;
                    else
                        label_result.Content = "Dzielenie przez zero!";
                    break;
                }
        }

        private void buttonClick_Operation(object sender, RoutedEventArgs e) // Wciskanie Plus/Minus/Mnożenie/Dzielenie
        {
            Button b = (Button)sender;
            string current = label_current.Content.ToString();
            string previous = label_previous.Text.ToString();
            char operation = Convert.ToChar(b.Content);

            if (current != "" && current.Last() != ',' || current == "" && previous != "")
            {
                label_current.Content = "";
                label_previous.Text += current + " " + operation + " ";
                label_operation.Content = operation;

                if(previous.Contains("=")) // Jeśli jest wynik, to do (od) wyniku dodawana/odejmowana/mnożona/dzielona jest nowa wartość
                {
                    string temp = result.ToString();
                    buttonClick_Clear(sender, e);
                    
                    label_previous.Text = temp + " " + b.Content + " ";
                    label_operation.Content = Convert.ToChar(b.Content);
                    result = Convert.ToDecimal(temp);
                }

                else
                if (previous != "")
                {
                    string [] a = label_previous.Text.ToString().Split(' ');
                    if (a.Length > 4)
                    {
                        char op = Convert.ToChar(a[a.Length - 4]);

                        Operations(Convert.ToDecimal(current), op);
                    }
                }
                else
                    if(current != "")
                    result = Convert.ToDecimal(current);
                if (result.ToString() == "-0")
                    result = 0;
                if (label_result.Content.ToString() != "Dzielenie przez zero!")
                    label_result.Content = result;
                else
                    DivideByZero();
            }
        }

        private void buttonClick_Back(object sender, RoutedEventArgs e) // Cofanie
        {
            string current = label_current.Content.ToString();

            if (current != "")
                label_current.Content = current.Remove(current.Length - 1, 1);
        }

        private void buttonClick_Equals(object sender, RoutedEventArgs e) // =
        {
            string prev = label_previous.Text.ToString();
            string cur = label_current.Content.ToString();
            

            if (prev.Contains("=") && cur != "") // Jeśli jest wynik, po wciśnieciu = wykonuje się ostatnie działanie
            {
                char operation = Convert.ToChar(label_operation.Content);
                string res = result.ToString();
                Operations(Convert.ToDecimal(cur), operation);
                label_previous.Text = res + " " + operation + " " + cur + " = " + result;
                label_result.Content = result;
            }

            else
            if (prev.Length > 0)
            {
                char op;

                if (cur == "")
                {
                    op = Convert.ToChar(label_operation.Content);
                    string[] s = prev.Split(' ');
                    string c = Convert.ToString(s[s.Length - 3]);

                    prev = prev.Remove(2);
                    string temp = result.ToString();
                    Operations(Convert.ToDecimal(c), op);
                    label_previous.Text = temp + " " + op + " " + c + " = " + result;
                }
                else
                {
                    op = Convert.ToChar(prev.ElementAt(prev.Length - 2));

                    if (prev != "" && cur != "")
                    {
                        decimal current = Convert.ToDecimal(label_current.Content);
                        if (op == '+' || op == '-' || op == '×' || op == '÷')
                        {
                            prev = prev.Remove(prev.Length - 2, 1);
                            Operations(current, op);
                        }
                        label_previous.Text = prev + op + " " + current + " = " + result;
                    }
                    else
                    {
                        label_operation.Content = "=";
                        label_previous.Text = result.ToString();
                    }
                }
                if (label_result.Content.ToString() != "Dzielenie przez zero!")
                    label_result.Content = result;
                else
                    DivideByZero();
            }
        }
        private void DivideByZero() // Dzielenie przez zero
        {
            label_result.Content = "Dzielenie przez zero!"; ;
            label_current.Content = "";
            label_previous.Text = "";
            label_operation.Content = "";
        }
    }
}