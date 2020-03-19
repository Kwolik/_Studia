using System;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();

            queue.Enqueue(0);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

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

    class Queue
    {
        private double[] Q = new double[0];

        public void Enqueue(double data) // Dodawanie elementu na koniec kolejki
        {
            int n = Size();
            Array.Resize<double>(ref Q, n + 1);
            Q[n] = data;
        }

        public double Dequeue() // Usuwanie 0-wego elementu i zwracanie go
        {
            int n = Size();
            double temp = Q[0];

            for (int i = 1; i < n; i++)
                Q[i - 1] = Q[i];
            Array.Resize<double>(ref Q, n - 1);
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
            double[] queue = Copy();
            int i = 0;

            while(!isEmpty())
            {
                if (Peek() == element)
                {
                    Back(queue);
                    return i;
                }
                Dequeue();
                i++;
            }
            Back(queue);
            throw new Exception("This element does not exist.");
        }

        public int Size() //Rozmiar kolejki
        {
            return Q.Length;
        }

        // ###########################################

        private double[] Copy() // Kopiowanie kolejki 'Q' do tablicy 'copy'
        {
            int n = Size();
            double[] copy = new double[n];

            for (int i = 0; i < n; i++)
                copy[i] = Q[i];

            return copy;
        }

        private void Back(double[] temp) // Kopiowanie tablicy 'temp' do kolejki 'Q'
        {
            int n = temp.Length;
            Array.Resize<double>(ref Q, n);
            for (int i = 0; i < n; i++)
                Q[i] = temp[i];
        }

        // ##################################################################
        // Do testów:

        public void Show() // Wypisywanie całej tablicy
        {
            Console.WriteLine("======");
            for (int i = 0; i < Size(); i++)
                Console.WriteLine(i + ". " + Q[i]);
            Console.WriteLine("======\n");
        }
    }
}
