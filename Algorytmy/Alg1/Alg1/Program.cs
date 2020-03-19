using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WartoscNajwieksza
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] Data = GetData();
            double maximum = FindMaximum(Data);
            Console.WriteLine("The highest value is: " + maximum); 

            Pause();
        }
        static double []GetData()
        {
            string path = "data.txt";
            string[] Lines = File.ReadAllLines(path);
            int n = Lines.Length;
            double[] Data = new double[n];
            for (int i = 0; i < n; i++)
            {
                Data[i] = Convert.ToDouble(Lines[i]);
            }   
            return Data;
        }
        static double FindMaximum(double[] Data)
        {
            int n = Data.Length;
            double maximum = Data[0];
            for (int i = 1; i < n; i++)
            {
                if (Data[i] > maximum)
                    maximum = Data[i];
            }
            return maximum;
        }
        static void Pause()
        {
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
