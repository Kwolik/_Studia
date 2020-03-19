using System;

namespace KolejkaPriorytet
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 3;
            Queue q = new Queue(size + 2);

            q.Show();
            Console.WriteLine("Write 3 values and priorities");
            for (int i = 0; i < size; i++)
            {
                Console.Write(i + ". ");
                double n = Convert.ToDouble(Console.ReadLine());
                Console.Write("     ");
                int p = Convert.ToInt32(Console.ReadLine());
                q.Enqueue(n,p);
            }
            Console.WriteLine("Queue:");
            q.Show();
            Console.WriteLine();
            Console.WriteLine("Write another 2 values and priorities");
            for (int i = 0; i < 2; i++)
            {
                Console.Write(i + ". ");
                double n = Convert.ToDouble(Console.ReadLine());
                Console.Write("     ");
                int p = Convert.ToInt32(Console.ReadLine());
                q.Enqueue(n, p);
            }
            Console.WriteLine();
            Console.WriteLine("Queue:");
            q.Show();
            Console.WriteLine("Dequeue 1:");
            q.Dequeue();
            q.Show();
            Console.WriteLine("Dequeue 2:");
            q.Dequeue();
            q.Show();
            Console.WriteLine("Dequeue 3:");
            q.Dequeue();
            q.Show();

            q.Front();

            Console.WriteLine("\n\nEnd");
            Console.Read();
        }
    }

    class Queue
    {
        private static double[][] queue;
        private static int count, f, r;

        public Queue(int c)
        {
            f = 0;
            r = 0;
            count = c;

            queue = new double[count][];
            for (int i = 0; i < count; i++)
                queue[i] = new double[2];
            
            
        }

        public void Enqueue(double element, int prio) // Dodawanie elementów
        {
            if (count == r) // Jeśli kolejka jest pełna, to koniec
            {
                Console.WriteLine("Queue is full.");
                return;
            }
            else // Jeśli kolejka nie jest pełna
            {
                queue[r][0] = element; // Dodawanie kolejnego elementu
                queue[r][1] = prio;

                //for (int i = 0; i <= r; i++)
                //{
                //    Console.WriteLine(i + ". " + queue[i][0] + " " + "Pr: " + queue[i][1]);
                //}

                SortByPriority(r);
                r++;
            }
            return;
        }

        public void SortByPriority(int cur)
        {
            double temp;
            double temp2;
            int i = 1;
            int j = 0;
            while(i <= cur)
            {
                j = i;
                while (queue[i][1] < queue[i - 1][1])
                {
                    temp = queue[i][0];
                    temp2 = queue[i][1];
                    queue[i][0] = queue[i - 1][0];
                    queue[i][1] = queue[i - 1][1];
                    queue[i - 1][0] = temp;
                    queue[i - 1][1] = temp2;

                    if (i > 1)
                    i--;
                }
                i = j;
                i++;
            }

            //for (int i = 0; i < cur; i++)
            //{
            //    for (int j = 0; j < cur; j++)
            //    {
            //        if(queue[i][1] != 0)
            //            if (queue[i][1] < queue[j][1])
            //            {
            //                temp = queue[i][0];
            //                    temp2 = queue[i][1];
            //                queue[i][0] = queue[j][0];
            //                    queue[i][1] = queue[j][1];
            //                queue[j][0] = temp;
            //                    queue[j][1] = temp2;

            //            }
            //    }
            //}
            //Console.WriteLine("=================== Po sortowaniu");
            //for (int i = 0; i <= r; i++)
            //{
            //    Console.WriteLine(i + ". " + queue[i][0] + " " + "Pr: " + queue[i][1]);
            //}
            //Console.WriteLine("=====================");
        }

        public void Dequeue() // Usuwanie danych
        {
            if (f == r) // Jeśli kolejka jest pusta, to koniec
            {
                Console.WriteLine("Queue is empty.");
                return;
            }
            else // Jeśli kolejka nie jest pusta
            {
                for (int i = 0; i < r - 1; i++) // Przesunięcie danych w kolejce
                {
                    queue[i][0] = queue[i + 1][0];
                    queue[i][1] = queue[i + 1][1];
                }
                if (r < count)
                    queue[r][0] = 0;
                r--;
            }
            return;
        }
        public void Show() // Wyświetlanie danych
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
                Console.WriteLine(i + ". " + queue[i][0] + " Prio: " + queue[i][1]);
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
            Console.WriteLine("Front Element is: " + queue[f][0]);
            return;
        }
    }
}