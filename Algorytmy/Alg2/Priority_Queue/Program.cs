using System;

namespace Priority_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Priority_Queue queue = new Priority_Queue();

            queue.Enqueue(0,2);
            queue.Enqueue(1,1);
            queue.Enqueue(2,3);
            queue.Enqueue(3,1);
            queue.Enqueue(4,2);

            queue.Show();

            Console.WriteLine(queue.Peek() + " - Peek");
            Console.WriteLine(queue.Dequeue() + " - Deq");
            Console.WriteLine(queue.Peek() + " - Peek");
            Console.WriteLine();

            queue.Show();

            Console.WriteLine(queue.Find(4) + " - F(4)");
            Console.WriteLine(queue.Peek() + " - Peek");
            Console.WriteLine();

            queue.Show();

            Console.WriteLine(queue.Find(4) + " - F(4)");
            Console.WriteLine(queue.Peek() + " - Peek");

            queue.Show();




            Console.Read();
        }
    }

    class Priority_Queue
    {
        private double[] Q = new double[0];
        private int[]    P = new int[0];

        public void Enqueue(double data, int p) // Dodawanie elementu na koniec kolejki
        {
            int n = Size();
            Array.Resize<double>(ref Q, n + 1);
            Array.Resize<int>   (ref P, n + 1);

            Q[n] = data;
            P[n] = p;

            if (n > 0)
                SortByPriority();

        }

        public double Dequeue() // Usuwanie 0-wego elementu i zwracanie go
        {
            int n = Size();
            double temp = Q[0];
            double p    = P[0];

            for (int i = 1; i < n; i++)
            {
                Q[i - 1] = Q[i];
                P[i - 1] = P[i];
            }
            Array.Resize<double>(ref Q, n - 1);
            Array.Resize<int>   (ref P, n - 1);
            return temp;
        }

        public double Peek() // Zwracanie 0-wego elementu bez usuwania go
        {
            return Q[0];
        }

        public bool isEmpty() // Sprawdzanie, czy kolejka jest pusta
        {
            if (Size() > 0) return false;

            Console.WriteLine("The queue is empty.");
            return true;
        }

        public int Find(double element) // Znajdywanie elementu o podanym indeksie
        {
            double[] queue = Copy().Item1;
            int[] p = Copy().Item2;
            int i = 0;

            while (!isEmpty())
            {
                if (Peek() == element)
                {
                    Back(queue,p);
                    return i;
                }
                Dequeue();
                i++;
            }
            Back(queue,p);
            throw new Exception("This element does not exist.");
        }

        public int Size() //Rozmiar kolejki
        {
            return Q.Length;
        }

        // ##################################################

        private (double[], int[]) Copy() // Kopiowanie kolejki 'Q' do tablicy 'copy'
        {
            int n = Size();
            double[] copy = new double[n];
            int[] p = new int[n];

            for (int i = 0; i < n; i++)
            {
                copy[i] = Q[i];
                p[i] = P[i];
            }

            return (copy,p);
        }

        private void SortByPriority() // Sortowanie
        {
            int n = Size();
            double temp;
            int p;
            int i = 1;
            int j = 0;
            while (i < n)
            {
                j = i;
                while (P[i] < P[i - 1])
                {
                    temp = Q[i];
                    p = P[i];
                    Q[i] = Q[i - 1];
                    P[i] = P[i - 1];
                    Q[i - 1] = temp;
                    P[i - 1] = p;

                    if (i > 1)
                        i--;
                }
                i = j;
                i++;
            }
        }

        private void Back(double[] temp, int[] p) // Kopiowanie tablicy 'temp' do kolejki 'Q'
        {
            int n = temp.Length;
            Array.Resize<double>(ref Q, n);
            Array.Resize<int>(ref P, n);
            for (int i = 0; i < n; i++)
            {
                Q[i] = temp[i];
                P[i] = p[i];
            }
        }

        // ##################################################################
        // Do testów:

        public void Show() // Wypisywanie całej tablicy
        {
            Console.WriteLine("======");
            for (int i = 0; i < Size(); i++)
                Console.WriteLine(i + ". " + Q[i] + " - P: " + P[i]);
            Console.WriteLine("======\n");
        }
    }
}