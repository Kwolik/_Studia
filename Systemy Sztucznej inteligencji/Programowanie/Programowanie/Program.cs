using System;
using System.Collections.Generic;
using System.Linq;

namespace Programowanie
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Dane dane = new Dane();
             // 1.1.
                 Console.WriteLine(" Pobierz");
                 double[][] list = dane.Pobierz();

                 for (int i = 0; i < list.Length; i++)
                 {
                     for (int j = 0; j < list[i].Length; j++)
                         Console.Write(list[i][j] + " ");
                     Console.WriteLine();
                 }
             // 1.2.
                 dane.Tasuj(list);

                 Console.WriteLine("\n Tasuj");
                 for (int i = 0; i < list.Length; i++)
                 {
                     for (int j = 0; j < list[i].Length; j++)
                         Console.Write(list[i][j] + " ");
                     Console.WriteLine();
                 }
             // 1.3.
                 double min = list[0].Min();
                 double max = list[0].Max();
                 for (int i = 0; i < list.Length; i++)
                     for (int j = 0; j < list[i].Length; j++)
                     {
                         if (list[i][j] < min)
                             min = list[i][j];
                         if (list[i][j] > max)
                             max = list[i][j];
                     }
                 double new_min = 3;
                 double new_max = 5.5;
             Console.WriteLine("\n\n Normalizuj");
             Console.WriteLine("   Min-Max:");
                     for (int i = 0; i < list.Length; i++)
                     {
                         for (int j = 0; j < list[i].Length; j++)
                             Console.Write(String.Format("{0:N2} ", dane.Normalizuj_min_max(list, new_min, new_max, min, max, list[i][j])));
                         Console.WriteLine();
                     }

             Console.WriteLine("\n   Standaryzacja:");
                     double sum = 0;
                     int count = 0;
                     double deviation = 0;
                     for (int i = 0; i < list.Length; i++)
                     {
                         for (int j = 0; j < list[i].Length; j++)
                             sum += list[i][j];
                         count += list[i].Length;
                     }
                     double average = sum / count;
                     sum = 0;
                     for (int i = 0; i < list.Length; i++)
                         for (int j = 0; j < list[i].Length; j++)
                             sum += (list[i][j] * list[i][j]);
                     deviation = Math.Sqrt(sum / count - (average * average));
                     for (int i = 0; i < list.Length; i++)
                     {
                         for (int j = 0; j < list[i].Length; j++)
                             Console.Write(String.Format("{0:N2} ", dane.Normalizuj_standaryzacja(list, average, deviation, list[i][j])));
                         Console.WriteLine();
                     }

             Console.WriteLine("\n   Mean:");
                     for (int i = 0; i < list.Length; i++)
                     {
                         for (int j = 0; j < list[i].Length; j++)
                             Console.Write(String.Format("{0:N2} ", dane.Normalizuj_mean(list, min, max, average, list[i][j])));
                         Console.WriteLine();
                     }
                     
    */
            //2.1.
            Grafika grafika = new Grafika();
                    int[,,] matrix = grafika.Macierz("img.png");
            //2.2.
                    int[,] gauss = grafika.Filtr_Gauss();
                    int[,] sharp = grafika.Filtr_Sharp();
                    int[,] blurr = grafika.Filtr_Blur();
                    
                //Gauss
                    grafika.Filtr(matrix, gauss, "Gauss");
                //Sharp
                    grafika.Filtr(matrix, sharp, "Sharp");
                //Blur
                    grafika.Filtr(matrix, blurr, "Blur");
            /*
            //3.1
            Console.WriteLine("\n\nBaza danych");
            List<Part> osoby = new List<Part>();
            osoby.Add(new Part() { ID_os = 1, IMIĘ_os = "Jan", NAZWISKO_os = "Nowak", WIEK_os = 20 });
            osoby.Add(new Part() { ID_os = 2, IMIĘ_os = "Bob", NAZWISKO_os = "Kowal", WIEK_os = 30 });
            osoby.Add(new Part() { ID_os = 3, IMIĘ_os = "Ola", NAZWISKO_os = "Opona", WIEK_os = 25 });

            Console.WriteLine();
            foreach (Part aPart in osoby)
            {
                Console.WriteLine(aPart);
            }
            */
            Console.Read();
        }
    }
}
