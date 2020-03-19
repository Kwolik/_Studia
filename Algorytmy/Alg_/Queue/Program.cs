using System;

namespace Kolejka
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 3;
            Queue q = new Queue(size + 3);

            q.Peek();
            Console.WriteLine("Write 3 values");
            for (int i = 0; i < size; i++)
            {
                Console.Write(i + ". ");
                q.Enqueue(Convert.ToDouble(Console.ReadLine()));
            }
            Console.WriteLine("Queue:");
            q.Peek();
            Console.WriteLine();
            Console.WriteLine("Write another 2 values");
            for (int i = 0; i < 2; i++)
            {
                Console.Write(i + ". ");
                q.Enqueue(Convert.ToDouble(Console.ReadLine()));
            }
            Console.WriteLine();
            Console.WriteLine("Queue:");
            q.Peek();
            Console.WriteLine("Dequeue 1:");
            q.Dequeue();
            q.Peek();
            Console.WriteLine("Dequeue 2:");
            q.Dequeue();
            q.Peek();
            Console.WriteLine("Dequeue 3:");
            q.Dequeue();
            q.Peek();

            q.Front();

            Console.WriteLine("\n\nEnd");
            Console.Read();
        }
    }

    class Queue
    {
        private static double[] queue;
        private static int count, f, r;

        public Queue(int c)
        {
            f = 0;
            r = 0;
            count = c;
            queue = new double[count];
        }

        public void Enqueue(double element) // Dodawanie elementów
        {
            if (count == r) // Jeśli kolejka jest pełna, to koniec
            {
                Console.WriteLine("Queue is full.");
                return;
            }
            else // Jeśli kolejka nie jest pełna
            {
                queue[r] = element; // Dodawanie kolejnego elementu
                r++;
            }
            return;
        }

        public void Dequeue() // Usuwanie danych
        { 
            if (f == r) // Jeśli kolejka jest pusta, to koniec
            {
                Console.WriteLine("Queue is empty.");
                return;
            }
            else // Jeśli kolejka nie jets pusta
            {
                for (int i = 0; i < r - 1; i++) // Przesunięcie danych w kolejce
                {
                    queue[i] = queue[i + 1];
                }
                if (r < count)
                    queue[r] = 0;
                r--;
            }
            return;
        }
        public void Peek() // Wyświetlanie danych
        {
            int i;
            if (f == r)
            {
                Console.WriteLine("Queue is Empty.");
                return;
            }

            Console.WriteLine("==");
            for (i = f; i < r; i++)
            {
                Console.WriteLine(i + ". " + queue[i]);
            }
            Console.WriteLine("==");
            return;
        }
        public void Front() // Wyświetlanie elementu z pierwszej pozycji
        {
            if (f == r)
            {
                Console.WriteLine("Queue is Empty.");
                return;
            }
            Console.WriteLine("Front Element is: " + queue[f]);
            return;
        }
    }
}