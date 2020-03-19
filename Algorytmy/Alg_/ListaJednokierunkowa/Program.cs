using System;

namespace ListaJednokierunkowa
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;

            List list = new List();
            Console.WriteLine("Enter " + n + " values:");
            for (int i = 0; i < n; i++)
                list.Add(Convert.ToDouble(Console.ReadLine()));
            list.Show();
            Console.WriteLine("Enter 1 value on 2nd position:");
            list.Add(Convert.ToDouble(Console.ReadLine()), 2);
            list.Show();
            Console.WriteLine("Enter 1 value on 4th position:");
            list.Add(Convert.ToDouble(Console.ReadLine()), 4);
            list.Show();
            Console.WriteLine("Deleting last value:");
            list.Delete();
            list.Show();
            Console.WriteLine("Deleting 3th value:");
            list.Delete(3);
            list.Show();
        }
    }

    class List
    {
        private static double[] list;
        private static int lptr = 0, size = 0;

        public List()
        {
            list = new double[0];
        }

        public void Add(double element)
        {
            size++;
            Array.Resize(ref list, size);
            list[lptr] = element;
            lptr++;
        }

        public void Add(double element, int position)
        {
            size++;
            Array.Resize(ref list, size);
            for (int i = size - 1; i > position; i--)
                list[i] = list[i - 1];

            list[position] = element;
        }

        public void Show()
        {
            Console.WriteLine(" > Values <");
            for (int i = 0; i < size; i++)
                Console.WriteLine(i + ". " + list[i]);
        }

        public void Delete()
        {
            size--;
            Array.Resize(ref list, size);
        }

        public void Delete(int position)
        {
            for (int i = position; i < size - 1; i++)
                list[i] = list[i + 1];

            size--;
            Array.Resize(ref list, size);
        }
    }
}
