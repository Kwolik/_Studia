using System;
using System.Collections.Generic;

namespace NotacjaPolska
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("                                                                      Input:             Output:");
            Console.WriteLine("If you want to convert expression into RPN, press (1)        Example: ( 3 + 5 ) * 2      3 5 + 2 *");
            Console.WriteLine("If you want to convert expression from RPN, press (2)        Example: 25 34 +            (25 + 34)");
            Console.Write(" >> ");
            string choice = Console.ReadLine();

            string s = GetExpression();
            string result = null;

            if (choice == "1")
                result = ToRPN(s);
            if (choice == "2")
                result = FromRPN(s);

            Console.WriteLine("After conversion: " + result);
            //Result(s);

            Console.Read();
        }
        static string GetExpression() // Pobranie wyrażenia
        {
            Console.WriteLine("Enter expression:");
            string expression = Console.ReadLine();

            expression = expression.Replace('.', ',');

            return expression;
        }

        static string FromRPN(string s) // Zamiana z odwróconej notacji polskiej na zwykłą
        {
            string[] Stack = new string[s.Length];
            List<object> NewExpression = new List<object>();
            string substring = null;
            int p = 0;
            string x1, x2;
            string result = null;

            for (int i = 0; i < s.Length; i++)
            {
                string number;
                if (s[i] != ' ')
                {
                    if (s[i] == '+' || s[i] == '-' || s[i] == '/' || s[i] == '*' || s[i] == '^') // operatory
                        NewExpression.Add(s[i]);                  
                    else
                    {
                        int temp = i;
                        int start = temp;
                        while (s[temp + 1] != ' ')
                            temp++;
                        int length = temp - start + 1;
                        number = s.Substring(start, length);

                        NewExpression.Add(number);
                        i += number.Length; // przeskoczenie na koniec liczby
                    }
                }
            }
            foreach (object i in NewExpression)
            {
                if (i.GetType() == typeof(string))
                    Stack[p++] = Convert.ToString(i);
                else
                {
                    x2 = Stack[--p];
                    x1 = Stack[--p];
                    switch ((char)i)
                    {
                        case '+':
                            substring = "(" + x1 + " + " + x2 + ")";
                            //x1 += x2;
                            break;
                        case '-':
                            substring = "(" + x1 + " - " + x2 + ")";
                            //x1 -= x2;
                            break;
                        case '*':
                            substring = "(" + x1 + " * " + x2 + ")";
                            //x1 *= x2;
                            break;
                        case '/':
                            substring = "(" + x1 + " / " + x2 + ")";
                            //x1 /= x2;
                            break;
                        case '^':
                            substring = "(" + x1 + "^" + x2 + ")";
                            break;
                    }
                    result = substring;
                    Stack[p++] = substring;
                }
            }

            return result;
        }

        static string ToRPN(string s)
        {
            Stack<string> Stack = new Stack<string>();
            List<string> result = new List<string>();
            string[] str = s.Split(' ');

            foreach (var i in str)
            {
                if (i == "(")
                    Stack.Push("(");

                if (i == ")")
                    while (Stack.Count != 0 && Stack.Peek() != "(")
                        result.Add(Stack.Pop());

                if (i == "+" || i == "-" || i == "*" || i == "/" || i == "^")
                {
                    while (Stack.Count != 0 && Priority(Stack.Peek()) >= Priority(i))
                        result.Add(Stack.Pop());
                    Stack.Push(i);
                }
                if (double.TryParse(i.ToString(), out double n))
                    result.Add(i);
            }

            while (Stack.Count != 0)
                result.Add(Stack.Pop());

            result.RemoveAll(x => x.StartsWith("("));

            string res = null;
            for (int i = 0; i < result.Count; i++)
                res += result[i] + " ";
            return res;
        }

        static int Priority(string c)
        {
            switch(c)
            {
                case "+": return 1;
                case "-": return 1;
                case "*": return 2;
                case "/": return 2;
                case "^": return 3;
            }
            return 0;
        }

        static void Result(string s) // Obliczanie wyniku
        {
            double[] Stack = new double[s.Length];
            List<object> NewExp = new List<object>();
            int p = 0;
            double x1, x2;

            for (int i = 0; i < s.Length; i++)
            {
                string number;
                if (s[i] != ' ')
                {
                    if (s[i] == '+' || s[i] == '-' || s[i] == '/' || s[i] == '*') // operatory
                    { 
                        NewExp.Add(s[i]);
                    }
                    else
                    {
                        int temp = i;
                        int start = temp;
                        while (s[temp + 1] != ' ')
                        {
                            temp++;
                        }
                        int length = temp - start + 1;
                        number = s.Substring(start, length);
                        double num = Convert.ToDouble(number);
                        NewExp.Add(num);
                        i += number.Length; // przeskoczenie na koniec liczby
                    }
                }
            }

            foreach (object i in NewExp)
            {
                if (i.GetType() == typeof(double))
                    Stack[p++] = (double)i;
                
                else
                {
                    x2 = Stack[--p];
                    x1 = Stack[--p];
                    switch((char)i)
                    {
                        case '+':
                            x1 += x2;
                            break;
                        case '-':
                            x1 -= x2;
                            break;
                        case '*':
                            x1 *= x2;
                            break;
                        case '/':
                            x1 /= x2;
                            break;
                    }
                    Stack[p++] = x1;
                }
            }
            Console.WriteLine(Stack[--p]);
        }
    }
}
