using System;
using System.IO;
using System.Linq;

namespace Programowanie
{
    class Dane
    {
        public double[][] Pobierz()
        {
            double[][] list = File.ReadAllLines("dane.txt")
                   .Select(l => l.Split(' ').Select(i => double.Parse(i)).ToArray()).ToArray();

            return list;
        }

        public void Tasuj(double[][] list)
        {
            int new_i;
            int new_j;
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = 0; j < list[i].Length; j++)
                {
                    double tmp = list[i][j];
                    Random random = new Random();

                    new_i = random.Next(0, list.Length - 1);
                    new_j = random.Next(0, list[i].Length - 1);

                    list[i][j] = list[new_i][new_j];
                    list[new_i][new_j] = tmp;
                }
            }
        }

        public double Normalizuj_min_max(double[][] list, double new_min, double new_max, double min, double max, double x)
        {
            x = (x - min) * (new_max - new_min) / (max - min) + new_min;

            return x;
        }
        public double Normalizuj_mean(double[][] list, double min, double max, double average, double x)
        {
            x = (x - average) / (max - min);

            return x;
        }
        public double Normalizuj_standaryzacja(double[][] list, double average, double deviation, double x)
        {
           x = (x - average) / deviation;

            return x;
        }
    }
}
