using System;

namespace Stos
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            Stack s = new Stack(n);

            for (int i = 0; i < n; i++)
                s.Push(i);

            while (!s.isEmpty())
            {
                s.Top();
                s.Pop();
            }
            
            Console.Read();
        }
    }

    class Stack
    {
        private static double[] stack;
        private static int sptr = 0, size = 0;

        public Stack(int n)
        {
            stack = new double[n];
            size = n;
        }

        public bool isEmpty()
        {
            if (sptr == 0) return true;
            return false;
        }

        public void Push(double data)
        {
            if (sptr < size)
                stack[sptr++] = data;
        }

        public void Pop()
        {
            if(sptr > 0) sptr--;
        }

        public void Top()
        {
            if(sptr > 1)
                Console.WriteLine(stack[sptr - 1]);
        }
    }
}
