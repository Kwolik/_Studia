using System;

namespace Doubly_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class List
    {
        private Element head;
        private Element tail;

        public List()
        {
            tail = head = null;
        }

        public void Insert(double data)
        {
            var temp = head;
            head = new Element(data);
            head.next = temp;
        }

        public void InsertToEnd(double data)
        {
            var temp = head;
            while (temp.next != null)
                temp = temp.next;

            temp.next = new Element(data);
        }

        public double Remove(int index)
        {
            if (index > Size() || index < 0)
                throw new Exception("Out of range");

            double element;

            if (index == 0)
            {
                element = head.element;
                head = head.next;
            }
            else if (index == Size() - 1)
            {
                var temp = head;
                while (temp.next.next != null)
                    temp = temp.next;

                element = temp.next.element;

                temp.next = null;
            }
            else
            {
                var prev = head;
                for (int i = 0; i < index - 1; i++)
                    prev = prev.next;

                element = prev.next.element;

                var newNext = prev.next.next;
                prev.next = newNext;
            }

            return element;
        }

        public int Find(double element)
        {
            var temp = head;
            int i = 0;
            while (temp != null)
            {
                if (temp.element == element)
                    return i;

                temp = temp.next;
                i++;
            }

            throw new Exception("This element does not exist.");
        }

        public int Size()
        {
            var temp = head;
            int i = 0;
            while (temp != null)
            {
                i++;
                temp = temp.next;
            }

            return i;
        }

        public void Show()
        {
            if (Size() == 0)
            {
                Console.WriteLine("List is empty");
                return;
            }

            var temp = head.next;
            int i = 1;
            Console.WriteLine("======");
            Console.WriteLine(0 + ". " + head.element);
            while (temp != null)
            {
                Console.WriteLine(i + ". " + temp.element);
                temp = temp.next;
                i++;
            }
            Console.WriteLine("======\n");
        }

        private class Element
        {
            public Element next;
            public Element prev;
            public double element;

            public Element(double el)
            {
                element = el;
                prev = next = null;
            }
        }
    }
}
