using System;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();

            stack.isEmpty();

            stack.Push(10);
            stack.Push(11);
            stack.Push(12);
            stack.Push(13);
            stack.Push(14);

            stack.Show();

            Console.WriteLine(stack.Peek() + " - Peek");
            Console.WriteLine(stack.Pop()  + " - Pop");
            Console.WriteLine(stack.Peek() + " - Peek");
            Console.WriteLine();

            stack.Show();

            Console.WriteLine(stack.Find(12) + " - F(12)");
            Console.WriteLine(stack.Peek()  + " - Peek");
            Console.WriteLine();

            stack.Show();

            Console.WriteLine(stack.Find(12) + " - F(12)");
            Console.WriteLine(stack.Peek()  + " - Peek");

            stack.Show();

            Console.Read();

        }

        class Stack
        {
            private double[] S = new double[0];

            public void Push(double data)
            {
                int n = Size();
                Array.Resize<double>(ref S, n + 1);
                S[n] = data;
            }

            public double Pop()
            {
                int n = Size();
                double result = S[n - 1];
                Array.Resize<double>(ref S, n - 1);

                return result;
            }

            public double Peek()
            {
                return S[Size() - 1];
            }

            public bool isEmpty()
            {
                if (Size() > 0) return false;

                Console.WriteLine("The stack is empty.");
                return true;
            }

            public double Find(double element)
            {
                double[] s = Copy();
                int i = Size() - 1;

                while (!isEmpty())
                {
                    if (Peek() == element)
                    {
                        Back(s);
                        return i;
                    }
                    Pop();
                    i--;
                }
                Back(s);
                throw new Exception("This element does not exist.");
            }

            public int Size() //Rozmiar stosu
            {
                return S.Length;
            }

            // ###########################################

            private double[] Copy() // Kopiowanie kolejki 'Q' do tablicy 'copy'
            {
                int n = Size();
                double[] copy = new double[n];

                for (int i = 0; i < n; i++)
                    copy[i] = S[i];

                return copy;
            }

            private void Back(double[] temp) // Kopiowanie tablicy 'temp' do kolejki 'Q'
            {
                int n = temp.Length;
                Array.Resize<double>(ref S, n);
                for (int i = 0; i < n; i++)
                    S[i] = temp[i];
            }

            // ##################################################################
            // Do testów:

            public void Show() // Wypisywanie całej tablicy
            {
                Console.WriteLine("======");
                for (int i = 0; i < Size(); i++)
                    Console.WriteLine(i + ". " + S[i]);
                Console.WriteLine("======\n");
            }
        }
    }
}
